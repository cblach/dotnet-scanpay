using System;
using Scanpay;

namespace NewURLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client("1089:bx2a4DATi8ad87Nm4uaxg5nggYA8J/Hv99CON977YiEdvYa6DmMwdoRPoYWyBJSi");
            var data = new Client.NewURLReq
            {
                orderid     = "999",
                language    = "",
                successurl  = "https://example.com",
                autocapture = false,
                items = new Client.Item[]
                {
                    new Client.Item
                    {
                        name     = "Ultra Bike 7000",
                        price    = "1337.01 DKK",
                        quantity = 2,
                        sku      = "ff123",
                    },
                    new Client.Item
                    {
                      name      = "巨人宏偉的帽子",
                      price     = "420 DKK",
                      quantity  = 2,
                      sku       = "124",
                    }
                },
                billing = new Client.Billing
                {
                    name    = "Hans Jensen",
                    company = "HJ Planteskole ApS",
                    email   = "hans@hjplanter.dk",
                    phone   = "+45 12345678",
                    address = new string[]
                    {
                        "Grønnegade 5, st. th",
                        "C/O Hans Jensen",
                    },
                    city    = "Børum",
                    zip     = "1234",
                    country = "DK",
                    vatin   = "DK12345678",
                    gln     = "",
                },
                shipping = new Client.Shipping
                {
                    name    = "John Hanson",
                    company = "HJ Planteskole ApS",
                    email   = "john@hjplanter.dk",
                    phone   = "+45 12345679",
                    address = new string[]
                    {
                        "Gryngade 90",
                        "C/O John Hanson",
                    },
                    city    = "Ørum",
                    zip     = "1235",
                    country = "DK",
                },
            };
            var opts = new Client.Options
            {
                hostname = "api.test.scanpay.dk",
            };
            var url = client.newURL(data, opts);
            Console.WriteLine("Payment URL is:" + url);
        }
    }
}