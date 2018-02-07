using AluraTestDrive.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AluraTestDrive.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";

        //Tipo observablecollection avisa a view quando a lista atualiza automaticamente
        public ObservableCollection<Veiculo> Veiculos { get; set; }

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

        private bool aguarde;

        public bool Aguarde
        {
            get { return aguarde; }
            set {
                    aguarde = value;
                    OnPropertyChanged();
                }
        }


        public ListagemViewModel()
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
        }

        public async Task GetVeiculosAsync()
        {
            Aguarde = true; //Componente aguardar rodando

            HttpClient cliente = new HttpClient();
            var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);

            var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

            foreach (var veiculoJson in veiculosJson)
            {
                this.Veiculos.Add(new Veiculo()
                {
                    Nome = veiculoJson.nome,
                    Preco = veiculoJson.preco
                });
            }

            Aguarde = false; // Desligando componente aguardar
        }

    }
}
