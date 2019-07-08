using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using netcore.Data;
using netcore.Models;
using netcore.Models.Invent;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace netcore.Services
{
    public class NetcoreService : INetcoreService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRoles _roles;
        private readonly SuperAdminDefaultOptions _superAdminDefaultOptions;

        public NetcoreService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context,
            SignInManager<ApplicationUser> signInManager,
            IRoles roles,
            IOptions<SuperAdminDefaultOptions> superAdminDefaultOptions)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
            _roles = roles;
            _superAdminDefaultOptions = superAdminDefaultOptions.Value;
        }

        public async Task SendEmailBySendGridAsync(string apiKey, string fromEmail, string fromFullName, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromFullName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email, email));
            await client.SendEmailAsync(msg);

        }

        public async Task SendEmailByGmailAsync(string fromEmail,
            string fromFullName,
            string subject,
            string messageBody,
            string toEmail,
            string toFullName,
            string smtpUser,
            string smtpPassword,
            string smtpHost,
            int smtpPort,
            bool smtpSSL)
        {
            var body = messageBody;
            var message = new MailMessage();
            message.To.Add(new MailAddress(toEmail, toFullName));
            message.From = new MailAddress(fromEmail, fromFullName);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = smtpUser,
                    Password = smtpPassword
                };
                smtp.Credentials = credential;
                smtp.Host = smtpHost;
                smtp.Port = smtpPort;
                smtp.EnableSsl = smtpSSL;
                await smtp.SendMailAsync(message);

            }

        }

        public async Task<bool> IsAccountActivatedAsync(string email, UserManager<ApplicationUser> userManager)
        {
            bool result = false;
            try
            {
                var user = await userManager.FindByNameAsync(email);
                if (user != null)
                {
                    //Add this to check if the email was confirmed.
                    if (await userManager.IsEmailConfirmedAsync(user))
                    {
                        result = true;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }


        public async Task<string> UploadFile(List<IFormFile> files, IHostingEnvironment env)
        {
            var result = "";

            var webRoot = env.WebRootPath;
            var uploads = System.IO.Path.Combine(webRoot, "uploads");
            var extension = "";
            var filePath = "";
            var fileName = "";


            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    extension = System.IO.Path.GetExtension(formFile.FileName);
                    fileName = Guid.NewGuid().ToString() + extension;
                    filePath = System.IO.Path.Combine(uploads, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    result = fileName;

                }
            }

            return result;
        }

        public async Task UpdateRoles(ApplicationUser appUser,
            ApplicationUser currentLoginUser)
        {
            try
            {
                await _roles.UpdateRoles(appUser, currentLoginUser);

                //so no need to manually re-signIn to make roles changes effective
                if (currentLoginUser.Id == appUser.Id)
                {
                    await _signInManager.SignInAsync(appUser, false);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreateDefaultSuperAdmin()
        {
            try
            {
                ApplicationUser superAdmin = new ApplicationUser();
                superAdmin.Email = _superAdminDefaultOptions.Email;
                superAdmin.UserName = superAdmin.Email;
                superAdmin.EmailConfirmed = true;
                superAdmin.isSuperAdmin = true;

                Type t = superAdmin.GetType();
                foreach (System.Reflection.PropertyInfo item in t.GetProperties())
                {
                    if (item.Name.Contains("Role"))
                    {
                        item.SetValue(superAdmin, true);
                    }
                }

                await _userManager.CreateAsync(superAdmin, _superAdminDefaultOptions.Password);

                //loop all the roles and then fill to SuperAdmin so he become powerfull
                foreach (var item in typeof(netcore.MVC.Pages).GetNestedTypes())
                {
                    var roleName = item.Name;
                    if (!await _roleManager.RoleExistsAsync(roleName)) { await _roleManager.CreateAsync(new IdentityRole(roleName)); }

                    await _userManager.AddToRoleAsync(superAdmin, roleName);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public VMStock GetStockByProductAndWarehouse(string productId, string warehouseId)
        {
            VMStock result = new VMStock();

            try
            {
                Product product = _context.Product.Where(x => x.productId.Equals(productId)).FirstOrDefault();
                Warehouse warehouse = _context.Warehouse.Where(x => x.warehouseId.Equals(warehouseId)).FirstOrDefault();

                if (product != null && warehouse != null)
                {
                    VMStock stock = new VMStock();
                    stock.Product = product.productCode;
                    stock.Warehouse = warehouse.warehouseName;
                    stock.QtyReceiving = _context.ReceivingLine.Where(x => x.productId.Equals(product.productId) && x.warehouseId.Equals(warehouse.warehouseId)).Sum(x => x.qtyReceive);
                    stock.QtyShipment = _context.ShipmentLine.Where(x => x.productId.Equals(product.productId) && x.warehouseId.Equals(warehouse.warehouseId)).Sum(x => x.qtyShipment);
                    stock.QtyTransferIn = _context.TransferInLine.Where(x => x.productId.Equals(product.productId) && x.transferIn.warehouseIdTo.Equals(warehouse.warehouseId)).Sum(x => x.qty);
                    stock.QtyTransferOut = _context.TransferOutLine.Where(x => x.productId.Equals(product.productId) && x.transferOut.warehouseIdFrom.Equals(warehouse.warehouseId)).Sum(x => x.qty);
                    stock.QtyOnhand = stock.QtyReceiving + stock.QtyTransferIn - stock.QtyShipment - stock.QtyTransferOut;

                    result = stock;
                }

                
            }
            catch (Exception)
            {

                throw;
            }

            return result;

        }

        public List<VMStock> GetStockPerWarehouse()
        {
            List<VMStock> result = new List<VMStock>();

            try
            {
                List<VMStock> stocks = new List<VMStock>();
                List<Product> products = new List<Product>();
                List<Warehouse> warehouses = new List<Warehouse>();
                warehouses = _context.Warehouse.ToList();
                products = _context.Product.ToList();
                foreach (var item in products)
                {
                    foreach (var wh in warehouses)
                    {
                        VMStock stock = stock = GetStockByProductAndWarehouse(item.productId, wh.warehouseId);
                        
                        if (stock != null) stocks.Add(stock);

                    }


                }

                result = stocks;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task InitDemo()
        {
            try
            {
              

                Branch branch = new Branch() { branchName = "HQ", isDefaultBranch = true, street1 = "Rua Orós, 92" };
                _context.Branch.Add(branch);

                List<Warehouse> whs = new List<Warehouse>() {
                    new Warehouse{warehouseName = "WH1", branch = branch, street1 = "Rua Orós, 92"},
                    new Warehouse{warehouseName = "WH2", branch = branch, street1 = "C/ Moralzarzal, 86"},
                    new Warehouse{warehouseName = "WH3", branch = branch, street1 = "184, chaussée de Tournai"},
                    new Warehouse{warehouseName = "WH4", branch = branch, street1 = "Åkergatan 24"},
                    new Warehouse{warehouseName = "WH5", branch = branch, street1 = "Berliner Platz 43"}
                };

                _context.Warehouse.AddRange(whs);

                List<Product> products = new List<Product>() {
                    new Product{productCode = "Chai", productName = "Chai", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Chang", productName = "Chang", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Aniseed Syrup", productName = "Aniseed Syrup", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Chef Anton's Cajun Seasoning", productName = "Chef Anton's Cajun Seasoning", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Chef Anton's Gumbo Mix", productName = "Chef Anton's Gumbo Mix", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Grandma's Boysenberry Spread", productName = "Grandma's Boysenberry Spread", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Uncle Bob's Organic Dried Pears", productName = "Uncle Bob's Organic Dried Pears", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Northwoods Cranberry Sauce", productName = "Northwoods Cranberry Sauce", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Mishi Kobe Niku", productName = "Mishi Kobe Niku", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Ikura", productName = "Ikura", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Queso Cabrales", productName = "Queso Cabrales", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Queso Manchego La Pastora", productName = "Queso Manchego La Pastora", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Konbu", productName = "Konbu", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Tofu", productName = "Tofu", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Genen Shouyu", productName = "Genen Shouyu", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Pavlova", productName = "Pavlova", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Alice Mutton", productName = "Alice Mutton", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Carnarvon Tigers", productName = "Carnarvon Tigers", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Teatime Chocolate Biscuits", productName = "Teatime Chocolate Biscuits", productType = ProductType.Food, uom = UOM.Pcs},
                    new Product{productCode = "Sir Rodney's Marmalade", productName = "Sir Rodney's Marmalade", productType = ProductType.Food, uom = UOM.Pcs}

                };
                _context.Product.AddRange(products);

                List<Vendor> vendors = new List<Vendor>() {
                    new Vendor{vendorName = "Exotic Liquids", street1 = "49 Gilbert St.", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "New Orleans Cajun Delights", street1 = "P.O. Box 78934", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Grandma Kelly's Homestead", street1 = "707 Oxford Rd.", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Tokyo Traders", street1 = "9-8 Sekimai Musashino-shi", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Cooperativa de Quesos 'Las Cabras'", street1 = "Calle del Rosal 4", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Mayumi's", street1 = "92 Setsuko Chuo-ku", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Pavlova, Ltd.", street1 = "74 Rose St. Moonie Ponds", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Specialty Biscuits, Ltd.", street1 = "29 King's Way", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "PB Knäckebröd AB", street1 = "Kaloadagatan 13", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Refrescos Americanas LTDA", street1 = "Av. das Americanas 12.890", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Heli Süßwaren GmbH & Co. KG", street1 = "Tiergartenstraße 5", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Plutzer Lebensmittelgroßmärkte AG", street1 = "Bogenallee 51", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Nord-Ost-Fisch Handelsgesellschaft mbH", street1 = "Frahmredder 112a", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Formaggi Fortini s.r.l.", street1 = "Viale Dante, 75", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Norske Meierier", street1 = "Hatlevegen 5", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Bigfoot Breweries", street1 = "3400 - 8th Avenue Suite 210", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Svensk Sjöföda AB", street1 = "Brovallavägen 231", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "Aux joyeux ecclésiastiques", street1 = "203, Rue des Francs-Bourgeois", size = BusinessSize.Enterprise},
                    new Vendor{vendorName = "New England Seafood Cannery", street1 = "Order Processing Dept. 2100 Paul Revere Blvd.", size = BusinessSize.Enterprise}
                };
                _context.Vendor.AddRange(vendors);

                List<Customer> customers = new List<Customer>() {
                    new Customer{customerName = "Hanari Carnes", street1 = "Rua do Paço, 67", size = BusinessSize.Enterprise},
                    new Customer{customerName = "HILARION-Abastos", street1 = "Carrera 22 con Ave. Carlos Soublette #8-35", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Hungry Coyote Import Store", street1 = "City Center Plaza 516 Main St.", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Hungry Owl All-Night Grocers", street1 = "8 Johnstown Road", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Island Trading", street1 = "Garden House Crowther Way", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Königlich Essen", street1 = "Maubelstr. 90", size = BusinessSize.Enterprise},
                    new Customer{customerName = "La corne d'abondance", street1 = "67, avenue de l'Europe", size = BusinessSize.Enterprise},
                    new Customer{customerName = "La maison d'Asie", street1 = "1 rue Alsace-Lorraine", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Laughing Bacchus Wine Cellars", street1 = "1900 Oak St.", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Lazy K Kountry Store", street1 = "12 Orchestra Terrace", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Lehmanns Marktstand", street1 = "Magazinweg 7", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Let's Stop N Shop", street1 = "87 Polk St. Suite 5", size = BusinessSize.Enterprise},
                    new Customer{customerName = "LILA-Supermercado", street1 = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", size = BusinessSize.Enterprise},
                    new Customer{customerName = "LINO-Delicateses", street1 = "Ave. 5 de Mayo Porlamar", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Lonesome Pine Restaurant", street1 = "89 Chiaroscuro Rd.", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Magazzini Alimentari Riuniti", street1 = "Via Ludovico il Moro 22", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Maison Dewey", street1 = "Rue Joseph-Bens 532", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Mère Paillarde", street1 = "43 rue St. Laurent", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Morgenstern Gesundkost", street1 = "Heerstr. 22", size = BusinessSize.Enterprise},
                    new Customer{customerName = "Old World Delicatessen", street1 = "2743 Bering St.", size = BusinessSize.Enterprise}
                };
                _context.Customer.AddRange(customers);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
