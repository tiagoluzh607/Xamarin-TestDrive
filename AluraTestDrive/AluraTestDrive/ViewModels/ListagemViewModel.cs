using AluraTestDrive.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AluraTestDrive.ViewModels
{
    public class ListagemViewModel
    {
        public List<Veiculo> Veiculos { get; set; }

        private Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado {
            get {
                return veiculoSelecionado;
            }

            set {
                veiculoSelecionado = value;
                if (veiculoSelecionado != null) {
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
                }
            }
        }

        public ListagemViewModel()
        {
            this.Veiculos = new ListagemVeiculos().Veiculos;
        }
    }
}
