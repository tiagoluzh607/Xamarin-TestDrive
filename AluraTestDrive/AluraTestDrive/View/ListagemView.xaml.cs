using AluraTestDrive.Models;
using AluraTestDrive.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AluraTestDrive.View
{
	public partial class ListagemView : ContentPage
	{

        public ListagemViewModel ViewModel { get; set; }

		public ListagemView()
		{
			InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.BindingContext = this.ViewModel;
		}

        protected async override void OnAppearing()
        {
            //Rebendo a mensagem do ViewModel e Fazendo a Navegação
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", (msg) => {
                Navigation.PushAsync(new DetalheView(msg));
            });

            //Acionando a Busca de veiculos

            await this.ViewModel.GetVeiculosAsync();

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }

    }
}
