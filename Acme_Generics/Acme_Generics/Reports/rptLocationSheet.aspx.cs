using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class Reports_rptLocSheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {

            rvLocSheet.SizeToReportContent = true;

            rvLocSheet.LocalReport.ReportPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ReportPath"].ToString() + "rptLoc.rdlc");

            rvLocSheet.LocalReport.DataSources.Clear();

            ReportDataSource _rsource = new ReportDataSource("DataSet2", (DataTable)Session["LocationDtl"]);

            ReportParameter[] rpParam = new ReportParameter[5];

            rpParam[0] = new ReportParameter { Name = "rpUser", Values = { clsStandards.current_User().ToString() } };
            rpParam[1] = new ReportParameter { Name = "rpDate", Values = { System.DateTime.Now.Date.ToString() } };
            rpParam[2] = new ReportParameter { Name = "rpHeading", Values = { Session["LocHeading"].ToString() } };
            rpParam[3] = new ReportParameter { Name = "rpBlock", Values = { Session["Block"].ToString() } };
            rpParam[4] = new ReportParameter { Name = "rpArea", Values = { Session["Area"].ToString() } };

            rvLocSheet.LocalReport.DataSources.Add(_rsource);
            rvLocSheet.LocalReport.SetParameters(rpParam);
            rvLocSheet.LocalReport.Refresh();

            loadReport();

        }
    }

    protected void loadReport()
    {
        Warning[] warnings;
        string[] streamids;
        string mimeType;
        string encoding;
        string extension;

        byte[] bytes = rvLocSheet.LocalReport.Render("PDF", null, out mimeType,
                       out encoding, out extension, out streamids, out warnings);

        FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ReportOutPath"].ToString() + "output.pdf"), FileMode.Create);
        fs.Write(bytes, 0, bytes.Length);
        fs.Close();

        //Open exsisting pdf
        Document document = new Document(PageSize.LETTER);
        PdfReader reader = new PdfReader(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ReportOutPath"].ToString() + "output.pdf"));
        //Getting a instance of new pdf wrtiter
        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
        HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ReportOutPath"].ToString() + "Print.pdf"), FileMode.Create));
        document.Open();
        PdfContentByte cb = writer.DirectContent;

        int i = 0;
        int p = 0;
        int n = reader.NumberOfPages;
        Rectangle psize = reader.GetPageSize(1);

        float width = psize.Width;
        float height = psize.Height;

        //Add Page to new document
        while (i < n)
        {
            document.NewPage();
            p++;
            i++;

            PdfImportedPage page1 = writer.GetImportedPage(reader, i);
            cb.AddTemplate(page1, 0, 0);
        }
        Response.ContentType = "APPLICATION/OCTET-STREAM";
        String Header = "Attachment; Filename=" + "LoctionChart" + ".pdf";
        Response.AppendHeader("Content-Disposition", Header);

        System.IO.FileInfo Dfile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ReportOutPath"].ToString() + "output.pdf"));
        Response.WriteFile(Dfile.FullName);

        HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
        HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
        HttpContext.Current.ApplicationInstance.CompleteRequest();
        document.Close();
    }
}