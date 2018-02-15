using AluraTestDrive.Data;
using AluraTestDrive.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluraTestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        private const string URL_POST_AGENDAMENTO = "http://aluracar.herokuapp.com/salvaragendamento";

        public Agendamento agendamento { get; set; }

        public Veiculo Veiculo
        {
            get
            {
                return agendamento.Veiculo;
            }
            set
            {
                agendamento.Veiculo = value;
            }
        }

        public string Nome {
            get { return agendamento.Nome; }
            set {
                agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }

        public string Fone {
            get { return agendamento.Fone; }
            set {
                agendamento.Fone = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }

        public string Email {
            get { return agendamento.Email; }
            set {
                agendamento.Email = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }

        public DateTime DataAgendamento
        {
            get { return agendamento.DataAgendamento; }
            set { agendamento.DataAgendamento = value; }
        }
        public TimeSpan HoraAgendamento { get { return agendamento.HoraAgendamento; } set { agendamento.HoraAgendamento = value; } }

        //Commands

        public ICommand AgendarCommand { get; set; }
        public void Agendar()
        {
            MessagingCenter.Send(this, "Agendar");
        }
        public bool AgendarCondicao()
        {
            return
                !string.IsNullOrEmpty(this.Nome) &&
                !string.IsNullOrEmpty(this.Fone) &&
                !string.IsNullOrEmpty(this.Email);
        }

       
        //Construtor
        public AgendamentoViewModel(Veiculo veiculo)
        {
            agendamento = new Agendamento();
            this.agendamento.Veiculo = veiculo;
            this.AgendarCommand = new Command(Agendar,AgendarCondicao);
        }

        //Métodos

        public async void SalvaAgendamentoAsync()
        {
            HttpClient cliente = new HttpClient();

            var dataHoraAgendamento = new DateTime(
                DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds
                );

            var json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Fone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
            var resposta = await cliente.PostAsync(URL_POST_AGENDAMENTO, conteudo);

            //verifica se foi enviado corretamente ao servidor
            this.agendamento.Confirmado = resposta.IsSuccessStatusCode;


            //SQLite salvar localmente

            SalvarAgendamentoDB();


            //Envia para o servidor
            if (this.agendamento.Confirmado)
            {
                MessagingCenter.Send<Agendamento>(this.agendamento, "SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
            }
        }

        private void SalvarAgendamentoDB()
        {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conexao);
                dao.Salvar(this.agendamento);
            }
        }
    }
}
