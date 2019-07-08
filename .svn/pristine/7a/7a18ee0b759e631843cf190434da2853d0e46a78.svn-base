using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netcore.Data;

namespace netcore.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Dashboard")]
    public class DashboardController : Controller
    {

        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetPieData")]
        public IActionResult GetPieData()
        {
            var productTypes = Enum.GetValues(typeof(Models.Invent.ProductType));
            List<PieData> pieDatas = new List<PieData>();
            List<string> colors = new List<string>()
            {
                "#f56954", "#00a65a", "#f39c12", "#00c0ef", "#3c8dbc", "#d2d6de"
            };

            int i = 0;
            foreach (var item in productTypes)
            {
                int count = _context.Product.Where(x => x.productType.Equals(item)).Count();
                PieData pieData = new PieData();
                pieData.value = count;
                pieData.label = item.ToString();
                pieData.color = colors[i];
                pieDatas.Add(pieData);
                i++;
                if (i > colors.Count - 1) i = 0;
            }

            return Json(pieDatas);
        }

        [HttpGet("GetBarData")]
        public IActionResult GetBarData()
        {
            List<string> labels = new List<string>();
            DateTime from = DateTime.UtcNow.AddMonths(-5);
            DateTime to = DateTime.UtcNow.AddMonths(1);
            for (DateTime i = from.Date; i < to.Date; i = i.AddMonths(1))
            {
                labels.Add(i.ToString("MMMM-yy"));
            }

            BarDataItem po = new BarDataItem();
            po.label = "Purchase Order";
            po.fillColor = "rgba(210, 214, 222, 1)";
            po.strokeColor = "rgba(210, 214, 222, 1)";
            po.pointColor = "rgba(210, 214, 222, 1)";
            po.pointStrokeColor = "#c1c7d1";
            po.pointHighlightFill = "#fff";
            po.pointHighlightStroke = "rgba(220,220,220,1)";
            List<int> poCounts = new List<int>();
            for (DateTime i = from.Date; i < to.Date; i = i.AddMonths(1))
            {
                int count = _context.PurchaseOrder.Where(x => x.poDate.Year.Equals(i.Year) && x.poDate.Month.Equals(i.Month)).Count();
                poCounts.Add(count);
            }
            po.data = poCounts;


            BarDataItem so = new BarDataItem();
            so.label = "Sales Order";
            so.fillColor = "rgba(60,141,188,0.9)";
            so.strokeColor = "rgba(60,141,188,0.8)";
            so.pointColor = "#3b8bba";
            so.pointStrokeColor = "rgba(60,141,188,1)";
            so.pointHighlightFill = "#fff";
            so.pointHighlightStroke = "rgba(60,141,188,1)";
            List<int> soCounts = new List<int>();
            for (DateTime i = from.Date; i < to.Date; i = i.AddMonths(1))
            {
                int count = _context.SalesOrder.Where(x => x.soDate.Year.Equals(i.Year) && x.soDate.Month.Equals(i.Month)).Count();
                soCounts.Add(count);
            }
            so.data = soCounts;

            List<BarDataItem> datasets = new List<BarDataItem>();

            datasets.Add(po);
            datasets.Add(so);

            BarData barData = new BarData();
            barData.labels = labels;
            barData.datasets = datasets;

            return Json(barData);
        }
    }

    public class PieData
    {
        public int value { get; set; }
        public string color { get; set; }
        public string highlight { get; set; }
        public string label { get; set; }
    }

    public class BarData
    {
        public List<string> labels { get; set; }
        public List<BarDataItem> datasets { get; set; }
    }

    public class BarDataItem
    {
        public string label { get; set; }
        public string fillColor { get; set; }
        public string strokeColor { get; set; }
        public string pointColor { get; set; }
        public string pointStrokeColor { get; set; }
        public string pointHighlightFill { get; set; }
        public string pointHighlightStroke { get; set; }
        public List<int> data { get; set; } = new List<int>();
    }
}