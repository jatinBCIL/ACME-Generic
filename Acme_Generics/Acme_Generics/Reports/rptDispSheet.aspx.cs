using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Configuration;

public partial class Reports_rptDispSheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {

            rvDispSheet.SizeToReportContent = true;

            rvDispSheet.LocalReport.ReportPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ReportPath"].ToString() + "rptDisp.rdlc");

            rvDispSheet.LocalReport.DataSources.Clear();

            ReportDataSource _rsource = new ReportDataSource("DataSet1",(DataTable)Session["DispDetails"]);

            ReportParameter[] rpParam = new ReportParameter[6];

            rpParam[0] = new ReportParameter { Name = "rpProdName", Values = { Session["ProductDesc"].ToString() } };
            rpParam[1] = new ReportParameter { Name = "rpBatchNo", Values = { Session["ProdBatch"].ToString() } };
            rpParam[2] = new ReportParameter { Name = "rpBatchSize", Values = { Session["BatchSize"].ToString() } };
            rpParam[3] = new ReportParameter { Name = "rpMFGDate", Values = { Session["MfgDate"].ToString() } };
            rpParam[4] = new ReportParameter { Name = "rpExpDate", Values = { Session["ExpDate"].ToString() } };
            rpParam[5] = new ReportParameter { Name = "rpProdCode", Values = { Session["ProdCode"].ToString() } };

            rvDispSheet.LocalReport.DataSources.Add(_rsource);
            //ReportViewer1.LocalReport.DataSources.Add(_rsource1);
            rvDispSheet.LocalReport.SetParameters(rpParam);

            rvDispSheet.LocalReport.Refresh();

        }
    }

    
}