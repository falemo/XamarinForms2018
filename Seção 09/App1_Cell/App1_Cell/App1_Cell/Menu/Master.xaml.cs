using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Cell.Paginas;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Cell.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
    {
		public Master ()
		{
			InitializeComponent ();
		}
        public void GoPagina1(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new TextCellPage());
            IsPresented = false;
        }
        public void GoPagina2(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new ImageCellPage());
            IsPresented = false;
        }
        public void GoPagina3(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new EntryCellPage());
            IsPresented = false;
        }
        public void GoPagina4(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new SwichtCellPage());
            IsPresented = false;
        }
        public void GoPagina5(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new ViewCellPage());
            IsPresented = false;
        }

        public void GoPagina6(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new ListViewPage());
            IsPresented = false;
        }
        public void GoPagina7(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new ListViewButtonPage());
            IsPresented = false;
        }





    }
}