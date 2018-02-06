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

        /* 
        * Escrevendo Ações das Mensagens 
        */
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo", (msg) => {
                Navigation.PushAsync(new AgendamentoView(msg));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }


    }
}