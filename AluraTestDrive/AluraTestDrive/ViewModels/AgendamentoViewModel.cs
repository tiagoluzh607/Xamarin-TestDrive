using AluraTestDrive.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluraTestDrive.ViewModels
{
    public class AgendamentoViewModel
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

        public string Nome { get { return agendamento.Nome; } set { agendamento.Nome = value; } }
        public string Fone { get { return agendamento.Fone; } set { agendamento.Fone = value; } }
        public string Email { get { return agendamento.Email; } set { agendamento.Email = value; } }

        //Commands

        public ICommand AgendarCommand { get; set; }
        public void Agendar()
        {
            string mensagem = string.Format(
            @"Veiculo: {0} 
            Nome: {1}
            Fone: {2}
            E-mail: {3}
            Data Agendamento: {4}
            Hora Agendamento: {5}",
            agendamento.Veiculo.Nome , 
            agendamento.Nome, 
            agendamento.Fone, 
            agendamento.Email, 
            agendamento.DataAgendamento.ToString("dd/MM/yyyy"), 
            agendamento.HoraAgendamento);

            MessagingCenter.Send(mensagem, "DisplayAlert");
        }

        public AgendamentoViewModel(Veiculo veiculo)
        {
            agendamento = new Agendamento();
            this.agendamento.Veiculo = veiculo;
            this.AgendarCommand = new Command(Agendar);
        }

        public DateTime DataAgendamento
        {
            get { return agendamento.DataAgendamento; }
            set { agendamento.DataAgendamento = value; }
        }

        public TimeSpan HoraAgendamento { get { return agendamento.HoraAgendamento; } set { agendamento.HoraAgendamento = value; } }

    }
}
