using AluraTestDrive.Models;
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

        public bool TemFreioAbs
        {
            get { return veiculo.TemFreioAbs; }
            set
            {
                veiculo.TemFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal)); // Atualiza a propriedade ValorTotal faz a pagina chamar novamente o get da propriedade
            }
        }
        public bool TemArCondicionado
        {
            get { return veiculo.TemArCondicionado; }
            set
            {
                veiculo.TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal)); // Atualiza a propriedade ValorTotal faz a pagina chamar novamente o get da propriedade
            }
        }
        public bool TemMp3Player
        {
            get { return veiculo.TemMp3Player; }
            set
            {
                veiculo.TemMp3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal)); // Atualiza a propriedade ValorTotal faz a pagina chamar novamente o get da propriedade
            }
        }

        public Veiculo veiculo { get; set; }

        public string textoFreioAbs
        {
            get { return string.Format("Freio ABS  R$ {0}", Veiculo.FREIO_ABS); }
        }
        public string textoArCondicionado
        {
            get { return string.Format("Ar Condicionado  R$ {0}", Veiculo.AR_CONDICIONADO); }
        }
        public string textoMp3Player
        {
            get { return string.Format("MP3 Player  R$ {0}", Veiculo.MP3_PLAYER); }
        }



        public string ValorTotal
        {
            get {
                return veiculo.PrecoTotalFormatado;
            }
        }

        public DetalheView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.veiculo = veiculo;

            this.BindingContext = this; // para poder acessar as propriedades no view
		}


        private void buttonProximo_Clicked(object send, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.veiculo));
        }



    }
}