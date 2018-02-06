using AluraTestDrive.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AluraTestDrive.ViewModels
{
    public class DetalheViewModel : INotifyPropertyChanged
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


        public DetalheViewModel(Veiculo veiculo)
        {
            this.veiculo = veiculo;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //Simplesmente usa o nome do metódoto para chamar o sistema de notificação que foi recebido pela interface
        //Ao ser chamado ele avisa o xamarin que um elemento da tela precisa ser atualizado
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
