using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Travel.Connectors.Hotel.Common.Utilities
{
    public static class CommonUtility
    {
        public static string GetIPAddress()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect(ApplicationConstants.GetIpHost, ApplicationConstants.GetIpPort);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
                return localIP;
            }
        }

        public static string ConvertObjectToJson(object typeInstance)
        {
            string jsonString = string.Empty;
            if (typeInstance !=null)
                jsonString = JsonConvert.SerializeObject(typeInstance);
            return jsonString;
        }

    }
}
