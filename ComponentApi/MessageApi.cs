using System;
using System.Globalization;
using System.IO;
using System.Net.Sockets;

namespace ComponentApi
{
    public class MessageApi
    {
        public string Greet()
        {
            string greeting = GetDateTimeMessageFromService();
            return greeting;
        }

        private string GetDateTimeMessageFromService()
        {
            var client = new TcpClient("time.nist.gov", 13);
            var localDateTimeString = string.Empty;
            using (var streamReader = new StreamReader(client.GetStream()))
            {
                var response = streamReader.ReadToEnd();
                var utcDateTimeString = response.Substring(7, 17);
                var localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture,DateTimeStyles.AssumeUniversal);
                localDateTimeString = (localDateTime.ToLongDateString() + " " + localDateTime.ToLongTimeString());
            }
            return localDateTimeString;
        }
    }
}
