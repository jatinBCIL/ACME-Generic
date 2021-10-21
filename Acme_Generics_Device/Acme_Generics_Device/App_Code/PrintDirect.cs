using System;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Net.Sockets;
using System.Net;
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


   
  
    
    //public static Boolean Print_DispenseRawLabel(string printerName, string strBarcode, string strMatCode, string strMatDescription, string strMatBatch, string strGrade, string strNxtInspectionDate, string strSLED, string strProcessOrder, string strProdCode, string strProdBatch, string strProdDesc, string strStageDesc, string strProcessDesc, decimal dGrosswt, decimal dNetwt, decimal dTarewt, string strIssuedBy, string strCheckedBy, string strIssueDate, string strCheckDate, string strLot, string strUom, string strPlantName)
    //{
    //    IntPtr lhPrinter = new IntPtr();
    //    DOCINFO Doc = new DOCINFO();
    //    int pcWritten = 0;
    //    string strFileData;
    //    Doc.pDocName = strMatCode;
    //    Doc.pDataType = "RAW";
    //    try
    //    {
    //        if (strProcessDesc == "")
    //        {
    //            strProcessDesc = " NA";
    //        }

    //        PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
    //        PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
    //        PrintDirect.StartPagePrinter(lhPrinter);
    //        strFileData = ReadPrn("CIPLARAWDISP.prn");

    //        strFileData = strFileData.Replace("{Plant}", strPlantName);
    //        strFileData = strFileData.Replace("{ITEM}", strMatCode);
    //        strFileData = strFileData.Replace("{LOT}", strLot);
    //        if (clsStandards.filter(strMatDescription).Length <= 55)
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription.Trim()));
    //            strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strMatDescription).Length <= 105)
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(55, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 55)).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strMatDescription).Length <= 165)
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(55, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(105, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 105)).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strMatDescription).Length <= 225)
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(55, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(105, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strMatDescription).Substring(165, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 165)).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(55, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(105, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strMatDescription).Substring(165, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC4}", clsStandards.filter(strMatDescription).Substring(225, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 225)).Trim());
    //        }

    //        strFileData = strFileData.Replace("{SAPBATCH}", strMatBatch.Trim());
    //        strFileData = strFileData.Replace("{GROSS}", Convert.ToString(dGrosswt) + " " + strUom);
    //        strFileData = strFileData.Replace("{TARE}", Convert.ToString(dTarewt) + " " + strUom);
    //        strFileData = strFileData.Replace("{NET}", Convert.ToString(dNetwt) + " " + strUom);

    //        strFileData = strFileData.Replace("{BARCODE}", strBarcode.Trim());

    //        strFileData = strFileData.Replace("{BATCH}", strProdBatch.Trim());
    //        if (strNxtInspectionDate.Trim() == "01/01/1900")
    //        {
    //            strFileData = strFileData.Replace("{NXTINSPDATE}", "NA");
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{NXTINSPDATE}", strNxtInspectionDate.Trim());
    //        }
    //        strFileData = strFileData.Replace("{GRADE}", strGrade.Trim());
    //        if (strSLED.Trim() == "01/01/1900")
    //        {
    //            strFileData = strFileData.Replace("{SLED}", "NA");
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{SLED}", strSLED.Trim());
    //        }

    //        strFileData = strFileData.Replace("{PONUM}", strProcessOrder.Trim());
    //        strFileData = strFileData.Replace("{ISSUEPROD}", strProdCode.Trim());

    //        strFileData = strFileData.Replace("{PROCDESC}", strProcessDesc.Trim());

    //        if (strStageDesc.Trim() != "")
    //        {
    //            strFileData = strFileData.Replace("{STGDESC}", "Dispensing of " + strStageDesc.Trim());
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{STGDESC}", "NA");
    //        }
    //        if (clsStandards.filter(strProdDesc).Length <= 55)
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc.Trim()));
    //            strFileData = strFileData.Replace("{PRODESC1}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC2}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strProdDesc).Length <= 105)
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(55, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 55)).Trim());
    //            strFileData = strFileData.Replace("{PRODESC2}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strProdDesc).Length <= 165)
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(55, 60).Trim());
    //            strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(105, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 105)).Trim());
    //            strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strProdDesc).Length <= 225)
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(55, 60).Trim());
    //            strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(105, 60).Trim());
    //            strFileData = strFileData.Replace("{PRODESC3}", clsStandards.filter(strProdDesc).Substring(165, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 165)).Trim());
    //            strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(55, 60).Trim());
    //            strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(105, 60).Trim());
    //            strFileData = strFileData.Replace("{PRODESC3}", clsStandards.filter(strProdDesc).Substring(165, 60).Trim());
    //            strFileData = strFileData.Replace("{PRODESC4}", clsStandards.filter(strProdDesc).Substring(225, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 225)).Trim());
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

   
    public static Boolean CheckConnection(string strIP, string strPort)
    {
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            clientSocket.NoDelay = true;
            IPAddress ip = IPAddress.Parse(strIP);
            int Port = int.Parse(strPort);
            IPEndPoint ipep = new IPEndPoint(ip, Port);
            var result = clientSocket.BeginConnect(new IPEndPoint(ip,Port), null, null);

            bool success = result.AsyncWaitHandle.WaitOne(200, true);
            if (success)
            {
                clientSocket.EndConnect(result);
                return true;
            }
            else
            {
                clientSocket.Close();
                return false;
                throw new SocketException(10060); // Connection timed out.
            }

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


    public static Boolean Print_DispenseRawLabel(string printerName, string strBarcode, string strMatCode, string strMatDescription,
                                                 string strMatBatch, string strMfgDate, string strExpiryDate, string strProcessOrder,
                                                 string strProdCode, string strProdBatch, string strProdDesc, decimal dGrosswt, decimal dNetwt,
                                                 decimal dTarewt, string strIssuedBy, string strIssueDate, string strUom, string strPlantName,
                                                 string strBatchSize, string strARNo, string strContainerNo, string strLotNo,string strIP,string strPort,string strExpType)
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

            if (strExpType == "1")
            {
                strFileData = ReadPrn("Dispensing.prn");
                strPrnFile = "Dispensing";
            }
            else if (strExpType == "2")
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
            else //if(strARNo.Substring(0, 1).Trim() == "G")
            {
                strFormatNo = objData.ExecuteScalarString(objData.strLocal, "SELECT FORMAT_NO FROM [TBL_PRINT_FORMAT] WHERE BLOCK = 'GB' AND PRN_FILE_NAME = '" + strPrnFile + "'");
            } 

            //strFileData = strFileData.Replace("{Plant}", strPlantName);
            strFileData = strFileData.Replace("{MaterialCode}", strMatCode);
            strFileData = strFileData.Replace("{MaterialName}", strMatDescription);
            strFileData = strFileData.Replace("{ProductName}", strProdDesc);
            strFileData = strFileData.Replace("{BatchNo}", strMatBatch);
            strFileData = strFileData.Replace("{BSize}", clsStandards.getDoubleToString(strBatchSize));
            strFileData = strFileData.Replace("{MfgDate}", strMfgDate);
            strFileData = strFileData.Replace("{ExpDate}", strExpiryDate);
            strFileData = strFileData.Replace("{ARNo}", strARNo);
            strFileData = strFileData.Replace("{ContNo}", strContainerNo);
            strFileData = strFileData.Replace("{LotNo}", strLotNo);
            if (Convert.ToString(dGrosswt) == "0.000")
            {
                strFileData = strFileData.Replace("{GrossWt}", "NA");
            }
            else
            {
                strFileData = strFileData.Replace("{GrossWt}", dGrosswt.ToString()+ " " + strUom);
            }
            if (Convert.ToString(dTarewt) == "0.000")
            {
                strFileData = strFileData.Replace("{TareWt}", "NA");
            }
            else
            {
                strFileData = strFileData.Replace("{TareWt}", dTarewt.ToString() + " " + strUom);
            }
            if (Convert.ToString(dNetwt) == "0.000")
            {
                strFileData = strFileData.Replace("{NetWt}", "NA");
            }
            else
            {
                if (strUom.ToUpper() == "NOS")
                {
                    strFileData = strFileData.Replace("{NetWt}", double.Parse(dNetwt.ToString()).ToString() + " " + strUom);
                }
                else
                {
                    strFileData = strFileData.Replace("{NetWt}", dNetwt.ToString() + " " + strUom);
                }
            }

            strFileData = strFileData.Replace("{BARCODE}", strBarcode.Trim());
            strFileData = strFileData.Replace("{FORMATNO}", strFormatNo.Trim());

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.NoDelay = true;
            IPAddress ip = IPAddress.Parse(strIP);
            IPEndPoint ipep = new IPEndPoint(ip, int.Parse(strPort));

            if (PrintDirect.CheckConnection(strIP, strPort) == true)
            {

                clientSocket.Connect(ipep);
            }
            else
            {
                return false;
            }

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
    //Dispensed packing label printing

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

    //public static Boolean Print_DispensePackingLabel(string printerName, string strBarcode, string strMatCode, string strMatDescription, string strMatBatch, string strGrade, string strNxtInspectionDate, string strSLED, string strProcessOrder, string strProdCode, string strProdBatch, string strProdDesc, string strStageDesc, string strProcessDesc, decimal dQty, string strIssuedBy, string strCheckedBy, string strIssueDate, string strCheckDate, string strUom, string strPlantName, string strLot)
    //{
    //    IntPtr lhPrinter = new IntPtr();
    //    DOCINFO Doc = new DOCINFO();
    //    int pcWritten = 0;
    //    string strFileData;
    //    Doc.pDocName = strMatCode;
    //    Doc.pDataType = "RAW";
    //    try
    //    {
    //        if (strProcessDesc == "")
    //        {
    //            strProcessDesc = " NA";
    //        }

    //        PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
    //        PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
    //        PrintDirect.StartPagePrinter(lhPrinter);
    //        strFileData = ReadPrn("CIPLAPACKDISP.prn");

    //        strFileData = strFileData.Replace("{Plant}", strPlantName);
    //        strFileData = strFileData.Replace("{ITEM}", strMatCode);
    //        strFileData = strFileData.Replace("{LOT}", strLot);
    //        if (clsStandards.filter(strMatDescription).Length <= 55)
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription.Trim()));
    //            strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strMatDescription).Length <= 105)
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(55, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 55)).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strMatDescription).Length <= 165)
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(55, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(105, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 105)).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strMatDescription).Length <= 225)
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(55, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(105, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strMatDescription).Substring(165, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 165)).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC4}", string.Empty);
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(strMatDescription).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(strMatDescription).Substring(55, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(strMatDescription).Substring(105, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(strMatDescription).Substring(165, 60).Trim());
    //            strFileData = strFileData.Replace("{ITEMDESC4}", clsStandards.filter(strMatDescription).Substring(225, Convert.ToInt32(clsStandards.filter(strMatDescription).Length - 225)).Trim());
    //        }

    //        strFileData = strFileData.Replace("{SAPBATCH}", strMatBatch.Trim());
    //        strFileData = strFileData.Replace("{QTYUOM}", Convert.ToString(dQty) + " " + strUom.Trim());


    //        strFileData = strFileData.Replace("{BARCODE}", strBarcode.Trim());

    //        strFileData = strFileData.Replace("{BATCH}", strProdBatch.Trim());
    //        if (strNxtInspectionDate.Trim() == "01/01/1900")
    //        {
    //            strFileData = strFileData.Replace("{NXTINSPDATE}", "NA");
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{NXTINSPDATE}", strNxtInspectionDate.Trim());
    //        }
    //        strFileData = strFileData.Replace("{GRADE}", strGrade.Trim());
    //        if (strSLED.Trim() == "01/01/1900")
    //        {
    //            strFileData = strFileData.Replace("{SLED}", "NA");
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{SLED}", strSLED.Trim());
    //        }

    //        strFileData = strFileData.Replace("{PONUM}", strProcessOrder.Trim());
    //        strFileData = strFileData.Replace("{ISSUEPROD}", strProdCode.Trim());

    //        strFileData = strFileData.Replace("{PROCDESC}", strProcessDesc.Trim());

    //        if (strStageDesc.Trim() != "")
    //        {
    //            strFileData = strFileData.Replace("{STGDESC}", "Dispensing of " + strStageDesc.Trim());
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{STGDESC}", "NA");
    //        }


    //        if (clsStandards.filter(strProdDesc).Length <= 55)
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc.Trim()));
    //            strFileData = strFileData.Replace("{PRODESC1}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC2}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strProdDesc).Length <= 105)
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(55, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 55)).Trim());
    //            strFileData = strFileData.Replace("{PRODESC2}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strProdDesc).Length <= 165)
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(55, 60).Trim());
    //            strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(105, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 105)).Trim());
    //            strFileData = strFileData.Replace("{PRODESC3}", string.Empty);
    //            strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
    //        }
    //        else if (clsStandards.filter(strProdDesc).Length <= 225)
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(55, 60).Trim());
    //            strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(105, 60).Trim());
    //            strFileData = strFileData.Replace("{PRODESC3}", clsStandards.filter(strProdDesc).Substring(165, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 165)).Trim());
    //            strFileData = strFileData.Replace("{PRODESC4}", string.Empty);
    //        }
    //        else
    //        {
    //            strFileData = strFileData.Replace("{PRODESC}", clsStandards.filter(strProdDesc).Substring(0, 55).Trim());
    //            strFileData = strFileData.Replace("{PRODESC1}", clsStandards.filter(strProdDesc).Substring(55, 60).Trim());
    //            strFileData = strFileData.Replace("{PRODESC2}", clsStandards.filter(strProdDesc).Substring(105, 60).Trim());
    //            strFileData = strFileData.Replace("{PRODESC3}", clsStandards.filter(strProdDesc).Substring(165, 60).Trim());
    //            strFileData = strFileData.Replace("{PRODESC4}", clsStandards.filter(strProdDesc).Substring(225, Convert.ToInt32(clsStandards.filter(strProdDesc).Length - 225)).Trim());
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

    //Material label without weight
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

    //Material label with weight

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


    //Container barcode label printing
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

   //In Process label printing
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

    //Code to Label Printing
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


                strFileData = strFileData.Replace("{PRINTBY}", strUserName + " / " + strPrintedDate);
                //strFileData = strFileData.Replace("{GRADE}", strUserName);





                if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 65)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()));
                    strFileData = strFileData.Replace("{ITEMDESC1}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 130)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 65).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(65, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 65)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 195)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 65).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(65, 130).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(130, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 195)).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length <= 260)
                {
                    strFileData = strFileData.Replace("{ITEMDESC}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(0, 65).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC1}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(65, 130).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC2}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(130, 195).Trim());
                    strFileData = strFileData.Replace("{ITEMDESC3}", clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Substring(195, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["MATDESC"].ToString().Trim()).Length - 260)).Trim());
                }

                if (clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length <= 65)
                {
                    strFileData = strFileData.Replace("{PRODUCTDESC}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()));
                    strFileData = strFileData.Replace("{PRODUCTDESC1}", string.Empty);
                    strFileData = strFileData.Replace("{PRODUCTDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{PRODUCTDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length <= 130)
                {
                    strFileData = strFileData.Replace("{PRODUCTDESC}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(0, 65).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC1}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(65, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length - 65)).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC2}", string.Empty);
                    strFileData = strFileData.Replace("{PRODUCTDESC3}", string.Empty);

                }
                else if (clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length <= 195)
                {
                    strFileData = strFileData.Replace("{PRODUCTDESC}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(0, 65).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC1}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(65, 130).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC2}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(130, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length - 195)).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC3}", string.Empty);
                }
                else if (clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length <= 236)
                {
                    strFileData = strFileData.Replace("{PRODUCTDESC}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(0, 65).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC1}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(65, 130).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC2}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(130, 195).Trim());
                    strFileData = strFileData.Replace("{PRODUCTDESC3}", clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Substring(195, Convert.ToInt32(clsStandards.filter(dt.Rows[i]["PRODUCTDESC"].ToString().Trim()).Length - 260)).Trim());
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
                strFileData = strFileData.Replace("{PLANT}", dt.Rows[i]["PLANTDESC"].ToString());
                strFileData = strFileData.Replace("{ITEM}", dt.Rows[i]["MatCode"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{RESNO}", dt.Rows[i]["ReservationNo"].ToString());
                strFileData = strFileData.Replace("{BATCHNO}", dt.Rows[i]["SAP_BatchNo"].ToString());
                strFileData = strFileData.Replace("{BARCODE}", dt.Rows[i]["BarcodeNo"].ToString());
                strFileData = strFileData.Replace("{GRADE}", dt.Rows[i]["GRADE"].ToString());
                strFileData = strFileData.Replace("{PRINTBY}", strPrintBy + " / " + strPrintOn);
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
                strFileData = strFileData.Replace("{PLANT}", dt.Rows[i]["PLANTCODE"].ToString() + "-" + dt.Rows[i]["PLANTDESC"].ToString());
                strFileData = strFileData.Replace("{GRADE}", dt.Rows[i]["GRADE"].ToString());
                strFileData = strFileData.Replace("{ITEM}", dt.Rows[i]["MatCode"].ToString().TrimStart('0'));
                strFileData = strFileData.Replace("{DOCNO}",dt.Rows[i]["MatDocNo"].ToString());
                strFileData = strFileData.Replace("{BATCHNO}", dt.Rows[i]["SAP_BatchNo"].ToString());
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

    public static Boolean PrintSampleLabel(string strMatName, string strMatCode, string strBatchNo, string strARNo, string strGRNNo, string strGRNDate, string strWT1, string strWT2, string strWT3, string strUser, string strDate, string strBarcode, string strIP, string strPort, string printerName, string strUOM, string strCount)
    {
        IntPtr lhPrinter = new IntPtr();
        DOCINFO Doc = new DOCINFO();
        int pcWritten = 0;
        string strFileData;
        Doc.pDocName = strMatCode;
        Doc.pDataType = "RAW";
        try
        {
            strFileData = ReadPrn("Sample.prn");

            PrintDirect.OpenPrinter(printerName, ref lhPrinter, 0);
            PrintDirect.StartDocPrinter(lhPrinter, 1, ref Doc);
            PrintDirect.StartPagePrinter(lhPrinter);

            strFileData = strFileData.Replace("{MaterialName}", strMatCode + " " + strMatName);
            strFileData = strFileData.Replace("{BatchNo}", strBatchNo);
            strFileData = strFileData.Replace("{ARNo}", strARNo);
            strFileData = strFileData.Replace("{GRNNo}", strGRNNo);
            strFileData = strFileData.Replace("{GRNDate}", strGRNDate);
            strFileData = strFileData.Replace("{PrintBy}", strUser);
            strFileData = strFileData.Replace("{PrintDate}", strDate);

            if (Convert.ToString(strWT1) == "0.000")
            {
                strFileData = strFileData.Replace("{WtA}", "NA")  ;
            }
            else
            {
                strFileData = strFileData.Replace("{WtA}", strWT1 + " " + strUOM.Trim());
            }
            if (Convert.ToString(strWT2) == "0.000")
            {
                strFileData = strFileData.Replace("{WtB}", "NA") ;
            }
            else
            {
                strFileData = strFileData.Replace("{WtB}", strWT2 + " " + strUOM.Trim());
            }
            if (Convert.ToString(strWT3) == "0.000")
            {
                strFileData = strFileData.Replace("{WtC}", "NA");
            }
            else
            {
                strFileData = strFileData.Replace("{WtC}", strWT3 +" " + strUOM.Trim());
            }

            strFileData = strFileData.Replace("{BARCODE}", strBarcode.Trim());
            strFileData = strFileData.Replace("{COUNT}", strCount.Trim());

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.NoDelay = true;
            IPAddress ip = IPAddress.Parse(strIP);
            IPEndPoint ipep = new IPEndPoint(ip, int.Parse(strPort));

            if (PrintDirect.CheckConnection(strIP, strPort) == true)
            {

                clientSocket.Connect(ipep);
            }
            else
            {
                return false;
            }

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

