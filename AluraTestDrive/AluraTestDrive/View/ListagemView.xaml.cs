using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AluraTestDrive.View
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado
        {
            get { return "R$ " + this.Preco; }
        }
    }

	public partial class ListagemView : ContentPage
	{

        public List<Veiculo> Veiculos { get; set; }

		public ListagemView()
		{
			InitializeComponent();

            this.Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azera V6", Preco = 60000},
                new Veiculo { Nome = "Fiesta 2.0", Preco = 50000},
                new Veiculo { Nome = "HB20 S", Preco = 40000}
            };

            this.BindingContext = this; // fazer com que a classe xaml, veja a lista de Veiculos
		}

        private void listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Veiculo veiculo = (Veiculo)e.Item;
            Navigation.PushAsync(new DetalheView(veiculo));

        }

    }
}
