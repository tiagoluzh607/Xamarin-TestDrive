using AluraTestDrive.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

        public AgendamentoViewModel(Veiculo veiculo)
        {
            agendamento = new Agendamento();
            this.agendamento.Veiculo = veiculo;
        }

        public DateTime DataAgendamento
        {
            get { return agendamento.DataAgendamento; }
            set { agendamento.DataAgendamento = value; }
        }

        public TimeSpan HoraAgendamento { get { return agendamento.HoraAgendamento; } set { agendamento.HoraAgendamento = value; } }
    }
}
