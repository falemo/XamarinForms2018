using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(App2_SOAPClient.iOS.Service.ServiceSOAP))]

namespace App2_SOAPClient.iOS.Service
{
    public class ServiceSOAP: IServiceSOAP
    {
        public string somar(int num1, int num2)
        {
            var serve = new com.dneonline.www.Calculator();
            int resultado = serve.Add(num1, num2);
            return "Resultado WS SOAP (IOS):" + resultado.ToString();
        }
    }
}