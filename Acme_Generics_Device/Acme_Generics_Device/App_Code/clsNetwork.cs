using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

/// <summary>
/// Summary description for clsNetwork
/// </summary>
public class clsNetwork
{
    static TcpClient client;
    static bool IS_CONNECTED = false;
    public static int iPort = 5150;
    //public static int iPort = 5100;

    public static string fnSendReceiveData(string strData)
    {
        client = new TcpClient();
        string Response = string.Empty;
        try
        {
            //clsSetting.strServerIP = "192.168.43.130";
            //clsSetting.strServerIP = "192.168.1.221";
            // client.Connect("192.168.0.142", 5150);
            client.Connect("192.168.1.65", 5150);
            IS_CONNECTED = true;
            byte[] bData = Encoding.ASCII.GetBytes(strData);
            client.Client.Send(bData);
            // Application.DoEvents();
            byte[] bRes = new byte[50000];
            int iLen = client.Client.Receive(bRes);
            Response = Encoding.ASCII.GetString(bRes, 0, iLen);
            string sReturn = "";
            while (!Response.EndsWith("}"))
            {
                sReturn += Response;
                byte[] bRes2 = new byte[50000];
                int iLen2 = client.Client.Receive(bRes2);
                Response = Encoding.ASCII.GetString(bRes2, 0, iLen2);

                if (Response.EndsWith("}"))
                {
                    Response = Response.Replace("}", "");
                    //sReturn += Response;
                    break;
                }

            }
            Response = Response.Replace("}", "");
            sReturn += Response;
            Response = sReturn;
            client.Client.Send(Encoding.ASCII.GetBytes("quit}"));
            client.Close();
        }
        catch (Exception ex)
        {
            if (IS_CONNECTED)
                client.Close();
            Response = "NO_CONNECTION";
        }
        finally
        { client = null; }
        return Response;
    }

}
