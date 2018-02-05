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

        public List<Veiculo> Veiculos { get; set; }

		public ListagemView()
		{
			InitializeComponent();
            this.Veiculos = new ListagemVeiculos().Veiculos;
            this.BindingContext = this; // fazer com que a classe xaml, veja a lista de Veiculos
		}

        private void listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Veiculo veiculo = (Veiculo)e.Item;
            Navigation.PushAsync(new DetalheView(veiculo));

        }

    }
}
