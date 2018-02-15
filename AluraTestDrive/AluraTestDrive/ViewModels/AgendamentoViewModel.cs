using AluraTestDrive.Data;
using AluraTestDrive.Models;
using AluraTestDrive.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluraTestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        

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
            AgendamentoService agendamentoService = new AgendamentoService();
            await agendamentoService.EnviarAgendamento(this.agendamento);
        }


    }

}
