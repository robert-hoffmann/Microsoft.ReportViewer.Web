using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace Bll
{
    /// <summary>
    /// Little wrapper class to seperate report creation from MVC controller
    /// </summary>
    public class Report
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public enum Type
        {
            WORD,
            EXCEL,
            PDF
        }

        #region ReturnValues
        public string MimeType { get; set; }
        public byte[] Content  { get; set; }
        public string FileExtension {
            get
            {
                string extension;
                switch (ReportType)
                {
                    case Type.EXCEL:
                        extension = "xls";
                        break;

                    case Type.WORD:
                        extension = "doc";
                        break;

                    default:
                        extension = "pdf";
                        break;
                }

                return extension;
            }
        }
        #endregion

        #region InternalValues
        private string Path               { get; set; }
        private string DataSetName        { get; set; }
        private IEnumerable DataSetSource { get; set; }
        private Type ReportType           { get; set; }
        #endregion

        public Report(string path, string dataSetName, IEnumerable dataSetSource, Report.Type reportType = Report.Type.PDF)
        {
            if (!System.IO.File.Exists(path))
            {
                throw  new FileNotFoundException();
            }

            Path          = path;
            DataSetName   = dataSetName;
            DataSetSource = dataSetSource;
            ReportType    = reportType;

            Render();
        }

        private void Render()
        {
            LocalReport lr = new LocalReport
            {
                ReportPath = Path
            };

            ReportDataSource reportDataSource = new ReportDataSource(DataSetName, DataSetSource);
            lr.DataSources.Add(reportDataSource);

            string deviceInfo = $@"<DeviceInfo>
                                      <OutputFormat>{ReportType}</OutputFormat>
                                      <PageWidth>8.5in</PageWidth>
                                      <PageHeight>11in</PageHeight>
                                      <MarginTop>0.5in</MarginTop>
                                      <MarginLeft>1in</MarginLeft>
                                      <MarginRight>1in</MarginRight>
                                      <MarginBottom>0.5in</MarginBottom>
                                   </DeviceInfo>";

            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;

            Content = lr.Render(
                                ReportType.ToString(),
                                deviceInfo,
                                out mimeType,
                                out encoding,
                                out fileNameExtension,
                                out streams,
                                out warnings);

            MimeType = mimeType;
        }
    }
}