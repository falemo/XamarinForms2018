using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}
        private void GoActividetyIndicatorPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage( new Controles.ActivityIndicatorPage());
            IsPresented = false;

        }
        private void GoProgressBarPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.ProgressBarPage());
            IsPresented = false;

        }
        private void GoBoxViewPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.BoxViewPage());
            IsPresented = false;

        }
        private void GoLabelPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.LabelPage());
            IsPresented = false;

        }
        private void GoButtonPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.ButtonPage());
            IsPresented = false;

        }
        private void GoEntryEditorPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.EntryEditorPage());
            IsPresented = false;

        }
        private void GoDatePikerPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.DatePikerPage());
            IsPresented = false;

        }
        private void GoTimePikerPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.TimePikerPage());
            IsPresented = false;

        }
        private void GoPikerPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.PickerPage());
            IsPresented = false;

        }
        private void GoSearchBarPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.SearchBarPage());
            IsPresented = false;

        }
        private void GoSliderStepperPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.SliderStepperPage());
            IsPresented = false;

        }
        private void GoSwicthPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.SwicthPage());
            IsPresented = false;

        }
        private void GoImagePage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.ImagePage());
            IsPresented = false;

        }
        private void GoListViewPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.ListViewPage());
            IsPresented = false;

        }
        private void GoTableViewPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.TableViewPage());
            IsPresented = false;

        }
        private void GoWebViewPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Controles.WebViewPage());
            IsPresented = false;

        }
        



    }
}