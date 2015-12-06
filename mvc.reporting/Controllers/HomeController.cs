using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace mvc.reporting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report(Bll.Report.Type reportType, bool download = false)
        {
            IList<Models.ReportModel> reportList = new List<Models.ReportModel>();

            reportList.Add(new Models.ReportModel("Robert" , 42));
            reportList.Add(new Models.ReportModel("Patrick", 53));
            reportList.Add(new Models.ReportModel("Malory" , 24));
            reportList.Add(new Models.ReportModel("David"  , 44));

            var report = new Bll.Report(Server.MapPath("~/Reports/Report.rdlc"), "ReportDataSet", reportList, reportType);

            if (download)
            {
                return File(report.Content, report.MimeType, $"ReportDataSet_{DateTime.Now.ToString("yyyy-MM-dd-HH'h'mm")}.{report.FileExtension}");
            }
            return File(report.Content, report.MimeType);
        }
    }
}