﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Cell.Modelo;

namespace App1_Cell.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TextCellPage : ContentPage
	{
		public TextCellPage ()
		{
			InitializeComponent ();
            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Cargo = "Gerente TI", Nome = "Pedro" });
            Lista.Add(new Funcionario() { Cargo = "Analista TI", Nome = "Joaquim" });
            Lista.Add(new Funcionario() { Cargo = "Programador TI", Nome = "Tereza" });
            Lista.Add(new Funcionario() { Cargo = "Dono TI", Nome = "Elaine" });
            Lista.Add(new Funcionario() { Cargo = "Presidente TI", Nome = "Guilherme" });
            Lista.Add(new Funcionario() { Cargo = "Entregador TI", Nome = "Madre" });

            ListaFuncionario.ItemsSource = Lista;   

        }
    }
}