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
        private const int FREIO_ABS = 800;
        private const int AR_CONDICIONADO = 1000;
        private const int MP3_PLAYER = 500;

        private bool temFreioAbs;
        public bool TemFreioAbs
        {
            get { return temFreioAbs; }
            set
            {
                temFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal)); // Atualiza a propriedade ValorTotal faz a pagina chamar novamente o get da propriedade
            }
        }

        private bool temArCondicionado;
        public bool TemArCondicionado
        {
            get { return temArCondicionado; }
            set
            {
                temArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal)); // Atualiza a propriedade ValorTotal faz a pagina chamar novamente o get da propriedade
            }
        }

        private bool temMp3Player;
        public bool TemMp3Player
        {
            get { return temMp3Player; }
            set
            {
                temMp3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal)); // Atualiza a propriedade ValorTotal faz a pagina chamar novamente o get da propriedade
            }
        }

        public Veiculo veiculo { get; set; }

        public string textoFreioAbs
        {
            get { return string.Format("Freio ABS  R$ {0}", FREIO_ABS); }
        }
        public string textoArCondicionado
        {
            get { return string.Format("Ar Condicionado  R$ {0}", AR_CONDICIONADO); }
        }
        public string textoMp3Player
        {
            get { return string.Format("MP3 Player  R$ {0}", MP3_PLAYER); }
        }



        public string ValorTotal
        {
            get { return string.Format("Valor Total: R$ {0}", veiculo.Preco 
                
                        + (temFreioAbs ? FREIO_ABS: 0)
                        + (temArCondicionado ? AR_CONDICIONADO : 0 )
                        + (temMp3Player ? MP3_PLAYER : 0)
                    );
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