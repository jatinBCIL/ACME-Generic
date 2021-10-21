using System;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Net;
using System.Net.Sockets;
using DataLayer;

[StructLayout(LayoutKind.Sequential)]

public struct DOCINFO
{
    [MarshalAs(UnmanagedType.LPWStr)]

    public string pDocName;
    [MarshalAs(UnmanagedType.LPWStr)]

    public string pOutputFile;
    [MarshalAs(UnmanagedType.LPWStr)]

    public string pDataType;
}
/// <summary>
/// Purpose : Importing DLL references for printing document from webpage.
/// Created By : Chandrakant Shindkar.
/// Created On : 17 August 2012.
/// Modified By : 
/// Modified On :
/// Comment :
/// </summary>
public class PrintDirect
{
    [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]

    public static extern long OpenPrinter(string pPrinterName, ref IntPtr phPrinter, int pDefault);
    [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]

    public static extern long StartDocPrinter(IntPtr hPrinter, int Level, ref DOCINFO pDocInfo);
    [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]

    public static extern long StartPagePrinter(IntPtr hPrinter);
    [DllImport("winspool.drv", CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]

    public static extern long WritePrinter(IntPtr hPrinter, string data, int buf, ref int pcWritten);
    [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]

    public static extern long EndPagePrinter(IntPtr hPrinter);
    [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]

    public static extern long EndDocPrinter(IntPtr hPrinter);
    [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]

    public static extern long ClosePrinter(IntPtr hPrinter);

    /// <summary>
    /// Purpose : Function is created to send data on selected printer.
    /// </summary>
    /// <param name="printerName">Printer name reference.</param>
    /// <param name="strLevel_Type">Label Type reference.</param>
    /// 


    //public static Boolean Print_DispenseRawLabel(string printerName, string strBarcode, string strMatCode, string strMatDescription,
    //    string strMatBatch, string strGrade, string strNxtInspectionDate, string strSLED,
    //    string strProcessOrder, string strProdCode, string strProdBatch, string strProdDesc,
    //    string strStageDesc, string strProcessDesc, decimal dGrosswt, decimal dNetwt, decimal dTarewt,
    //    string strIssuedBy, string strCheckedBy, string strIssueDate, string strCheckDate, string strLot,
    //    string strUom, string strPlantDesc)
    //{
    //    IntPtr lhPrinter = new IntPtr();
    //    DOCINFO Doc = new DOCINFO();
    //    int pcWritten = 0;
    //    string strFileData;
    //    Doc.pDocName = strMatCode;
    //    Doc.pDataType = "RAW";
    //    try
    //    {
    //        PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
    //        PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
    //        PrintDirect.StartPagePrinter(lhPrinter);
    //        strFileData = ReadPrn("CIPLARAWDISP.prn");
    //        strFileData = strFileData.Replace("{Plant}", strPlantDesc);
    //        strFileData = strFileData.Replace("{ITEM}", strMatCode.TrimStart('0'));
    //        strFileData = strFileData.Replace("{LOT}", strLot);
    //        if (clsStandards.filter(strMatDescription).Length <= 35)
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription.Trim()));
    //            strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strMatDescription).Length <= 85)
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 17).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(17, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 17)).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strMatDescription).Length <= 145)
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 35).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(35, 40).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(85, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 85)).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strMatDescription).Length <= 205)
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 35).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(35, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(85, 40).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strMatDescription).Substring(145, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 145)).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 35).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(35, 40).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(85, 40).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strMatDescription).Substring(145, 40).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC4}", clsStandards.filter(strMatDescription).Substring(205, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 205)).Trim());
    //        }

    //        strFileData = strFileData.Replace("{SAPBATCH}", strMatBatch.Trim());
    //        strFileData = strFileData.Replace("{GROSS}", Convert.ToString(dGrosswt) + " " + strUom);
    //        strFileData = strFileData.Replace("{TARE}", Convert.ToString(dTarewt) + " " + strUom);
    //        strFileData = strFileData.Replace("{NET}", Convert.ToString(dNetwt) + " " + strUom);

    //        strFileData = strFileData.Replace("{BARCODE}", strBarcode.Trim());

    //        strFileData = strFileData.Replace("{BATCH}", strProdBatch.Trim());
    //        strFileData = strFileData.Replace("{NXTINSPDATE}", strNxtInspectionDate.Trim());
    //        strFileData = strFileData.Replace("{GRADE}", strGrade.Trim());
    //        strFileData = strFileData.Replace("{SLED}", strSLED.Trim());
    //        strFileData = strFileData.Replace("{PONUM}", strProcessOrder.Trim().TrimStart('0'));
    //        strFileData = strFileData.Replace("{ISSUEPROD}", strProdCode.Trim().TrimStart('0'));
    //        strFileData = strFileData.Replace("{PROCDESC}", strProcessDesc.Trim());
    //        strFileData = strFileData.Replace("{STGDESC}", strStageDesc.Trim());

    //        if (clsStandards.filter(strProdDesc).Length <= 35)
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc.Trim()));
    //            strFileData = strFileData.Replace("{PRODESC1}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC2}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strProdDesc).Length <= 85)
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 35).Trim());
    //            strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(35, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 35)).Trim());
    //            strFileData = strFileData.Replace("{PRODESC2}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strProdDesc).Length <= 145)
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 35).Trim());
    //            strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(35, 40).Trim());
    //            strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(85, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 85)).Trim());
    //            strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strProdDesc).Length <= 205)
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 35).Trim());
    //            strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(35, 40).Trim());
    //            strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(85, 49).Trim());
    //            strFileData = strFileData.Replace("{PRODESC3}", clsStandards.filter(strProdDesc).Substring(145, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 145)).Trim());
    //            strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 35).Trim());
    //            strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(35, 40).Trim());
    //            strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(85, 40).Trim());
    //            strFileData = strFileData.Replace("{PRODESC3}", clsStandards.filter(strProdDesc).Substring(85, 40).Trim());
    //            strFileData = strFileData.Replace("{PRODESC4}", clsStandards.filter(strProdDesc).Substring(205, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 205)).Trim());
    //        }


    //        PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ApplicationException(ex.Message);
    //    }
    //    finally
    //    {
    //        PrintDirect.EndPagePrinter(lhPrinter);
    //        PrintDirect.EndDocPrinter(lhPrinter);
    //        PrintDirect.ClosePrinter(lhPrinter);
    //    }
    //}

    //public static Boolean Print_DispenseRawLabel(string printerName,
    //  string strBarcode,
    //  string strMatCode,
    //  string strMatDescription, string strMatBatch, string strMfgDate, string strExpiryDate, string strProcessOrder,
    //  string strProdCode, string strProdBatch, string strProdDesc, decimal dGrosswt, decimal dNetwt, decimal dTarewt, string strIssuedBy, string strIssueDate, string strUom, string strPlantName, string strBatchSize, string strARNo, string strContainerNo)
    //{
    //    IntPtr lhPrinter = new IntPtr();
    //    DOCINFO Doc = new DOCINFO();
    //    int pcWritten = 0;
    //    string strFileData;
    //    Doc.pDocName = strMatCode;
    //    Doc.pDataType = "RAW";
    //    try
    //    {


    //        PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
    //        PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
    //        PrintDirect.StartPagePrinter(lhPrinter);
    //        strFileData = ReadPrn("Dispensing.prn");

    //        //strFileData = strFileData.Replace("{Plant}", strPlantName);
    //        strFileData = strFileData.Replace("{MaterialCode}", strMatCode);
    //        strFileData = strFileData.Replace("{MaterialName}", strMatDescription);
    //        strFileData = strFileData.Replace("{ProductName}", strProdDesc);
    //        strFileData = strFileData.Replace("{BatchNo}", strMatBatch);
    //        strFileData = strFileData.Replace("{BSize}", strBatchSize);
    //        strFileData = strFileData.Replace("{MfgDate}", strMfgDate);
    //        strFileData = strFileData.Replace("{ExpDate}", strExpiryDate);
    //        strFileData = strFileData.Replace("{ARNo}", strARNo);
    //        strFileData = strFileData.Replace("{ContNo}", strContainerNo);

    //        //if (clsStandards.filter(strMatDescription).Length <= 25)
    //        //{
    //        //    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription.Trim()));
    //        //    strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
    //        //    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
    //        //    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
    //        //    strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        //}
    //        //else if (clsStandards.filter(strMatDescription).Length <= 75)
    //        //{
    //        //    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 25).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(25, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 25)).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
    //        //    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
    //        //    strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        //}
    //        //else if (clsStandards.filter(strMatDescription).Length <= 125)
    //        //{
    //        //    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 25).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(25, 50).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(75, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 75)).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
    //        //    strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        //}
    //        //else if (clsStandards.filter(strMatDescription).Length <= 175)
    //        //{
    //        //    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 25).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(25, 50).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(75, 50).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strMatDescription).Substring(125, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 125)).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        //}
    //        //else
    //        //{
    //        //    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 25).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(25, 50).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(75, 50).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strMatDescription).Substring(125, 50).Trim());
    //        //    strFileData = strFileData.Replace("{ITEMDESC4}", clsStandards.filter(strMatDescription).Substring(175, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 175)).Trim());
    //        //}
    //        strFileData = strFileData.Replace("{GrossWt}", Convert.ToString(dGrosswt) + " " + strUom);
    //        strFileData = strFileData.Replace("{TareWt}", Convert.ToString(dTarewt) + " " + strUom);
    //        strFileData = strFileData.Replace("{NetWt}", Convert.ToString(dNetwt) + " " + strUom);

    //        strFileData = strFileData.Replace("{BARCODE}", strBarcode.Trim());

    //        PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ApplicationException(ex.Message);
    //    }
    //    finally
    //    {
    //        PrintDirect.EndPagePrinter(lhPrinter);
    //        PrintDirect.EndDocPrinter(lhPrinter);
    //        PrintDirect.ClosePrinter(lhPrinter);
    //    }
    //}


    public static Boolean Print_DispenseRawLabel(string printerName, string strBarcode, string strMatCode, string strMatDescription,
                                                 string strMatBatch, string strMfgDate, string strExpiryDate, string strProcessOrder,
                                                 string strProdCode, string strProdBatch, string strProdDesc, decimal dGrosswt, decimal dNetwt,
                                                 decimal dTarewt, string strIssuedBy, string strIssueDate, string strUom, string strPlantName,
                                                 string strBatchSize, string strARNo, string strContainerNo, string strLotNo,string strip, string port,string strPrintFlag)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        SqlDataLayer objData = new SqlDataLayer();
        int pcWritten = 0;
        string strFileData;
        string strFormatNo = "";
        string strPrnFile = "";
        Doc.pDocName = strMatCode;
        Doc.pDataType = "RAW";
        try
        {


            PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
            PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
            PrintDirect.StartPagePrinter(lhPrinter);

            if (strPrintFlag == "1")
            {
                strFileData = ReadPrn("Dispensing.prn");
                strPrnFile = "Dispensing";
            }
            else if (strPrintFlag == "2")
            {
                strFileData = ReadPrn("Dispensing-2.prn");
                strPrnFile = "Dispensing-2";
            }
            else
            {
                strFileData = ReadPrn("Dispensing-1.prn");
                strPrnFile = "Dispensing-1";
            }

            if (strARNo.Substring(0, 1).Trim() == "H" || strARNo.Substring(0, 2).Trim() == "FH")
            {
                strFormatNo = objData.ExecuteScalarString(objData.strLocal, "SELECT FORMAT_NO FROM [TBL_PRINT_FORMAT] WHERE BLOCK = 'HB' AND PRN_FILE_NAME = '" + strPrnFile + "'");
            }
            else //if (strARNo.Substring(0, 1).Trim() == "G")
            {
                strFormatNo = objData.ExecuteScalarString(objData.strLocal, "SELECT FORMAT_NO FROM [TBL_PRINT_FORMAT] WHERE BLOCK = 'GB' AND PRN_FILE_NAME = '" + strPrnFile + "'");
            } 

            //strFileData = strFileData.Replace("{Plant}", strPlantName);
            strFileData = strFileData.Replace("{MaterialCode}", strMatCode);
            strFileData = strFileData.Replace("{MaterialName}", strMatDescription);
            strFileData = strFileData.Replace("{ProductName}", strProdDesc);
            strFileData = strFileData.Replace("{BatchNo}", strProdBatch);
            if (strBatchSize == string.Empty)
            {
                strFileData = strFileData.Replace("{BSize}", " ");
               
            }
            else
            {
                strFileData = strFileData.Replace("{BSize}", double.Parse(strBatchSize).ToString());
            }
            strFileData = strFileData.Replace("{MfgDate}", strMfgDate);
            strFileData = strFileData.Replace("{ExpDate}", strExpiryDate);
            strFileData = strFileData.Replace("{ARNo}", strARNo);
            strFileData = strFileData.Replace("{ContNo}", strContainerNo);
            if (strLotNo == " ")
            {
                strFileData = strFileData.Replace("{LotNo}", strLotNo);
            }
            else
            {
                strFileData = strFileData.Replace("{LotNo}", strLotNo);
 
            }
            if (dGrosswt == 0)
            {
                strFileData = strFileData.Replace("{GrossWt}", "NA");
            }
            else
            {
                strFileData = strFileData.Replace("{GrossWt}", Convert.ToString(dGrosswt) + " " + strUom);
 
            }
            if (dTarewt == 0)
            {
                strFileData = strFileData.Replace("{TareWt}", "NA");
            }
            else
            {
                strFileData = strFileData.Replace("{TareWt}", Convert.ToString(dTarewt) + " " + strUom);
            }
           
            strFileData = strFileData.Replace("{NetWt}", Convert.ToString(dNetwt.ToString()) + " " + strUom);
            strFileData = strFileData.Replace("{BARCODE}", strBarcode.Trim());
            strFileData = strFileData.Replace("{FORMATNO}", strFormatNo.Trim());

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.NoDelay = true;
            IPAddress ip = IPAddress.Parse(strip);
            IPEndPoint ipep = new IPEndPoint(ip, int.Parse(port));
            clientSocket.Connect(ipep);

            byte[] fileBytes = Encoding.ASCII.GetBytes(strFileData);

            clientSocket.Send(fileBytes);
            clientSocket.Close();
            //PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }

    public static Boolean Print_InProcContGrossAPILabel(string printerName, DataTable dt, string strPrintBy, string strPrintOn)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = "API Container Gross Weight Label";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);
                strFileData = ReadPrn("INPROCWIW.prn");
                strFileData = strFileData.Replace("{Plant}", dt.Rows[i]["PlantCode"].ToString());
                strFileData = strFileData.Replace("{Stage}", dt.Rows[i]["Opt_Desc"].ToString());
                strFileData = strFileData.Replace("{NxtStage}", dt.Rows[i]["Nxt_Opt_Desc"].ToString());
                strFileData = strFileData.Replace("{MATCD}", dt.Rows[i]["ProdCode"].ToString());
                strFileData = strFileData.Replace("{BATCHNO}", dt.Rows[i]["ProdBatch"].ToString());
                strFileData = strFileData.Replace("{CONTNO}", dt.Rows[i]["Cont_No"].ToString());
                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["BarcodeNo"].ToString());
                strFileData = strFileData.Replace("{PO}", dt.Rows[i]["ProcessOrderNo"].ToString());
                strFileData = strFileData.Replace("{PrintBy}", strPrintBy);
                strFileData = strFileData.Replace("{PrintDT}", strPrintOn);
                strFileData = strFileData.Replace("{LotNo}", dt.Rows[i]["Lot_No"].ToString());
                strFileData = strFileData.Replace("{GRWT}", dt.Rows[i]["GrossWt"].ToString());
                strFileData = strFileData.Replace("{NETWT}", dt.Rows[i]["NetWt"].ToString());
                strFileData = strFileData.Replace("{TAREWT}", dt.Rows[i]["TareWt"].ToString());

                if (clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Length <= 33)
                {
                    strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()));
                    strFileData = strFileData.Replace("{MATNAME1}", string.Empty);
                    strFileData = strFileData.Replace("{MATNAME2}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Length <= 82)
                {
                    strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Substring(0, 33).Trim());
                    strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Substring(33, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Length - 33)).Trim());
                    strFileData = strFileData.Replace("{MATNAME2}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Length <= 131)
                {
                    strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Substring(0, 33).Trim());
                    strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Substring(33, 49).Trim());
                    strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Substring(82, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Length - 82)).Trim());
                }


                PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);

            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }


    public static Boolean Print_DispenseRawLabel(string printerName, string strBarcode, string strMatCode, string strMatDescription, string strMatBatch, string strGrade, string strNxtInspectionDate, string strSLED, string strProcessOrder, string strProdCode, string strProdBatch, string strProdDesc, string strStageDesc, string strProcessDesc, decimal dGrosswt, decimal dNetwt, decimal dTarewt, string strIssuedBy, string strCheckedBy, string strIssueDate, string strCheckDate, string strLot, string strUom, string strPlantName)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = strMatCode;
        Doc.pDataType = "RAW";
        try
        {
            if (strProcessDesc == "")
            {
                strProcessDesc = " NA";
            }

            PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
            PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
            PrintDirect.StartPagePrinter(lhPrinter);
            strFileData = ReadPrn("CIPLARAWDISP.prn");

            strFileData = strFileData.Replace("{Plant}", strPlantName);
            strFileData = strFileData.Replace("{ITEM}", strMatCode);
            strFileData = strFileData.Replace("{LOT}", strLot);

            if (clsStandards.filter(strMatDescription).Length <= 25)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription.Trim()));
                strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
            }
            else if (clsStandards.filter(strMatDescription).Length <= 75)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 25).Trim());
                strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(25, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 25)).Trim());
                strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
            }
            else if (clsStandards.filter(strMatDescription).Length <= 125)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 25).Trim());
                strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(25, 50).Trim());
                strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(75, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 75)).Trim());
                strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
            }
            else if (clsStandards.filter(strMatDescription).Length <= 175)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 25).Trim());
                strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(25, 50).Trim());
                strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(75, 50).Trim());
                strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strMatDescription).Substring(125, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 125)).Trim());
                strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
            }
            else
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 25).Trim());
                strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(25, 50).Trim());
                strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(75, 50).Trim());
                strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strMatDescription).Substring(125, 50).Trim());
                strFileData = strFileData.Replace("{ITEMDESC4}", clsStandards.filter(strMatDescription).Substring(175, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 175)).Trim());
            }

            strFileData = strFileData.Replace("{SAPBATCH}", strMatBatch.Trim());
            strFileData = strFileData.Replace("{GROSS}", Convert.ToString(dGrosswt) + " " + strUom);
            strFileData = strFileData.Replace("{TARE}", Convert.ToString(dTarewt) + " " + strUom);
            strFileData = strFileData.Replace("{NET}", Convert.ToString(dNetwt) + " " + strUom);

            strFileData = strFileData.Replace("{BARCODE}", strBarcode.Trim());

            strFileData = strFileData.Replace("{BATCH}", strProdBatch.Trim());
            if (strNxtInspectionDate.Trim() == "01/01/1900")
            {
                strFileData = strFileData.Replace("{NXTINSPDATE}", "NA");
            }
            else
            {
                strFileData = strFileData.Replace("{NXTINSPDATE}", strNxtInspectionDate.Trim());
            }
            strFileData = strFileData.Replace("{GRADE}", strGrade.Trim());
            if (strSLED.Trim() == "01/01/1900")
            {
                strFileData = strFileData.Replace("{SLED}", "NA");
            }
            else
            {
                strFileData = strFileData.Replace("{SLED}", strSLED.Trim());
            }

            strFileData = strFileData.Replace("{PONUM}", strProcessOrder.Trim());
            strFileData = strFileData.Replace("{ISSUEPROD}", strProdCode.Trim());

            strFileData = strFileData.Replace("{PROCDESC}", strProcessDesc.Trim());

            if (strStageDesc.Trim() != "")
            {
                strFileData = strFileData.Replace("{STGDESC}", "Dispensing of " + strStageDesc.Trim());
            }
            else
            {
                strFileData = strFileData.Replace("{STGDESC}", "NA");
            }

            if (clsStandards.filter(strProdDesc).Length <= 30)
            {
                strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc.Trim()));
                strFileData = strFileData.Replace("{PRODESC1}", string.Empty);
                strFileData = strFileData.Replace("{PRODESC2}", string.Empty);
                strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
                strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
            }
            else if (clsStandards.filter(strProdDesc).Length <= 75)
            {
                strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 30).Trim());
                strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(30, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 30)).Trim());
                strFileData = strFileData.Replace("{PRODESC2}", string.Empty);
                strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
                strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
            }
            else if (clsStandards.filter(strProdDesc).Length <= 120)
            {
                strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 30).Trim());
                strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(30, 45).Trim());
                strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(75, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 75)).Trim());
                strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
                strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
            }
            else if (clsStandards.filter(strProdDesc).Length <= 165)
            {
                strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 30).Trim());
                strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(30, 45).Trim());
                strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(75, 45).Trim());
                strFileData = strFileData.Replace("{PRODESC3}", clsStandards.filter(strProdDesc).Substring(120, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 120)).Trim());
                strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
            }
            else
            {
                strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 30).Trim());
                strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(30, 45).Trim());
                strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(75, 45).Trim());
                strFileData = strFileData.Replace("{PRODESC3}", clsStandards.filter(strProdDesc).Substring(120, 45).Trim());
                strFileData = strFileData.Replace("{PRODESC4}", clsStandards.filter(strProdDesc).Substring(165, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 165)).Trim());
            }


            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }

    public static Boolean Print_DispensePackingLabel(string printerName, string strBarcode, string strMatCode, string strMatDescription, string strMatBatch, string strGrade, string strNxtInspectionDate, string strSLED, string strProcessOrder, string strProdCode, string strProdBatch, string strProdDesc, string strStageDesc, string strProcessDesc, decimal dQty, string strIssuedBy, string strCheckedBy, string strIssueDate, string strCheckDate, string strUom, string strPlantName, string strLot)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = strMatCode;
        Doc.pDataType = "RAW";
        try
        {
            if (strProcessDesc == "")
            {
                strProcessDesc = " NA";
            }

            PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
            PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
            PrintDirect.StartPagePrinter(lhPrinter);
            strFileData = ReadPrn("CIPLAPACKDISP.prn");

            strFileData = strFileData.Replace("{Plant}", strPlantName);
            strFileData = strFileData.Replace("{ITEM}", strMatCode);
            strFileData = strFileData.Replace("{LOT}", strLot);

            if (clsStandards.filter(strMatDescription).Length <= 25)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription.Trim()));
                strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
            }
            else if (clsStandards.filter(strMatDescription).Length <= 75)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 25).Trim());
                strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(25, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 25)).Trim());
                strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
            }
            else if (clsStandards.filter(strMatDescription).Length <= 125)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 25).Trim());
                strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(25, 50).Trim());
                strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(75, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 75)).Trim());
                strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
            }
            else if (clsStandards.filter(strMatDescription).Length <= 175)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 25).Trim());
                strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(25, 50).Trim());
                strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(75, 50).Trim());
                strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strMatDescription).Substring(125, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 125)).Trim());
                strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
            }
            else
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 25).Trim());
                strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(25, 50).Trim());
                strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(75, 50).Trim());
                strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strMatDescription).Substring(125, 50).Trim());
                strFileData = strFileData.Replace("{ITEMDESC4}", clsStandards.filter(strMatDescription).Substring(175, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 175)).Trim());
            }

            strFileData = strFileData.Replace("{SAPBATCH}", strMatBatch.Trim());
            strFileData = strFileData.Replace("{QTYUOM}", Convert.ToString(dQty) + " " + strUom.Trim());


            strFileData = strFileData.Replace("{BARCODE}", strBarcode.Trim());

            strFileData = strFileData.Replace("{BATCH}", strProdBatch.Trim());
            if (strNxtInspectionDate.Trim() == "01/01/1900")
            {
                strFileData = strFileData.Replace("{NXTINSPDATE}", "NA");
            }
            else
            {
                strFileData = strFileData.Replace("{NXTINSPDATE}", strNxtInspectionDate.Trim());
            }
            strFileData = strFileData.Replace("{GRADE}", strGrade.Trim());
            if (strSLED.Trim() == "01/01/1900")
            {
                strFileData = strFileData.Replace("{SLED}", "NA");
            }
            else
            {
                strFileData = strFileData.Replace("{SLED}", strSLED.Trim());
            }

            strFileData = strFileData.Replace("{PONUM}", strProcessOrder.Trim());
            strFileData = strFileData.Replace("{ISSUEPROD}", strProdCode.Trim());

            strFileData = strFileData.Replace("{PROCDESC}", strProcessDesc.Trim());

            if (strStageDesc.Trim() != "")
            {
                strFileData = strFileData.Replace("{STGDESC}", "Dispensing of " + strStageDesc.Trim());
            }
            else
            {
                strFileData = strFileData.Replace("{STGDESC}", "NA");
            }


            if (clsStandards.filter(strProdDesc).Length <= 30)
            {
                strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc.Trim()));
                strFileData = strFileData.Replace("{PRODESC1}", string.Empty);
                strFileData = strFileData.Replace("{PRODESC2}", string.Empty);
                strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
                strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
            }
            else if (clsStandards.filter(strProdDesc).Length <= 75)
            {
                strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 30).Trim());
                strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(30, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 30)).Trim());
                strFileData = strFileData.Replace("{PRODESC2}", string.Empty);
                strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
                strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
            }
            else if (clsStandards.filter(strProdDesc).Length <= 120)
            {
                strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 30).Trim());
                strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(30, 45).Trim());
                strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(75, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 75)).Trim());
                strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
                strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
            }
            else if (clsStandards.filter(strProdDesc).Length <= 165)
            {
                strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 30).Trim());
                strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(30, 45).Trim());
                strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(75, 45).Trim());
                strFileData = strFileData.Replace("{PRODESC3}", clsStandards.filter(strProdDesc).Substring(120, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 120)).Trim());
                strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
            }
            else
            {
                strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 30).Trim());
                strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(30, 45).Trim());
                strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(75, 45).Trim());
                strFileData = strFileData.Replace("{PRODESC3}", clsStandards.filter(strProdDesc).Substring(120, 45).Trim());
                strFileData = strFileData.Replace("{PRODESC4}", clsStandards.filter(strProdDesc).Substring(165, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 165)).Trim());
            }


            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }


    //public static Boolean Print_InProcessBarcode(string strLabelType, string strPrinterName, string strBarcode, string strPlantCode, string strPoNumber,
    //      string strMatCode, string strMatDesc, string strBatchNo, string strCurrentOp, string strNextOp, string strLotNo,
    //      string strWeighId, string strGrossWt, string strTareWt, string strNetWt, string strQty, string strUom, string strPrinterCode, string strUserId, string strPartNo, string strPrintCount, string strTotalCount, string strContainerID)
    //{

    //    IntPtr lhPrinter = new IntPtr();
    //    DOCINFO Doc = new DOCINFO();
    //    int pcWritten = 0;
    //    string strFileData;
    //    Doc.pDocName = strMatCode;
    //    Doc.pDataType = "RAW";
    //    strFileData = ReadPrn("INPROCESSPRINTING.prn");
    //    try
    //    {

    //        PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
    //        PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
    //        PrintDirect.StartPagePrinter(lhPrinter);
    //        if (strLabelType == "INPROC")
    //        {
    //            //laste stage BFG

    //            strFileData = strFileData.Replace("{HEADING}", "IN PROCESS");
    //        }
    //        else if (strLabelType == "MAT")
    //        {
    //            //material barcode
    //            strFileData = strFileData.Replace("{HEADING}", "MATERIAL");
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{HEADING}", "BULK FINISHED GOODS");
    //            //inprocess
    //        }


    //        strFileData = strFileData.Replace("{PLANT}", strPlantCode);
    //        strFileData = strFileData.Replace("{STAGE}", strCurrentOp);
    //        strFileData = strFileData.Replace("{NEXTSTAGE}", strNextOp.Trim());
    //        strFileData = strFileData.Replace("{MATCD}", strMatCode.Trim());
    //        strFileData = strFileData.Replace("{BATCHNO}", strBatchNo.Trim());
    //        strFileData = strFileData.Replace("{GRWT}", strGrossWt.Trim());
    //        strFileData = strFileData.Replace("{NETWT}", strNetWt.Trim());
    //        strFileData = strFileData.Replace("{TAREWT}", strTareWt.Trim());
    //        strFileData = strFileData.Replace("{BATCHNO}", strBatchNo.Trim());
    //        strFileData = strFileData.Replace("{CONTCODE}", strContainerID.Trim());
    //        strFileData = strFileData.Replace("{CONTNO}", strPrintCount);
    //        strFileData = strFileData.Replace("{TOTCONT}", strTotalCount);
    //        strFileData = strFileData.Replace("{BARCODE}", strBarcode);
    //        if (clsStandards.filter(strMatDesc.Trim()).Length <= 33)
    //        {
    //            strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(strMatDesc.Trim()));
    //            strFileData = strFileData.Replace("{MATNAME1}", string.Empty);
    //            strFileData = strFileData.Replace("{MATNAME1}", string.Empty);

    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{MATNAME1}", strMatDesc);
    //        }
    //        strFileData = strFileData.Replace("{PO}", strPoNumber);
    //        strFileData = strFileData.Replace("{PART}", strPartNo);
    //        strFileData = strFileData.Replace("{PRINTBY}", strUserId);
    //        strFileData = strFileData.Replace("{PRINTDT}", clsStandards.filter(System.DateTime.Now.ToShortDateString()));

    //        PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
    //        return true;




    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ApplicationException(ex.Message);
    //    }
    //    finally
    //    {
    //        PrintDirect.EndPagePrinter(lhPrinter);
    //        PrintDirect.EndDocPrinter(lhPrinter);
    //        PrintDirect.ClosePrinter(lhPrinter);
    //    }
    //}

    public static Boolean Print_EmrmBarcode_po(string strPrinterName, string strUserName, string strPrintedDate, DataTable dt)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = "Emrm IN Process Label Printing";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;


                PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                strFileData = ReadPrn("EMRM.prn");
                strFileData = strFileData.Replace("{ITEM}", dt.Rows[0]["ItemCode"].ToString().TrimStart('0'));

                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[0]["BarcodeNo"].ToString());
                strFileData = strFileData.Replace("{PLANT}", dt.Rows[i]["PLANTCODE"].ToString());
                strFileData = strFileData.Replace("{GRADE}", dt.Rows[i]["GRADE"].ToString());
                strFileData = strFileData.Replace("{BATCHNO}", dt.Rows[i]["BATCHNO"].ToString());


                strFileData = strFileData.Replace("{PO}", dt.Rows[0]["ProcessOrderNo"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{PRODUCTCODE}", dt.Rows[i]["ProdCode"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{BATCH}", dt.Rows[i]["PRODUCTBATCH"].ToString());
                strFileData = strFileData.Replace("{GRWT}", dt.Rows[i]["GROSSWT"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());
                strFileData = strFileData.Replace("{NETWT}", dt.Rows[i]["NetWt"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());
                strFileData = strFileData.Replace("{TRWT}", dt.Rows[i]["TAREWT"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());


                strFileData = strFileData.Replace("{PRINTBY}", strUserName + "/" + strPrintedDate);
                //strFileData = strFileData.Replace("{GRADE}", strUserName);





                if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 50)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()));
                    strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 112)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 50)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 174)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 236)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 174)).Trim());
                }

                if (clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length <= 50)
                {
                    strFileData = strFileData.Replace("{PRODUCTDESC}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()));
                    strFileData = strFileData.Replace("{PRODUCTDESC1}", string.Empty);
                    strFileData = strFileData.Replace("{PRODUCTDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{PRODUCTDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length <= 112)
                {
                    strFileData = strFileData.Replace("{PRODUCTDESC}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC1}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length - 50)).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{PRODUCTDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length <= 174)
                {
                    strFileData = strFileData.Replace("{PRODUCTDESC}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC1}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC2}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC3}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length <= 236)
                {
                    strFileData = strFileData.Replace("{PRODUCTDESC}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC1}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC2}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(112, 62).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC3}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length - 174)).Trim());
                }


                PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }


    }

    public static Boolean Print_EMRMResLabel(string printerName, DataTable dt, string strPrintBy, string strPrintOn)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = "EMRM Against Reservation";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;


                PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                strFileData = ReadPrn("emrmres.prn");
                strFileData = strFileData.Replace("{PLANT}", dt.Rows[i]["PLANTCODE"].ToString());
                strFileData = strFileData.Replace("{ITEM}", dt.Rows[i]["ItemCode"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{RESNO}", dt.Rows[i]["ProcessOrderNo"].ToString());
                strFileData = strFileData.Replace("{BATCHNO}", dt.Rows[i]["BATCHNO"].ToString());
                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["BarcodeNo"].ToString());
                strFileData = strFileData.Replace("{GRADE}", dt.Rows[i]["GRADE"].ToString());
                strFileData = strFileData.Replace("{PRINTBY}", strPrintBy + "/" + strPrintOn);
                //strFileData = strFileData.Replace("{RAISEDBY}", strPrintBy + "/" + strPrintOn);
                //strFileData = strFileData.Replace("{CHECKEDBY}", strPrintBy + "/" + strPrintOn);

                strFileData = strFileData.Replace("{GRWT}", dt.Rows[i]["GrossWt"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());
                strFileData = strFileData.Replace("{NETWT}", dt.Rows[i]["NetWt"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());
                strFileData = strFileData.Replace("{TRWT}", dt.Rows[i]["TareWt"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());


                if (clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length <= 50)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()));
                    strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length <= 112)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length - 50)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length <= 174)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length <= 236)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length - 174)).Trim());
                }


                PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }
    //public static Boolean Print_ContainerBarcode_New(string strPrinterName, string strUserName, string strPrintedDate, DataTable dt)
    //{
    //    IntPtr lhPrinter = new IntPtr();
    //    DOCINFO Doc = new DOCINFO();
    //    int pcWritten = 0;
    //    string strFileData;
    //    Doc.pDocName = "Formulation In Process Printing";
    //    Doc.pDataType = "RAW";
    //    try
    //    {
    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            strFileData = string.Empty;


    //            PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
    //            PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
    //            PrintDirect.StartPagePrinter(lhPrinter);

    //            strFileData = ReadPrn("inprocesswithoutwt.prn");
    //            if (dt.Rows[i]["BARCODENO"].ToString().StartsWith("B"))
    //            {
    //                strFileData = strFileData.Replace("IN-PROCESS", "BULK FINISHED GOODS");
    //            }
    //            else
    //            {
    //                strFileData = strFileData.Replace("IN-PROCESS", "IN-PROCESS");
    //            }
    //            strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["BARCODENO"].ToString());
    //            strFileData = strFileData.Replace("{Plant}", dt.Rows[i]["PLANTCODE"].ToString());
    //            strFileData = strFileData.Replace("{Stage}", dt.Rows[i]["Operationno"].ToString().Split('-').GetValue(1).ToString());
    //            strFileData = strFileData.Replace("{NxtStage}", dt.Rows[i]["NEXTOPNO"].ToString().Contains("-") == false ? dt.Rows[i]["NEXTOPNO"].ToString() : dt.Rows[i]["NEXTOPNO"].ToString().Split('-').GetValue(1).ToString());
    //            strFileData = strFileData.Replace("{MATCD}", dt.Rows[i]["MaterialCode"].ToString().TrimStart('0'));
    //            strFileData = strFileData.Replace("{BATCHNO}", dt.Rows[i]["batchNo"].ToString());
    //            //strFileData = strFileData.Replace("{GRWT}", dt.Rows[i]["GROSSWT"].ToString());
    //            //strFileData = strFileData.Replace("{NETWT}", dt.Rows[i]["NetWt"].ToString());
    //            //strFileData = strFileData.Replace("{TAREWT}", dt.Rows[i]["TAREWT"].ToString());
    //            strFileData = strFileData.Replace("{CONT CODE}", dt.Rows[i]["ContainerID"].ToString() == "" ? "NA" : dt.Rows[i]["ContainerID"].ToString());
    //            strFileData = strFileData.Replace("{CONTNO}", dt.Rows[i]["Seq"].ToString());

    //            //strFileData = strFileData.Replace("{CONO}", dt.Rows[i]["Seq"].ToString().Split('/').GetValue(1).ToString());
    //            strFileData = strFileData.Replace("{PO}", dt.Rows[i]["ProcessOrderNo"].ToString().TrimStart('0'));
    //            strFileData = strFileData.Replace("{Part}", dt.Rows[i]["PARTNO"].ToString() == "" ? "NA" : dt.Rows[i]["PARTNO"].ToString());
    //            strFileData = strFileData.Replace("{Lot}", dt.Rows[i]["LOTNO"].ToString() == "" ? "NA" : dt.Rows[i]["LOTNO"].ToString());
    //            strFileData = strFileData.Replace("{PrintBy}", strUserName);
    //            strFileData = strFileData.Replace("{PrintDate}", strPrintedDate);



    //            if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 50)
    //            {
    //                strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()));
    //                strFileData = strFileData.Replace("{MATNAME2}", string.Empty);
    //                strFileData = strFileData.Replace("{MATNAME3}", string.Empty);
    //                strFileData = strFileData.Replace("{MATNAME4}", string.Empty);

    //            }
    //            else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 112)
    //            {
    //                strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
    //                strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 50)).Trim());
    //                strFileData = strFileData.Replace("{MATNAME3}", string.Empty);
    //                strFileData = strFileData.Replace("{MATNAME4}", string.Empty);

    //            }
    //            else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 174)
    //            {
    //                strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
    //                strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
    //                strFileData = strFileData.Replace("{MATNAME3}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Length - 112)).Trim());
    //                strFileData = strFileData.Replace("{MATNAME4}", string.Empty);
    //            }
    //            else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 236)
    //            {
    //                strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
    //                strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
    //                strFileData = strFileData.Replace("{MATNAME3}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, 62).Trim());
    //                strFileData = strFileData.Replace("{MATNAME4}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Length - 174)).Trim());
    //            }



    //            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


    //        }
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ApplicationException(ex.Message);
    //    }
    //    finally
    //    {
    //        PrintDirect.EndPagePrinter(lhPrinter);
    //        PrintDirect.EndDocPrinter(lhPrinter);
    //        PrintDirect.ClosePrinter(lhPrinter);
    //    }
    //}

    public static Boolean Print_ContainerBarcode_New(string strPrinterName, string strUserName, string strPrintedDate, DataTable dt)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = "Formulation In Process Printing";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;


                PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                strFileData = ReadPrn("inprocesswithoutwt.prn");
                if (dt.Rows[i]["BARCODENO"].ToString().StartsWith("B"))
                {
                    strFileData = strFileData.Replace("IN-PROCESS", "BULK FINISHED GOODS");
                }
                else
                {
                    strFileData = strFileData.Replace("IN-PROCESS", "IN-PROCESS");
                }
                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["BARCODENO"].ToString());
                strFileData = strFileData.Replace("{Plant}", dt.Rows[i]["PLANTCODE"].ToString());
                string strStage = dt.Rows[i]["Operationno"].ToString().Split('-').GetValue(1).ToString();
                string strNextStage = dt.Rows[i]["NEXTOPNO"].ToString().Contains("-") == false ? dt.Rows[i]["NEXTOPNO"].ToString() : dt.Rows[i]["NEXTOPNO"].ToString().Split('-').GetValue(1).ToString();
                if (clsStandards.filter(strStage).Length <= 20)
                {
                    strFileData = strFileData.Replace("{Stage}", strStage);
                    strFileData = strFileData.Replace("{Stage1}", "");

                }
                else
                {
                    strFileData = strFileData.Replace("{Stage}", clsStandards.filter(strStage).Substring(0, 20).Trim());
                    strFileData = strFileData.Replace("{Stage1}", clsStandards.filter(strStage).Substring(20, Convert.ToInt32(clsStandards.filter(strStage).Length - 20)).Trim());

                }

                if (clsStandards.filter(strNextStage).Length <= 25)
                {
                    strFileData = strFileData.Replace("{NxtStage}", strNextStage);
                    strFileData = strFileData.Replace("{NxtStage1}", "");

                }
                else
                {
                    strFileData = strFileData.Replace("{NxtStage}", clsStandards.filter(strNextStage).Substring(0, 25).Trim());
                    strFileData = strFileData.Replace("{NxtStage1}", clsStandards.filter(strNextStage).Substring(25, Convert.ToInt32(clsStandards.filter(strNextStage).Length - 25)).Trim());

                }


                //strFileData = strFileData.Replace("{NxtStage}", );
                strFileData = strFileData.Replace("{MATCD}", dt.Rows[i]["MaterialCode"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{BATCHNO}", dt.Rows[i]["batchNo"].ToString());
                //strFileData = strFileData.Replace("{GRWT}", dt.Rows[i]["GROSSWT"].ToString());
                //strFileData = strFileData.Replace("{NETWT}", dt.Rows[i]["NetWt"].ToString());
                //strFileData = strFileData.Replace("{TAREWT}", dt.Rows[i]["TAREWT"].ToString());
                strFileData = strFileData.Replace("{CONT CODE}", dt.Rows[i]["ContainerID"].ToString() == "" ? "NA" : dt.Rows[i]["ContainerID"].ToString());
                strFileData = strFileData.Replace("{CONTNO}", dt.Rows[i]["Seq"].ToString());

                //strFileData = strFileData.Replace("{CONO}", dt.Rows[i]["Seq"].ToString().Split('/').GetValue(1).ToString());
                strFileData = strFileData.Replace("{PO}", dt.Rows[i]["ProcessOrderNo"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{Part}", dt.Rows[i]["PARTNO"].ToString() == "" ? "NA" : dt.Rows[i]["PARTNO"].ToString());
                strFileData = strFileData.Replace("{Lot}", dt.Rows[i]["LOTNO"].ToString() == "" ? "NA" : dt.Rows[i]["LOTNO"].ToString());
                strFileData = strFileData.Replace("{PrintBy}", strUserName);
                strFileData = strFileData.Replace("{PrintDate}", strPrintedDate);



                if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 50)
                {
                    strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()));
                    strFileData = strFileData.Replace("{MATNAME2}", string.Empty);
                    strFileData = strFileData.Replace("{MATNAME3}", string.Empty);
                    strFileData = strFileData.Replace("{MATNAME4}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 112)
                {
                    strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 50)).Trim());
                    strFileData = strFileData.Replace("{MATNAME3}", string.Empty);
                    strFileData = strFileData.Replace("{MATNAME4}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 174)
                {
                    strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{MATNAME3}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{MATNAME4}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 236)
                {
                    strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{MATNAME3}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, 62).Trim());
                    strFileData = strFileData.Replace("{MATNAME4}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 174)).Trim());
                }



                PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }

    public static Boolean Print_InProcess_MaterialLabel_WithoutWt(string strPrinterName, string strUserName, string strPrintedDate, DataTable dt)
    {

        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = "Formulation In Process Printing";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;


                PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                strFileData = ReadPrn("MaterialLabelWithoutWt.prn");

                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["BarcodeNo"].ToString());
                strFileData = strFileData.Replace("{PLANT}", dt.Rows[i]["PLANTCODE"].ToString());
                strFileData = strFileData.Replace("{ADD1}", dt.Rows[i]["ADD1"].ToString());
                strFileData = strFileData.Replace("{ADD2}", dt.Rows[i]["ADD2"].ToString());
                strFileData = strFileData.Replace("{ADD3}", dt.Rows[i]["ADD3"].ToString());
                strFileData = strFileData.Replace("{ADD4}", dt.Rows[i]["ADD4"].ToString());

                strFileData = strFileData.Replace("{ITEM}", dt.Rows[i]["MaterialCode"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{BATCH}", dt.Rows[i]["BatchNo"].ToString());
                strFileData = strFileData.Replace("{GRADE}", dt.Rows[i]["GRADE"].ToString());

                //strFileData = strFileData.Replace("{GRWT}", dt.Rows[i]["GROSSWT"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
                //strFileData = strFileData.Replace("{NETWT}", dt.Rows[i]["NetWt"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
                //strFileData = strFileData.Replace("{TAREWT}", dt.Rows[i]["TAREWT"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
                strFileData = strFileData.Replace("{CONTNO}", dt.Rows[i]["ContainerId"].ToString());
                strFileData = strFileData.Replace("{TOTCONTNO}", dt.Rows[i]["SEQ"].ToString().Split('/').GetValue(1).ToString());

                strFileData = strFileData.Replace("{MFGDT}", dt.Rows[i]["MFGDATE"].ToString());
                strFileData = strFileData.Replace("{MFGLICNO}", dt.Rows[i]["MFGLICNO"].ToString());

                strFileData = strFileData.Replace("{PRINTBY}", strUserName);
                strFileData = strFileData.Replace("{PRINTDT}", strPrintedDate);




                //if (clsStandards.filter(dt.Rows[i]["PLANTADDRESS"].ToString().Trim()).Length <= 50)
                //{
                //    strFileData = strFileData.Replace("{ADD1}", clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()));
                //    strFileData = strFileData.Replace("{ADD2}", string.Empty);
                //    strFileData = strFileData.Replace("{ADD3}", string.Empty);


                //}
                //else if (clsStandards.filter(dt.Rows[i]["PLANTADDRESS"].ToString().Trim()).Length <= 112)
                //{
                //    strFileData = strFileData.Replace("{ADD1}", clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Substring(0, 50).Trim());
                //    strFileData = strFileData.Replace("{ADD2}", clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Length - 50)).Trim());
                //    strFileData = strFileData.Replace("{ADD3}", string.Empty);


                //}
                //else if (clsStandards.filter(dt.Rows[i]["PLANTADDRESS"].ToString().Trim()).Length <= 174)
                //{
                //    strFileData = strFileData.Replace("{ADD1}", clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Substring(0, 50).Trim());
                //    strFileData = strFileData.Replace("{ADD2}", clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Length - 50)).Trim());
                //    strFileData = strFileData.Replace("{ADD3}", clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Length - 112)).Trim());
                //}


                if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 50)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()));
                    strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 112)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 50)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 174)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 236)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 174)).Trim());
                }



                PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }

    public static Boolean Print_InProcess_MaterialLabel_WithWt(string strPrinterName, string strUserName, string strPrintedDate, DataTable dt)
    {

        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = "Formulation In Process Printing";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;


                PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                strFileData = ReadPrn("MaterialLabelWithWt.prn");

                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["ContainerBarcode"].ToString());
                strFileData = strFileData.Replace("{PLANT}", dt.Rows[i]["PLANTCODE"].ToString());
                strFileData = strFileData.Replace("{ADD1}", dt.Rows[i]["ADD1"].ToString());
                strFileData = strFileData.Replace("{ADD2}", dt.Rows[i]["ADD2"].ToString());
                strFileData = strFileData.Replace("{ADD3}", dt.Rows[i]["ADD3"].ToString());
                strFileData = strFileData.Replace("{ADD4}", dt.Rows[i]["ADD4"].ToString());

                strFileData = strFileData.Replace("{ITEM}", dt.Rows[i]["MaterialCode"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{BATCH}", dt.Rows[i]["BatchNo"].ToString());
                strFileData = strFileData.Replace("{GRADE}", dt.Rows[i]["GRADE"].ToString());

                strFileData = strFileData.Replace("{GRWT}", dt.Rows[i]["GROSSWT"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
                strFileData = strFileData.Replace("{NETWT}", dt.Rows[i]["NetWt"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
                strFileData = strFileData.Replace("{TAREWT}", dt.Rows[i]["TAREWT"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
                strFileData = strFileData.Replace("{CONTNO}", dt.Rows[i]["ContainerId"].ToString());
                strFileData = strFileData.Replace("{TOTCONTNO}", dt.Rows[i]["SEQ"].ToString().Split('/').GetValue(1).ToString());

                strFileData = strFileData.Replace("{MFGDT}", dt.Rows[i]["MFGDATE"].ToString());
                strFileData = strFileData.Replace("{MFGLICNO}", dt.Rows[i]["MFGLICNO"].ToString());

                strFileData = strFileData.Replace("{PRINTBY}", strUserName);
                strFileData = strFileData.Replace("{PRINTDT}", strPrintedDate);




                //if (clsStandards.filter(dt.Rows[i]["PLANTADDRESS"].ToString().Trim()).Length <= 50)
                //{
                //    strFileData = strFileData.Replace("{ADD1}", clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()));
                //    strFileData = strFileData.Replace("{ADD2}", string.Empty);
                //    strFileData = strFileData.Replace("{ADD3}", string.Empty);


                //}
                //else if (clsStandards.filter(dt.Rows[i]["PLANTADDRESS"].ToString().Trim()).Length <= 112)
                //{
                //    strFileData = strFileData.Replace("{ADD1}", clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Substring(0, 50).Trim());
                //    strFileData = strFileData.Replace("{ADD2}", clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Length - 50)).Trim());
                //    strFileData = strFileData.Replace("{ADD3}", string.Empty);


                //}
                //else if (clsStandards.filter(dt.Rows[i]["PLANTADDRESS"].ToString().Trim()).Length <= 174)
                //{
                //    strFileData = strFileData.Replace("{ADD1}", clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Substring(0, 50).Trim());
                //    strFileData = strFileData.Replace("{ADD2}", clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Length - 50)).Trim());
                //    strFileData = strFileData.Replace("{ADD3}", clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PlantAddress"].ToString().Trim()).Length - 112)).Trim());
                //}


                if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 50)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()));
                    strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 112)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 50)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 174)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 236)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 174)).Trim());
                }



                PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }

    //public static Boolean Print_InProcessBarcode_New(string strPrinterName, string strUserName, string strPrintedDate, DataTable dt)
    //{

    //    IntPtr lhPrinter = new IntPtr();
    //    DOCINFO Doc = new DOCINFO();
    //    int pcWritten = 0;
    //    string strFileData;
    //    Doc.pDocName = "Formulation In Process Printing";
    //    Doc.pDataType = "RAW";
    //    try
    //    {
    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            strFileData = string.Empty;


    //            PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
    //            PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
    //            PrintDirect.StartPagePrinter(lhPrinter);

    //            strFileData = ReadPrn("INPROCESSWITHWT.prn");
    //            if (dt.Rows[i]["CONTAINERBARCODE"].ToString().StartsWith("B"))
    //            {
    //                strFileData = strFileData.Replace("IN-PROCESS", "BULK FINISHED GOODS");
    //            }
    //            else
    //            {
    //                strFileData = strFileData.Replace("IN-PROCESS", "IN-PROCESS");
    //            }
    //            strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["CONTAINERBARCODE"].ToString());
    //            strFileData = strFileData.Replace("{PLANT}", dt.Rows[i]["PLANTCODE"].ToString());
    //            strFileData = strFileData.Replace("{STAGE}", dt.Rows[i]["CurrentOpNo"].ToString().Split('-').GetValue(1).ToString());
    //            strFileData = strFileData.Replace("{NEXTSTAGE}", dt.Rows[i]["NEXTOPNO"].ToString().Contains("-") == false ? dt.Rows[i]["NEXTOPNO"].ToString() : dt.Rows[i]["NEXTOPNO"].ToString().Split('-').GetValue(1).ToString());
    //            strFileData = strFileData.Replace("{MATCD}", dt.Rows[i]["MatCode"].ToString().TrimStart('0'));
    //            strFileData = strFileData.Replace("{BATCHNO}", dt.Rows[i]["BatchNo"].ToString());
    //            strFileData = strFileData.Replace("{GRWT}", dt.Rows[i]["GROSSWT"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
    //            strFileData = strFileData.Replace("{NETWT}", dt.Rows[i]["NetWt"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
    //            strFileData = strFileData.Replace("{TAREWT}", dt.Rows[i]["TAREWT"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
    //            strFileData = strFileData.Replace("{CONTCODE}", dt.Rows[i]["ContainerCode"].ToString());
    //            if (dt.Rows[i]["Seq"].ToString() != "")
    //            {
    //                strFileData = strFileData.Replace("{CONTNO}", dt.Rows[i]["Seq"].ToString());
    //                //strFileData = strFileData.Replace("{TOTCONT}", dt.Rows[i]["Seq"].ToString().Split('/').GetValue(1).ToString());

    //            }
    //            strFileData = strFileData.Replace("{PO}", dt.Rows[i]["ProcessOrderNo"].ToString().TrimStart('0'));
    //            strFileData = strFileData.Replace("{PART}", dt.Rows[i]["PARTNO"].ToString() == "" ? "NA" : dt.Rows[i]["PARTNO"].ToString());
    //            strFileData = strFileData.Replace("{LOT}", dt.Rows[i]["LOTNO"].ToString() == "" ? "NA" : dt.Rows[i]["LOTNO"].ToString());
    //            strFileData = strFileData.Replace("{PRINTBY}", strUserName);
    //            strFileData = strFileData.Replace("{PRINTDT}", strPrintedDate);



    //            if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 50)
    //            {
    //                strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()));
    //                strFileData = strFileData.Replace("{MATNAME1}", string.Empty);
    //                strFileData = strFileData.Replace("{MATNAME2}", string.Empty);
    //                strFileData = strFileData.Replace("{MATNAME3}", string.Empty);

    //            }
    //            else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 112)
    //            {
    //                strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
    //                strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 50)).Trim());
    //                strFileData = strFileData.Replace("{MATNAME2}", string.Empty);
    //                strFileData = strFileData.Replace("{MATNAME3}", string.Empty);

    //            }
    //            else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 174)
    //            {
    //                strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
    //                strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
    //                strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Length - 112)).Trim());
    //                strFileData = strFileData.Replace("{MATNAME3}", string.Empty);
    //            }
    //            else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 236)
    //            {
    //                strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
    //                strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
    //                strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, 62).Trim());
    //                strFileData = strFileData.Replace("{MATNAME3}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["ProdDesc"].ToString().Trim()).Length - 174)).Trim());
    //            }



    //            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


    //        }
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ApplicationException(ex.Message);
    //    }
    //    finally
    //    {
    //        PrintDirect.EndPagePrinter(lhPrinter);
    //        PrintDirect.EndDocPrinter(lhPrinter);
    //        PrintDirect.ClosePrinter(lhPrinter);
    //    }
    //}

    public static Boolean Print_InProcessBarcode_New(string strPrinterName, string strUserName, string strPrintedDate, DataTable dt)
    {

        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = "Formulation In Process Printing";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;


                PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                strFileData = ReadPrn("INPROCESSWITHWT.prn");
                if (dt.Rows[i]["CONTAINERBARCODE"].ToString().StartsWith("B"))
                {
                    strFileData = strFileData.Replace("IN-PROCESS", "BULK FINISHED GOODS");
                }
                else
                {
                    strFileData = strFileData.Replace("IN-PROCESS", "IN-PROCESS");
                }
                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["CONTAINERBARCODE"].ToString());
                strFileData = strFileData.Replace("{PLANT}", dt.Rows[i]["PLANTCODE"].ToString());
                string strStage = dt.Rows[i]["CurrentOpNo"].ToString().Split('-').GetValue(1).ToString();
                string strNextStage = dt.Rows[i]["NEXTOPNO"].ToString().Contains("-") == false ? dt.Rows[i]["NEXTOPNO"].ToString() : dt.Rows[i]["NEXTOPNO"].ToString().Split('-').GetValue(1).ToString();

                if (clsStandards.filter(strStage).Length <= 20)
                {
                    strFileData = strFileData.Replace("{STAGE}", strStage);
                    strFileData = strFileData.Replace("{STAGE1}", "");

                }
                else
                {
                    strFileData = strFileData.Replace("{STAGE}", clsStandards.filter(strStage).Substring(0, 20).Trim());
                    strFileData = strFileData.Replace("{STAGE1}", clsStandards.filter(strStage).Substring(20, Convert.ToInt32(clsStandards.filter(strStage).Length - 20)).Trim());

                }

                if (clsStandards.filter(strNextStage).Length <= 25)
                {
                    strFileData = strFileData.Replace("{NEXTSTAGE}", strNextStage);
                    strFileData = strFileData.Replace("{NEXTSTAGE1}", "");

                }
                else
                {
                    strFileData = strFileData.Replace("{NEXTSTAGE}", clsStandards.filter(strNextStage).Substring(0, 25).Trim());
                    strFileData = strFileData.Replace("{NEXTSTAGE1}", clsStandards.filter(strNextStage).Substring(25, Convert.ToInt32(clsStandards.filter(strNextStage).Length - 25)).Trim());

                }

                strFileData = strFileData.Replace("{MATCD}", dt.Rows[i]["MatCode"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{BATCHNO}", dt.Rows[i]["BatchNo"].ToString());
                strFileData = strFileData.Replace("{GRWT}", dt.Rows[i]["Uom"].ToString() == "EA" || dt.Rows[i]["Uom"].ToString() == "L" ? "" : dt.Rows[i]["GROSSWT"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
                strFileData = strFileData.Replace("{NETWT}", dt.Rows[i]["NetWt"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
                strFileData = strFileData.Replace("{TAREWT}", dt.Rows[i]["Uom"].ToString() == "EA" || dt.Rows[i]["Uom"].ToString() == "L" ? "" : dt.Rows[i]["TAREWT"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
                strFileData = strFileData.Replace("{CONTCODE}", dt.Rows[i]["ContainerCode"].ToString());
                if (dt.Rows[i]["Seq"].ToString() != "")
                {
                    strFileData = strFileData.Replace("{CONTNO}", dt.Rows[i]["Seq"].ToString());
                    //strFileData = strFileData.Replace("{TOTCONT}", dt.Rows[i]["Seq"].ToString().Split('/').GetValue(1).ToString());

                }
                strFileData = strFileData.Replace("{PO}", dt.Rows[i]["ProcessOrderNo"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{PART}", dt.Rows[i]["PARTNO"].ToString() == "" ? "NA" : dt.Rows[i]["PARTNO"].ToString());
                strFileData = strFileData.Replace("{LOT}", dt.Rows[i]["LOTNO"].ToString() == "" ? "NA" : dt.Rows[i]["LOTNO"].ToString());
                strFileData = strFileData.Replace("{PRINTBY}", strUserName);
                strFileData = strFileData.Replace("{PRINTDT}", strPrintedDate);



                if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 50)
                {
                    strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()));
                    strFileData = strFileData.Replace("{MATNAME1}", string.Empty);
                    strFileData = strFileData.Replace("{MATNAME2}", string.Empty);
                    strFileData = strFileData.Replace("{MATNAME3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 112)
                {
                    strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 50)).Trim());
                    strFileData = strFileData.Replace("{MATNAME2}", string.Empty);
                    strFileData = strFileData.Replace("{MATNAME3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 174)
                {
                    strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{MATNAME3}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 236)
                {
                    strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, 62).Trim());
                    strFileData = strFileData.Replace("{MATNAME3}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 174)).Trim());
                }



                PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }

    public static Boolean Print_OlrnBarcode_Po(string strPrinterName, string strUserName, string strPrintedDate, DataTable dt)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = "Emrm IN Process Label Printing";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;


                PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                strFileData = ReadPrn("OLRN.prn");
                strFileData = strFileData.Replace("{ITEM}", dt.Rows[0]["ItemCode"].ToString().TrimStart('0'));

                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[0]["BarcodeNo"].ToString());
                strFileData = strFileData.Replace("{GRADE}", dt.Rows[0]["GRADE"].ToString());
                strFileData = strFileData.Replace("{PLANT}", dt.Rows[i]["PLANTCODE"].ToString());
                strFileData = strFileData.Replace("{BATCH}", dt.Rows[i]["BatchNo"].ToString());
                strFileData = strFileData.Replace("{GRWT}", dt.Rows[i]["GROSSWT"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());
                strFileData = strFileData.Replace("{NETWT}", dt.Rows[i]["NetWt"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());
                strFileData = strFileData.Replace("{TRWT}", dt.Rows[i]["TAREWT"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());
                strFileData = strFileData.Replace("{PO}", dt.Rows[0]["ProcessOrderNo"].ToString().TrimStart('0'));

                strFileData = strFileData.Replace("{PRINTBY}", strUserName + " / " + System.DateTime.Now.ToString("dd/MM/yyyy"));

                strFileData = strFileData.Replace("{BATCHNO}", dt.Rows[i]["PRODUCTBATCH"].ToString());
                strFileData = strFileData.Replace("{PRODUCTCODE}", dt.Rows[i]["ProdCode"].ToString().TrimStart('0'));



                if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 50)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()));
                    strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 112)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 50)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 174)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 236)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 174)).Trim());
                }

                if (clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length <= 50)
                {
                    strFileData = strFileData.Replace("{PRODUCTDESC}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()));
                    strFileData = strFileData.Replace("{PRODUCTDESC1}", string.Empty);
                    strFileData = strFileData.Replace("{PRODUCTDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{PRODUCTDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length <= 112)
                {
                    strFileData = strFileData.Replace("{PRODUCTDESC}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC1}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length - 50)).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{PRODUCTDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length <= 174)
                {
                    strFileData = strFileData.Replace("{PRODUCTDESC}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC1}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC2}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC3}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length <= 236)
                {
                    strFileData = strFileData.Replace("{PRODUCTDESC}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC1}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC2}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(112, 62).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC3}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length - 174)).Trim());
                }


                PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }


    }

    public static Boolean Print_OlrnResLabel(string printerName, DataTable dt, string strPrintBy, string strPrintOn)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = "OLRN Against Reservation";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;


                PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                strFileData = ReadPrn("olrnres.prn");
                strFileData = strFileData.Replace("{PLANT}", dt.Rows[i]["PLANTCODE"].ToString());
                strFileData = strFileData.Replace("{GRADE}", dt.Rows[i]["GRADE"].ToString());
                strFileData = strFileData.Replace("{ITEM}", dt.Rows[i]["ItemCode"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{DOCNO}", dt.Rows[i]["MatDocNo"].ToString());
                strFileData = strFileData.Replace("{BATCHNO}", dt.Rows[i]["BatchNo"].ToString());
                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["BarcodeNo"].ToString());
                strFileData = strFileData.Replace("{PRINTBY}", strPrintBy + " / " + strPrintOn);
                //strFileData = strFileData.Replace("{RAISEDBY}", strPrintBy + "/" + strPrintOn);
                //strFileData = strFileData.Replace("{CHECKEDBY}", strPrintBy + "/" + strPrintOn);

                if (dt.Rows[i]["BaseUom"].ToString().Trim().ToUpper() == "EA")
                {
                    strFileData = strFileData.Replace("Gross Wt. :", "");
                    strFileData = strFileData.Replace("Tare Wt.:", "");
                    strFileData = strFileData.Replace("Net Wt. :", "Quantity : " + dt.Rows[i]["NetWt"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());
                    strFileData = strFileData.Replace("{GRWT}", "");
                    strFileData = strFileData.Replace("{NETWT}", "");
                    strFileData = strFileData.Replace("{TRWT}", "");
                }
                else
                {
                    strFileData = strFileData.Replace("{GRWT}", dt.Rows[i]["GrossWt"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());
                    strFileData = strFileData.Replace("{NETWT}", dt.Rows[i]["NetWt"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());
                    strFileData = strFileData.Replace("{TRWT}", dt.Rows[i]["TareWt"].ToString() + " " + dt.Rows[i]["BaseUom"].ToString());
                }


                if (clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length <= 50)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()));
                    strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length <= 112)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length - 50)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length <= 174)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length <= 236)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MatDesc"].ToString().Trim()).Length - 174)).Trim());
                }


                PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }

    public static Boolean Print_ReceiptLabel(string printerName, string strBarcode, string strMatCode, string strDescription, string strSapBatch, string strManuBatch, string strMfgCode, string strMfgName, string strGrade)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = strMatCode;
        Doc.pDataType = "RAW";
        try
        {
            PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
            PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
            PrintDirect.StartPagePrinter(lhPrinter);
            strFileData = ReadPrn("RECEIPT.prn");
            strFileData = strFileData.Replace("{ITEM}", strMatCode);
            strFileData = strFileData.Replace("{GRADE}", strGrade);
            if (clsStandards.filter(strDescription).Length <= 33)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strDescription.Trim()));
                strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
            }
            else if (clsStandards.filter(strDescription).Length <= 82)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strDescription).Substring(0, 33).Trim());
                strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strDescription).Substring(33, Convert.ToInt32(clsStandards.filter(strDescription).Length - 33)).Trim());
                strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
            }
            else if (clsStandards.filter(strDescription).Length <= 131)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strDescription).Substring(0, 33).Trim());
                strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strDescription).Substring(33, 49).Trim());
                strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strDescription).Substring(82, Convert.ToInt32(clsStandards.filter(strDescription).Length - 82)).Trim());
                strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
            }
            else if (clsStandards.filter(strDescription).Length <= 180)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strDescription).Substring(0, 33).Trim());
                strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strDescription).Substring(33, 49).Trim());
                strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strDescription).Substring(82, 49).Trim());
                strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strDescription).Substring(131, Convert.ToInt32(clsStandards.filter(strDescription).Length - 131)).Trim());
                strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
            }
            else
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strDescription).Substring(0, 33).Trim());
                strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strDescription).Substring(33, 49).Trim());
                strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strDescription).Substring(82, 49).Trim());
                strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strDescription).Substring(131, 49).Trim());
                strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strDescription).Substring(180, Convert.ToInt32(clsStandards.filter(strDescription).Length - 180)).Trim());
            }

            strFileData = strFileData.Replace("{SAP}", strSapBatch.Trim());
            strFileData = strFileData.Replace("{VBATCH}", strManuBatch.Trim());
            strFileData = strFileData.Replace("{MFGCODE}", strMfgCode.Trim());
            strFileData = strFileData.Replace("{BARCODE}", strBarcode.Trim());


            if (clsStandards.filter(strMfgName).Length <= 34)
            {
                strFileData = strFileData.Replace("{MANUFACTURER1}", clsStandards.filter(strMfgName.Trim()));
                strFileData = strFileData.Replace("{MANUFACTURER2}", string.Empty);
                strFileData = strFileData.Replace("{MANUFACTURER3}", string.Empty);

            }
            else if (clsStandards.filter(strMfgName).Length <= 83)
            {
                strFileData = strFileData.Replace("{MANUFACTURER1}", clsStandards.filter(strMfgName).Substring(0, 34).Trim());
                strFileData = strFileData.Replace("{MANUFACTURER2}", clsStandards.filter(strMfgName).Substring(34, Convert.ToInt32(clsStandards.filter(strMfgName).Length - 34)).Trim());
                strFileData = strFileData.Replace("{MANUFACTURER3}", string.Empty);

            }
            else if (clsStandards.filter(strMfgName).Length <= 132)
            {
                strFileData = strFileData.Replace("{MANUFACTURER1}", clsStandards.filter(strMfgName).Substring(0, 34).Trim());
                strFileData = strFileData.Replace("{MANUFACTURER2}", clsStandards.filter(strMfgName).Substring(34, 49).Trim());
                strFileData = strFileData.Replace("{MANUFACTURER3}", clsStandards.filter(strMfgName).Substring(83, Convert.ToInt32(clsStandards.filter(strMfgName).Length - 83)).Trim());
            }


            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }

    //To Print In process API Container Tare Weight Label

    public static Boolean Print_CodetoCode_new(string strPrinterName, string strUserName, string strPrintedDate, DataTable dt)
    {

        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = "Formulation In Process Printing";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;


                PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                strFileData = ReadPrn("CodeToCode.prn");
                if (dt.Rows[i]["CONTAINERBARCODE"].ToString().StartsWith("B"))
                {
                    strFileData = strFileData.Replace("IN-PROCESS", "BULK FINISHED GOODS");
                }
                else
                {
                    strFileData = strFileData.Replace("IN-PROCESS", "IN-PROCESS");
                }
                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["CONTAINERBARCODE"].ToString());
                strFileData = strFileData.Replace("{PLANT}", dt.Rows[i]["PLANTCODE"].ToString());
                string strStage = dt.Rows[i]["CurrentOpNo"].ToString().Split('-').GetValue(1).ToString();
                string strNextStage = dt.Rows[i]["NEXTOPNO"].ToString().Contains("-") == false ? dt.Rows[i]["NEXTOPNO"].ToString() : dt.Rows[i]["NEXTOPNO"].ToString().Split('-').GetValue(1).ToString();

                if (clsStandards.filter(strStage).Length <= 20)
                {
                    strFileData = strFileData.Replace("{STAGE}", strStage);
                    strFileData = strFileData.Replace("{STAGE1}", "");

                }
                else
                {
                    strFileData = strFileData.Replace("{STAGE}", clsStandards.filter(strStage).Substring(0, 20).Trim());
                    strFileData = strFileData.Replace("{STAGE1}", clsStandards.filter(strStage).Substring(20, Convert.ToInt32(clsStandards.filter(strStage).Length - 20)).Trim());

                }

                if (clsStandards.filter(strNextStage).Length <= 25)
                {
                    strFileData = strFileData.Replace("{NEXTSTAGE}", strNextStage);
                    strFileData = strFileData.Replace("{NEXTSTAGE1}", "");

                }
                else
                {
                    strFileData = strFileData.Replace("{NEXTSTAGE}", clsStandards.filter(strNextStage).Substring(0, 25).Trim());
                    strFileData = strFileData.Replace("{NEXTSTAGE1}", clsStandards.filter(strNextStage).Substring(25, Convert.ToInt32(clsStandards.filter(strNextStage).Length - 25)).Trim());

                }

                strFileData = strFileData.Replace("{MATCD}", dt.Rows[i]["MatCode"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{BATCHNO}", dt.Rows[i]["BatchNo"].ToString());
                strFileData = strFileData.Replace("{GRWT}", dt.Rows[i]["Uom"].ToString() == "EA" || dt.Rows[i]["Uom"].ToString() == "L" ? "" : dt.Rows[i]["GROSSWT"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
                strFileData = strFileData.Replace("{NETWT}", dt.Rows[i]["NetWt"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
                strFileData = strFileData.Replace("{TAREWT}", dt.Rows[i]["Uom"].ToString() == "EA" || dt.Rows[i]["Uom"].ToString() == "L" ? "" : dt.Rows[i]["TAREWT"].ToString() + " " + dt.Rows[i]["Uom"].ToString());
                strFileData = strFileData.Replace("{CONTCODE}", dt.Rows[i]["ContainerCode"].ToString());
                if (dt.Rows[i]["Seq"].ToString() != "")
                {
                    strFileData = strFileData.Replace("{CONTNO}", dt.Rows[i]["Seq"].ToString());
                    //strFileData = strFileData.Replace("{TOTCONT}", dt.Rows[i]["Seq"].ToString().Split('/').GetValue(1).ToString());

                }
                strFileData = strFileData.Replace("{PO}", "");
                strFileData = strFileData.Replace("{PART}", "");
                strFileData = strFileData.Replace("{LOT}", "");
                strFileData = strFileData.Replace("{PRINTBY}", strUserName);
                strFileData = strFileData.Replace("{PRINTDT}", strPrintedDate);



                if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 50)
                {
                    strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()));
                    strFileData = strFileData.Replace("{MATNAME1}", string.Empty);
                    strFileData = strFileData.Replace("{MATNAME2}", string.Empty);
                    strFileData = strFileData.Replace("{MATNAME3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 112)
                {
                    strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 50)).Trim());
                    strFileData = strFileData.Replace("{MATNAME2}", string.Empty);
                    strFileData = strFileData.Replace("{MATNAME3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 174)
                {
                    strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 112)).Trim());
                    strFileData = strFileData.Replace("{MATNAME3}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 236)
                {
                    strFileData = strFileData.Replace("{MATNAME}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 50).Trim());
                    strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(50, 62).Trim());
                    strFileData = strFileData.Replace("{MATNAME2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(112, 62).Trim());
                    strFileData = strFileData.Replace("{MATNAME3}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(174, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 174)).Trim());
                }



                PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }



    public static Boolean Print_MaterialLabel(string strPrinterName, string strUserName, string strPrintedDate, DataTable dt)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        string qty;
        Doc.pDocName = "formulation code to code printing";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;

               

                PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                qty = dt.Rows[i]["ContainerQty"].ToString().Split('.').GetValue(0).ToString() + "." + dt.Rows[i]["ContainerQty"].ToString().Split('.').GetValue(1).ToString().Substring(0, 3);

                strFileData = ReadPrn("MateialRecieptSuLabel.prn");

                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["BarcodeNo"].ToString());
                strFileData = strFileData.Replace("{Item Code}", dt.Rows[i]["MaterialCode"].ToString());
                strFileData = strFileData.Replace("{Item Name}", dt.Rows[i]["MaterialName"].ToString());
                strFileData = strFileData.Replace("{Qty}", dt.Rows[i]["NoOfContainer"].ToString());
                strFileData = strFileData.Replace("{GRN No}", dt.Rows[i]["GRNNo"].ToString());
                strFileData = strFileData.Replace("{GRNDate}", dt.Rows[i]["GRNDate"].ToString().Split(' ').GetValue(0).ToString());
                strFileData = strFileData.Replace("{BatchNo}", dt.Rows[i]["BatchNo"].ToString());
                strFileData = strFileData.Replace("{MFG Date}", dt.Rows[i]["MFGDate"].ToString().Split(' ').GetValue(0).ToString());
                strFileData = strFileData.Replace("{Exp Date}", dt.Rows[i]["EXPDate"].ToString().Split(' ').GetValue(0).ToString());
                strFileData = strFileData.Replace("{VendorBatch}", dt.Rows[i]["GRNNo"].ToString());
                strFileData = strFileData.Replace("{Supplier}", dt.Rows[i]["VendorBatchNo"].ToString());
                strFileData = strFileData.Replace("{Manufacturer}", dt.Rows[i]["ManufactureName"].ToString());
                strFileData = strFileData.Replace("{RQty}", qty);
                strFileData = strFileData.Replace("{UPacks}", "");
                strFileData = strFileData.Replace("{Packs}", dt.Rows[i]["GRNCount"].ToString() + " Of " + dt.Rows[i]["NoOfContainer"].ToString());
                strFileData = strFileData.Replace("{Scond}", dt.Rows[i]["VendorBatchNo"].ToString());
                strFileData = strFileData.Replace("{PrintBy}", strUserName);
                strFileData = strFileData.Replace("{PrintDate}", strPrintedDate);

                 //Label Printing over Ip and Port//----

                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.NoDelay = true;
                IPAddress ip = IPAddress.Parse("192.168.124.60");
                IPEndPoint ipep = new IPEndPoint(ip, 9100);
                clientSocket.Connect(ipep);

                byte[] fileBytes = Encoding.ASCII.GetBytes(strFileData);

                clientSocket.Send(fileBytes);
                clientSocket.Close();
             //   PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);    


            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }
    public static Boolean Print_MaterialLabelIP(string strPrinterName, string strUserName, string strPrintedDate,string strIP, string strPort, DataTable dt)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        SqlDataLayer objData = new SqlDataLayer();
        string strFileData;
        string strStrCond;
        string strFormatNo = "";
        string strPrnFile = "";
        string qty;
        Doc.pDocName = "formulation code to code printing";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;



                PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                strFileData = ReadPrn("MateialRecieptSuLabel.prn");
                strPrnFile = "MateialRecieptSuLabel";

                if ((dt.Rows[i]["InwardNo"].ToString().ToUpper().Contains("HRM") == true) || (dt.Rows[i]["InwardNo"].ToString().ToUpper().Contains("HPM") == true))
                {
                    strFormatNo = objData.ExecuteScalarString(objData.strLocal, "SELECT FORMAT_NO FROM [TBL_PRINT_FORMAT] WHERE BLOCK = 'HB' AND PRN_FILE_NAME = '" + strPrnFile + "'");
                }
                else //if ((dt.Rows[i]["InwardNo"].ToString().ToUpper().Contains("GRM") == true) || (dt.Rows[i]["InwardNo"].ToString().ToUpper().Contains("GPM") == true))
                {
                    strFormatNo = objData.ExecuteScalarString(objData.strLocal, "SELECT FORMAT_NO FROM [TBL_PRINT_FORMAT] WHERE BLOCK = 'GB' AND PRN_FILE_NAME = '" + strPrnFile + "'");
                }

                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["BarcodeNo"].ToString());
                strFileData = strFileData.Replace("{Item Code}", dt.Rows[i]["MaterialCode"].ToString());
                strFileData = strFileData.Replace("{Item Name}", dt.Rows[i]["MaterialName"].ToString());
                strFileData = strFileData.Replace("{Qty}", dt.Rows[i]["NoOfContainer"].ToString()+" NOS");
                strFileData = strFileData.Replace("{GRN No}", dt.Rows[i]["GRNNo"].ToString() + "   /    " + DateTime.Parse(dt.Rows[i]["GRNDate"].ToString()).ToString("dd/MM/yy").Replace('-', '/'));
                strFileData = strFileData.Replace("{RDate}", DateTime.Parse(dt.Rows[i]["GRNDate"].ToString()).ToString("dd/MM/yy").Replace('-', '/'));
                strFileData = strFileData.Replace("{BatchNo}", dt.Rows[i]["BatchNo"].ToString());
                if (dt.Rows[i]["MaterialType"].ToString().ToUpper() == "PM")
                {
                    strFileData = strFileData.Replace("{MFG Date}", "NA");
                    strFileData = strFileData.Replace("{Exp Date}", "NA");
                    strFileData = strFileData.Replace("{ReDate}", "NA");
                }
                else
                {
                    strFileData = strFileData.Replace("{MFG Date}", DateTime.Parse(dt.Rows[i]["MFGDate"].ToString()).ToString("MM/yy").Replace('-', '/'));
                    if (dt.Rows[0]["V_Retest"].ToString() == "0")
                    {
                        strFileData = strFileData.Replace("{Exp Date}", DateTime.Parse(dt.Rows[i]["EXPDate"].ToString()).ToString("MM/yy").Replace('-', '/'));
                        strFileData = strFileData.Replace("{ReDate}", "NA");
                    }
                    else
                    {
                        strFileData = strFileData.Replace("{ReDate}", DateTime.Parse(dt.Rows[i]["EXPDate"].ToString()).ToString("MM/yy").Replace('-', '/'));
                        strFileData = strFileData.Replace("{Exp Date}", "NA");
                    }
                }
                strFileData = strFileData.Replace("{VendorBatch}", dt.Rows[i]["GRNNo"].ToString());
                strFileData = strFileData.Replace("{InwardNo}", dt.Rows[i]["InwardNo"].ToString());
                strFileData = strFileData.Replace("{VBatch}", dt.Rows[i]["BatchNo"].ToString().Trim() == "" ? "NA" : dt.Rows[i]["BatchNo"].ToString().Trim());
                strFileData = strFileData.Replace("{Manufacturer}", dt.Rows[i]["ManufactureName"].ToString());
                strFileData = strFileData.Replace("{Supplier}",  dt.Rows[i]["SupplierName"].ToString());
                strFileData = strFileData.Replace("{RQty}", double.Parse(dt.Rows[i]["TotalQty"].ToString()).ToString() + " " + dt.Rows[i]["BaseUom"].ToString());
                strFileData = strFileData.Replace("{UPacks}", dt.Rows[i]["UnitPack"].ToString());
                strFileData = strFileData.Replace("{Packs}", dt.Rows[i]["GRNCount"].ToString() + " Of " + dt.Rows[i]["NoOfContainer"].ToString());
                strStrCond = dt.Rows[i]["StoragCondition"].ToString().Replace("°", "\\B0");
                if (strStrCond != string.Empty)
                {
                    if (strStrCond.Length > 46)
                    {
                        strFileData = strFileData.Replace("{Scond}", strStrCond.Substring(0, 46));
                        strFileData = strFileData.Replace("{Scond1}", strStrCond.Substring(46, strStrCond.Length - 46));
                    }
                    else
                    {
                        strFileData = strFileData.Replace("{Scond}", strStrCond);
                        strFileData = strFileData.Replace("{Scond1}", " ");
                    }
                }
                else
                {
                    strFileData = strFileData.Replace("{Scond}", "NA");
                    strFileData = strFileData.Replace("{Scond1}", " ");
 
                }
                strFileData = strFileData.Replace("{PrintBy}", strUserName);
                strFileData = strFileData.Replace("{PrintDate}", strPrintedDate);

                strFileData = strFileData.Replace("{FORMATNO}", strFormatNo.Trim());

                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.NoDelay = true;
                IPAddress ip = IPAddress.Parse(strIP);
                IPEndPoint ipep = new IPEndPoint(ip, int.Parse(strPort));
                clientSocket.Connect(ipep);

                byte[] fileBytes = Encoding.ASCII.GetBytes(strFileData);

                clientSocket.Send(fileBytes);
                clientSocket.Close();
            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }

    public static Boolean CheckConnection(string strIP, string strPort)
    {
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            clientSocket.NoDelay = true;
            IPAddress ip = IPAddress.Parse(strIP);
            int Port = int.Parse(strPort);
            IPEndPoint ipep = new IPEndPoint(ip, Port);
            clientSocket.Connect(ipep);

            return true;

        }
        catch (Exception ex)
        {
            return false;
            throw new ApplicationException(ex.Message);
        }

        finally
        {
            clientSocket.Close();
        }
    }
    public static Boolean Print_SampleLabelIP(string strPrinterName, string strUserName, string strPrintedDate,string strIP, string strPort, DataTable dt)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        SqlDataLayer objData = new SqlDataLayer();
        int pcWritten = 0;
        string strFileData;
        string strFormatNo = "";
        string strPrnFile = "";
        Doc.pDocName = "formulation code to code printing";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;

                PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                if (dt.Rows[0]["MaterialType"].ToString().ToUpper() == "RM")
                {
                    strFileData = ReadPrn("SampledLabel-RM.prn");
                    strPrnFile = "SampledLabel-RM";
                }
                else
                {
                    strFileData = ReadPrn("SampledLabel-PM.prn");
                    strPrnFile = "SampledLabel-PM";
                }

                if (dt.Rows[i]["ARNo"].ToString().Substring(0, 1).Trim() == "H")
                {
                    strFormatNo = objData.ExecuteScalarString(objData.strLocal, "SELECT FORMAT_NO FROM [TBL_PRINT_FORMAT] WHERE BLOCK = 'HB' AND PRN_FILE_NAME = '" + strPrnFile + "'");
                }
                else //if(dt.Rows[i]["ARNo"].ToString().Substring(0, 1).Trim() == "G")
                {
                    strFormatNo = objData.ExecuteScalarString(objData.strLocal, "SELECT FORMAT_NO FROM [TBL_PRINT_FORMAT] WHERE BLOCK = 'GB' AND PRN_FILE_NAME = '" + strPrnFile + "'");
                }

                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["BarcodeNo"].ToString());
                strFileData = strFileData.Replace("{MaterialName}", dt.Rows[i]["MaterialCode"].ToString() + " / " + dt.Rows[i]["MaterialName"].ToString());
                strFileData = strFileData.Replace("{GRNNo}", dt.Rows[i]["GRNNo"].ToString());
                strFileData = strFileData.Replace("{GRNDate}", DateTime.Parse(dt.Rows[i]["GRNDate"].ToString()).ToString("dd/MM/yy").Replace('-','/'));
                strFileData = strFileData.Replace("{BatchNo}", dt.Rows[i]["BatchNo"].ToString());
                strFileData = strFileData.Replace("{ARNo}", dt.Rows[i]["ARNo"].ToString());
                strFileData = strFileData.Replace("{NOLabel}", dt.Rows[i]["LabelCount"].ToString() + " of " + dt.Rows[i]["NoOfContainer"].ToString());
                //strFileData = strFileData.Replace("{UnitNo}", dt.Rows[i]["UnitNo"].ToString());
                strFileData = strFileData.Replace("{PrintBy}", strUserName);
                strFileData = strFileData.Replace("{PrintDate}", strPrintedDate.Replace('-','/'));

                strFileData = strFileData.Replace("{FORMATNO}", strFormatNo.Trim());

                //Label Printing over Ip and Port//----

                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.NoDelay = true;
                IPAddress ip = IPAddress.Parse(strIP);
                IPEndPoint ipep = new IPEndPoint(ip, int.Parse(strPort));
                clientSocket.Connect(ipep);

                byte[] fileBytes = Encoding.ASCII.GetBytes(strFileData);

                clientSocket.Send(fileBytes);
                clientSocket.Close();
                // PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }
    public static Boolean Print_MRNLabelIP(string strPrinterName, string strUserName, string strPrintedDate, string strIP, string strPort, DataTable dt,string strProdBatch,string strProdName, string strUOM)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        SqlDataLayer objData = new SqlDataLayer();
        string strFileData;
        string strFormatNo = "";
        string strPrnFile = "";
        Doc.pDocName = "formulation code to code printing";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;

                PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                strFileData = ReadPrn("MateialReturnLabel.prn");
                strPrnFile = "MateialReturnLabel";


                if ((dt.Rows[i]["InwardNo"].ToString().ToUpper().Contains("HRM") == true) || (dt.Rows[i]["InwardNo"].ToString().ToUpper().Contains("HPM") == true))
                {
                    strFormatNo = objData.ExecuteScalarString(objData.strLocal, "SELECT FORMAT_NO FROM [TBL_PRINT_FORMAT] WHERE BLOCK = 'HB' AND PRN_FILE_NAME = '" + strPrnFile + "'");
                }
                else //if ((dt.Rows[i]["InwardNo"].ToString().ToUpper().Contains("GRM") == true) || (dt.Rows[i]["InwardNo"].ToString().ToUpper().Contains("GPM") == true))
                {
                    strFormatNo = objData.ExecuteScalarString(objData.strLocal, "SELECT FORMAT_NO FROM [TBL_PRINT_FORMAT] WHERE BLOCK = 'GB' AND PRN_FILE_NAME = '" + strPrnFile + "'");
                }
                //if (dt.Rows[i]["ARNo"].ToString().Substring(0, 1).Trim() == "H")
                //{
                //    strFormatNo = objData.ExecuteScalarString(objData.strLocal, "SELECT FORMAT_NO FROM [TBL_PRINT_FORMAT] WHERE BLOCK = 'HB' AND PRN_FILE_NAME = '" + strPrnFile + "'");
                //}
                //else //if (dt.Rows[i]["ARNo"].ToString().Substring(0, 1).Trim() == "G")
                //{
                //    strFormatNo = objData.ExecuteScalarString(objData.strLocal, "SELECT FORMAT_NO FROM [TBL_PRINT_FORMAT] WHERE BLOCK = 'GB' AND PRN_FILE_NAME = '" + strPrnFile + "'");
                //}

                strFileData = strFileData.Replace("{ProdName}", strProdName);
                strFileData = strFileData.Replace("{BatNo}", strProdBatch);
                strFileData = strFileData.Replace("{MatName}", dt.Rows[i]["MaterialName"].ToString());
                strFileData = strFileData.Replace("{ItemCode}", dt.Rows[i]["MaterialCode"].ToString());
                strFileData = strFileData.Replace("{ARNo}", dt.Rows[i]["ARNo"].ToString());
                strFileData = strFileData.Replace("{NetWt.}", double.Parse(dt.Rows[i]["ContainerQty"].ToString()).ToString() + " " + strUOM);
                strFileData = strFileData.Replace("{GrossWt.}", double.Parse(dt.Rows[i]["GWeight"].ToString()).ToString() == "0" ? "NA" : double.Parse(dt.Rows[i]["GWeight"].ToString()).ToString()+" "+ strUOM);
                strFileData = strFileData.Replace("{TareWt.}", double.Parse(dt.Rows[i]["TWeight"].ToString()).ToString() == "0" ? "NA" : double.Parse(dt.Rows[i]["TWeight"].ToString()).ToString() + "" + strUOM);
                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["BarcodeNo"].ToString());
                strFileData = strFileData.Replace("{FORMATNO}", strFormatNo.Trim());
                //Label Printing over Ip and Port//----

                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.NoDelay = true;
                IPAddress ip = IPAddress.Parse(strIP);
                IPEndPoint ipep = new IPEndPoint(ip, int.Parse(strPort));
                clientSocket.Connect(ipep);

                byte[] fileBytes = Encoding.ASCII.GetBytes(strFileData);

                clientSocket.Send(fileBytes);
                clientSocket.Close();
                // PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);

            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }
    public static Boolean Print_SampleLabel(string strPrinterName, string strUserName, string strPrintedDate, DataTable dt)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = "formulation code to code printing";
        Doc.pDataType = "RAW";
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strFileData = string.Empty;

                PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
                PrintDirect.StartPagePrinter(lhPrinter);

                strFileData = ReadPrn("SampledLabel.prn");

                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["BarcodeNo"].ToString());
                strFileData = strFileData.Replace("{MaterialName}", dt.Rows[i]["MaterialName"].ToString());
                strFileData = strFileData.Replace("{GRNNo}", dt.Rows[i]["GRNNo"].ToString());
                strFileData = strFileData.Replace("{GRNDate}", DateTime.Parse(dt.Rows[i]["GRNDate"].ToString()).ToString("dd/MM/yyyy"));
                strFileData = strFileData.Replace("{BatchNo}", dt.Rows[i]["BatchNo"].ToString());
                strFileData = strFileData.Replace("{ARNo}", dt.Rows[i]["ARNo"].ToString());
                strFileData = strFileData.Replace("{UnitNo}", dt.Rows[i]["UnitNo"].ToString());
                strFileData = strFileData.Replace("{PrintBy}", strUserName);
                strFileData = strFileData.Replace("{PrintDate}", strPrintedDate);

                //Label Printing over Ip and Port//----

                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.NoDelay = true;
                IPAddress ip = IPAddress.Parse("192.168.124.60");
                IPEndPoint ipep = new IPEndPoint(ip, 9100);
                clientSocket.Connect(ipep);

                byte[] fileBytes = Encoding.ASCII.GetBytes(strFileData);

                clientSocket.Send(fileBytes);
                clientSocket.Close();
               // PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);


            }
            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }

    //To Print In process API Container Gross Weight Label
    public static Boolean Print_InProcessBarcode(string strLabelType, string strPrinterName, string strBarcode, string strPlantCode, string strPoNumber,
           string strMatCode, string strMatDesc, string strBatchNo, string strCurrentOp, string strNextOp, string strLotNo,
            string strGrossWt, string strTareWt, string strNetWt, string strQty, string strUom, string strUserId, string strPartNo, string strSeq, string strContainerID)
    {

        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = strMatCode;
        Doc.pDataType = "RAW";
        strFileData = ReadPrn("INPROCESSPRINTING.prn");
        try
        {

            PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
            PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
            PrintDirect.StartPagePrinter(lhPrinter);
            if (strLabelType == "INPROC")
            {
                //laste stage BFG

                strFileData = strFileData.Replace("{HEADING}", "IN PROCESS");
            }
            else if (strLabelType == "MAT")
            {
                //material barcode
                strFileData = strFileData.Replace("{HEADING}", "MATERIAL");
            }
            else
            {
                strFileData = strFileData.Replace("{HEADING}", "BULK FINISHED GOODS");
                //inprocess
            }


            strFileData = strFileData.Replace("{PLANT}", strPlantCode);
            strFileData = strFileData.Replace("{STAGE}", strCurrentOp);
            strFileData = strFileData.Replace("{NEXTSTAGE}", strNextOp.Trim());
            strFileData = strFileData.Replace("{MATCD}", strMatCode.Trim());
            strFileData = strFileData.Replace("{BATCHNO}", strBatchNo.Trim());
            strFileData = strFileData.Replace("{GRWT}", strGrossWt.Trim());
            strFileData = strFileData.Replace("{NETWT}", strNetWt.Trim());
            strFileData = strFileData.Replace("{TAREWT}", strTareWt.Trim());
            strFileData = strFileData.Replace("{BATCHNO}", strBatchNo.Trim());
            strFileData = strFileData.Replace("{CONTCODE}", strContainerID.Trim());
            // strFileData = strFileData.Replace("{CONTNO}", strSeq.Split('/').GetValue(0).ToString());
            // strFileData = strFileData.Replace("{TOTCONT}", strSeq.Split('/').GetValue(1).ToString());
            strFileData = strFileData.Replace("{BARCODE}", strBarcode);
            if (clsStandards.filter(strMatDesc.Trim()).Length <= 33)
            {
                strFileData = strFileData.Replace("{MATNAME1}", clsStandards.filter(strMatDesc.Trim()));
                strFileData = strFileData.Replace("{MATNAME1}", string.Empty);
                strFileData = strFileData.Replace("{MATNAME1}", string.Empty);

            }
            else
            {
                strFileData = strFileData.Replace("{MATNAME1}", strMatDesc);
            }
            strFileData = strFileData.Replace("{PO}", strPoNumber);
            strFileData = strFileData.Replace("{PART}", strPartNo);
            strFileData = strFileData.Replace("{PRINTBY}", strUserId);
            strFileData = strFileData.Replace("{PRINTDT}", clsStandards.filter(System.DateTime.Now.ToShortDateString()));

            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
            return true;




        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }


    public static Boolean Print_OlrnBarcode(string strPrinterName, string strBarcode, string strPlantCode, string strPoNumber,
             string strMatCode, string strMatDesc, string strBatchNo, string strGrossWt, string strTareWt, string strNetWt, string strUserId, string strProdCode, string strProdDesc)
    {

        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = strMatCode;
        Doc.pDataType = "RAW";
        strFileData = ReadPrn("OLRNPRINTING.prn");
        try
        {

            PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
            PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
            PrintDirect.StartPagePrinter(lhPrinter);

            strFileData = strFileData.Replace("{ITEM}", strMatCode);
            strFileData = strFileData.Replace("{BATCH}", strBatchNo.Trim());
            strFileData = strFileData.Replace("{PO}", strPoNumber.Trim());
            strFileData = strFileData.Replace("{GRWT}", strGrossWt.Trim());
            strFileData = strFileData.Replace("{NETWT}", strNetWt.Trim());
            strFileData = strFileData.Replace("{TRWT}", strTareWt.Trim());
            strFileData = strFileData.Replace("{BATCHNO}", strBatchNo);
            strFileData = strFileData.Replace("{PRODUCTCODE}", strProdCode.Trim());
            strFileData = strFileData.Replace("{MATCD}", strMatCode.Trim());
            strFileData = strFileData.Replace("{BARCODE}", strBarcode);
            if (clsStandards.filter(strMatDesc.Trim()).Length <= 33)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDesc.Trim()));
                strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
            }
            else
            {
                strFileData = strFileData.Replace("{ITEMDESC}", strMatDesc);
            }
            if (clsStandards.filter(strProdDesc.Trim()).Length <= 33)
            {
                strFileData = strFileData.Replace("{PRODUCTDESC1}", clsStandards.filter(strMatDesc.Trim()));
                strFileData = strFileData.Replace("{PRODUCTDESC2}", string.Empty);
                strFileData = strFileData.Replace("{PRODUCTDESC3}", string.Empty);
            }
            else
            {
                strFileData = strFileData.Replace("{PRODUCTDESC}", strMatDesc);
            }

            strFileData = strFileData.Replace("{PRINTBY}", strUserId);
            strFileData = strFileData.Replace("{RAISEDBY}", "");
            strFileData = strFileData.Replace("{PRINTDT}", clsStandards.filter(System.DateTime.Now.ToShortDateString()));

            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
            return true;




        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }


    public static Boolean Print_EmrmBarcode(string strPrinterName, string strBarcode, string strPlantCode, string strPoNumber,
         string strMatCode, string strMatDesc, string strBatchNo, string strGrossWt, string strTareWt, string strNetWt, string strUserId, string strProdCode, string strProdDesc)
    {

        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = strMatCode;
        Doc.pDataType = "RAW";
        strFileData = ReadPrn("PRINTEMRMBARCODE.prn");
        try
        {

            PrintDirect.OpenPrinter(strPrinterName, ref lhPrinter, 0);
            PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
            PrintDirect.StartPagePrinter(lhPrinter);

            strFileData = strFileData.Replace("{ITEM}", strMatCode);
            strFileData = strFileData.Replace("{BATCH}", strBatchNo.Trim());
            strFileData = strFileData.Replace("{PO}", strPoNumber.Trim());
            strFileData = strFileData.Replace("{GRWT}", strGrossWt.Trim());
            strFileData = strFileData.Replace("{NETWT}", strNetWt.Trim());
            strFileData = strFileData.Replace("{TRWT}", strTareWt.Trim());
            strFileData = strFileData.Replace("{BATCHNO}", strBatchNo);
            strFileData = strFileData.Replace("{PRODUCTCODE}", strProdCode.Trim());
            strFileData = strFileData.Replace("{MATCD}", strMatCode.Trim());
            strFileData = strFileData.Replace("{BARCODE}", strBarcode);
            if (clsStandards.filter(strMatDesc.Trim()).Length <= 33)
            {
                strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDesc.Trim()));
                strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
            }
            else
            {
                strFileData = strFileData.Replace("{ITEMDESC}", strMatDesc);
            }
            if (clsStandards.filter(strProdDesc.Trim()).Length <= 33)
            {
                strFileData = strFileData.Replace("{PRODUCTDESC1}", clsStandards.filter(strMatDesc.Trim()));
                strFileData = strFileData.Replace("{PRODUCTDESC2}", string.Empty);
                strFileData = strFileData.Replace("{PRODUCTDESC3}", string.Empty);
            }
            else
            {
                strFileData = strFileData.Replace("{PRODUCTDESC}", strMatDesc);
            }

            strFileData = strFileData.Replace("{PRINTBY}", strUserId);
            strFileData = strFileData.Replace("{RAISEDBY}", "");
            strFileData = strFileData.Replace("{PRINTDT}", clsStandards.filter(System.DateTime.Now.ToShortDateString()));

            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
            return true;




        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }
    }


    public static Boolean Print_RegLabel(string strPrintName, string strBarcode)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = strBarcode;
        Doc.pDataType = "RAW";

        try
        {

            PrintDirect.OpenPrinter(strPrintName, ref lhPrinter, 0);
            PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
            PrintDirect.StartPagePrinter(lhPrinter);
            strFileData = ReadPrn("APINTMED.prn");
            strFileData = strFileData.Replace("{BARCODE}", strBarcode);
            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
            return true;
        }
        catch (Exception ex)
        {

            throw ex;
            return false;
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }



    }


    public static Boolean Print_Master_Barcode(string strPrintName, string strBarcode)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = strBarcode;
        Doc.pDataType = "RAW";

        try
        {

            PrintDirect.OpenPrinter(strPrintName, ref lhPrinter, 0);
            PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
            PrintDirect.StartPagePrinter(lhPrinter);
            strFileData = ReadPrn("MASTER.prn");
            strFileData = strFileData.Replace("{BARCODE}", strBarcode);
            PrintDirect.WritePrinter(lhPrinter, strFileData, strFileData.Length, ref pcWritten);
            return true;
        }
        catch (Exception ex)
        {

            throw ex;
            return false;
        }
        finally
        {
            PrintDirect.EndPagePrinter(lhPrinter);
            PrintDirect.EndDocPrinter(lhPrinter);
            PrintDirect.ClosePrinter(lhPrinter);
        }



    }
    /// <summary>
    /// Purpose : Function created to read base printing format from reference filename.
    /// </summary>
    /// <param name="strLevel_Type">Label type name reference.</param>
    /// <returns>Returning output in string format.</returns>
    public static string ReadPrn(string strLevel_Type)
    {
        try
        {
            string strFileData = string.Empty;
            //Reading HTML page and converting it into string format.
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/PrnFile/" + strLevel_Type)))
            {
                strFileData = reader.ReadToEnd();
            }
            return strFileData;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }


}

