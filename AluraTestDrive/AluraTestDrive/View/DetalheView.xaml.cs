using AluraTestDrive.Models;
using AluraTestDrive.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluraTestDrive.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheView : ContentPage
	{

        private Veiculo veiculo { get; set; }

        public DetalheView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.veiculo = veiculo;
            this.BindingContext = new DetalheViewModel(veiculo); // para poder acessar as propriedades no view
		}


        private void buttonProximo_Clicked(object send, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.veiculo));
        }



    }
}