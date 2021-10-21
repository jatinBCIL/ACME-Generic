using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;

/// <summary>
/// Purpose : Importing DLL references for printing document from webpage.
/// Created By : Chandrakant Shindkar.
/// Created On : 1st October, 2012.
/// Modified By : 
/// Modified On :
/// Comment :
/// </summary>
public class clsxlsExport
{
    public static void ConvertToxls(System.Data.DataTable objData, string strFileName)
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        dt = objData;
        string attachment = "attachment; filename=" + strFileName + ".xls";
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", attachment);
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        //string style = @"&lt;style> .text { mso-number-format:\@; } </style> ";
        //HttpContext.Current.Response.Write(style);
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            HttpContext.Current.Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }
        HttpContext.Current.Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                HttpContext.Current.Response.Write(tab + String.Format("=\"{0}\"",dr[i].ToString()));
                tab = "\t";
            }
            HttpContext.Current.Response.Write("\n");
        }
        HttpContext.Current.Response.End();
    }

    public static void ExportWord(GridView objGrid, string strFilename)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + strFilename + ".doc");
        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.ContentType = "application/vnd.ms-word ";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        clsxlsExport.ClearControls(objGrid);
        objGrid.HeaderStyle.BackColor = System.Drawing.Color.Blue;
        objGrid.HeaderStyle.ForeColor = System.Drawing.Color.White;
        objGrid.HeaderStyle.Font.Underline = false;
        objGrid.RenderControl(hw);
        HttpContext.Current.Response.Output.Write(sw.ToString());
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

    public static void ExportExcel(GridView objGrid, string strFilename)
    {
        try
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;

            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + strFilename + ".xls");
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            clsxlsExport.ClearControls(objGrid);
            
            //Change the Header Row back to white color
            //Apply style to Individual Cells
            //objGrid.HeaderRow.Cells[0].Style.Add("background-color", "Black");
            objGrid.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            objGrid.HeaderStyle.ForeColor = System.Drawing.Color.White;
            objGrid.HeaderStyle.Font.Underline = false;
           
            for (int i = 0; i < objGrid.Rows.Count; i++)
            {
                GridViewRow row = objGrid.Rows[i];

                //Change Color back to white
                //row.BackColor = System.Drawing.Color.White;

                //Apply text style to each Row
                row.Attributes.Add("class", "textmode");
            }
            objGrid.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style>.textmode{mso-number-format:\@;}</style>";
            //HttpContext.Current.Response.Write(style);
            HttpContext.Current.Response.Output.Write(sw.ToString().Normalize());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public static void ExportPDF(GridView objGrid, string strFilename)
    {
        objGrid.AllowPaging = false;
        objGrid.AllowSorting = false;
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + strFilename + ".pdf");
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        clsxlsExport.ClearControls(objGrid);
        objGrid.HeaderStyle.BackColor = System.Drawing.Color.Blue;
        objGrid.HeaderStyle.ForeColor = System.Drawing.Color.White;
        objGrid.HeaderStyle.Font.Underline = false;
        objGrid.RenderControl(hw);
        DataTable dt = new DataTable();
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 2f, 2f, 2f, 2f);
        //pdfDoc.SetPageSize(iTextSharp.text.Rectangle(2.1, 2.1));
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        objGrid.AllowPaging = true;
        objGrid.AllowSorting = true;
        HttpContext.Current.Response.Write(pdfDoc);
        HttpContext.Current.Response.End();
    }

    public static void ClearControls(Control control)
    {
        for (int i=control.Controls.Count -1; i>=0; i--)
        {
            ClearControls(control.Controls[i]);
        }
        if (!(control is TableCell))
        {
            if (control.GetType().GetProperty("SelectedItem") != null)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                try
                {
                    literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                }
                catch
                {
                }
                control.Parent.Controls.Remove(control);
            }
            else
                if (control.GetType().GetProperty("Text") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                    control.Parent.Controls.Remove(control);
                }
        }
        return;
    }

    public static void ExportCSV(GridView objGrid, string strFilename)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + strFilename + ".csv");
        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.ContentType = "application/text";

        StringBuilder sb = new StringBuilder();
        for (int k = 0; k < objGrid.Columns.Count; k++)
        {
            //add separator
            sb.Append(objGrid.Columns[k].HeaderText + ',');
        }
        //append new line
        sb.Append("\r\n");
        for (int i = 0; i < objGrid.Rows.Count; i++)
        {
            for (int k = 0; k < objGrid.Columns.Count; k++)
            {
                //add separator
                sb.Append(Convert.ToString(Convert.ToString(objGrid.Rows[i].Cells[k].Text).Replace(",", " ")).Replace("\n", " ") + ',');
            }
            //append new line
            sb.Append("\r\n");
        }
        HttpContext.Current.Response.Output.Write(sb.ToString());
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            //if (current.HasControls())
            //{
            //    GridViewExportUtil.PrepareControlForExport(current);
            //}
        }
    }

    public static string toHTML_Table(DataTable dt)
    {
        if (dt.Rows.Count == 0) return ""; // enter code here

        StringBuilder builder = new StringBuilder();
        builder.Append("<html>");
        builder.Append("<head>");
        builder.Append("<title>");
        builder.Append("Page-");
        builder.Append(Guid.NewGuid());
        builder.Append("</title>");
        builder.Append("</head>");
        builder.Append("<body style='width:800px'>");
        //builder.Append("<table style='width:800px'><tr><td style='width:50px;'><img ID='Img1' runat='server' src='~/App_Themes/Styles/Images/b1.jpg'/></td><td style='width:100%'></td><td style='width:50px; background-image: url('../App_Themes/Styles/Images/b2.jpg')'></td></tr></table>");
        builder.Append("<table style='width:800px' border='1px' cellpadding='5' cellspacing='0' ");
        builder.Append("style='border: solid 1px black; font-size: 12;'><col width='130'><col width='80'>");
        builder.Append("{ReportHeading}");
        builder.Append("<tr align='left' valign='top' height='35'>");
        int Columns = 0;
        foreach (DataColumn c in dt.Columns)
        {
            switch (c.ColumnName)
            {
                case "Sl. No.":
                    builder.Append("<td align='left' valign='top' height='35' width='50' bgcolor='#e0e0d1' style='word-wrap: normal;border: solid 1px black;font-family:Arial;font-size: 12;'><b>");
                    break;
                case "RANGE":
                    builder.Append("<td align='left' valign='top' height='35' width='200' bgcolor='#e0e0d1' style='word-wrap: normal;border: solid 1px black;font-family:Arial;font-size: 12;'><b>");
                    break;
                case "Critical Instrument (Yes/No)":
                    builder.Append("<td align='left' valign='top' height='35' width='150' bgcolor='#e0e0d1' style='word-wrap: normal;border: solid 1px black;font-family:Arial;font-size: 12;'><b>");
                    break;
                default:
                    builder.Append("<td align='left' valign='top' height='35' width='100' bgcolor='#e0e0d1' style='word-wrap: normal;border: solid 1px black;font-family:Arial;font-size: 12;'><b>");
                    break;
            }
            builder.Append(c.ColumnName);
            builder.Append("</b></td>");
            Columns += 1;
        }
        string strHeader = string.Empty;
        strHeader = "<tr align='left' valign='top'><td align='center' height='35' valign='center' colspan=" + Columns.ToString() + "><b>" + "<p style='text-align:center;font-family:Arial;font-size:16;'><u>CALIBRATION MASTER LIST OF MONITORING AND MEASURING EQUIPMENT (MME)</u></p>" + "</b></td></tr>";
        builder.Replace("{ReportHeading}", strHeader);

        builder.Append("</tr>");
        foreach (DataRow r in dt.Rows)
        {
            builder.Append("<tr align='left' valign='top'>");
            foreach (DataColumn c in dt.Columns)
            {
                builder.Append("<td align='left' valign='top' style='word-wrap: normal;font-family:Arial;font-size: 12'>");
                builder.Append(r[c.ColumnName]);
                builder.Append("</td>");
            }
            builder.Append("</tr>");
        }
        builder.Append("</table>");
        builder.Append("</body>");
        builder.Append("</html>");

        return builder.ToString();
    }
}
