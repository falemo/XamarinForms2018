﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SwicthPage : ContentPage
	{
		public SwicthPage ()
		{
			InitializeComponent ();
		}

        private void ActionTrocou (object sender, ToggledEventArgs args)
        {
            lblResultado.Text = DateTime.Now.ToString() + " - " + args.Value.ToString();

        }
    }
}