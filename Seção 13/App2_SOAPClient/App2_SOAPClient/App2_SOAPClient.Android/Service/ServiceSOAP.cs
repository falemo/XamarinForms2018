using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(App2_SOAPClient.Droid.Service.ServiceSOAP))]

namespace App2_SOAPClient.Droid.Service
{
    public class ServiceSOAP: IServiceSOAP
    {
        public string somar(int num1, int num2)
        {
            var serve = new com.dneonline.www.Calculator();
            int resultado = serve.Add(num1, num2);
            return "Resultado WS SOAP (Android):" + resultado.ToString();
        }

    }
}