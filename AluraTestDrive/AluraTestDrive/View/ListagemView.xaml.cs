using AluraTestDrive.Models;
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
		public ListagemView()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            //Rebendo a mensagem do ViewModel e Fazendo a Navegação
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", (msg) => {
                Navigation.PushAsync(new DetalheView(msg));
            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }

    }
}
