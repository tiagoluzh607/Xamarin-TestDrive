using AluraTestDrive.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluraTestDrive.ViewModels
{
    public class DetalheViewModel : BaseViewModel
    {
        public Veiculo veiculo { get; set; }

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
            get
            {
                return veiculo.PrecoTotalFormatado;
            }
        }

        //Comands

        public ICommand ProximoCommand { get; set; }
        public void proximaPagina()
        {
            MessagingCenter.Send(veiculo, "Proximo");
        }

        public DetalheViewModel(Veiculo veiculo)
        {
            this.veiculo = veiculo;
            ProximoCommand = new Command(proximaPagina);
        }


    }
}
