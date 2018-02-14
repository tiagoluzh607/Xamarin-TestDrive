﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AluraTestDrive.Models
{
    public class Agendamento
    {
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }


        private DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento
        {
            get { return dataAgendamento; }
            set { dataAgendamento = value; }
        }
        public TimeSpan HoraAgendamento { get; set; }



        public AgendamentoBD GetAgendamentoDB()
        {
            AgendamentoBD agendamentoBD = new AgendamentoBD(Nome, Fone, Email, Veiculo.Nome, Veiculo.Preco, DataAgendamento, HoraAgendamento);
            return agendamentoBD;
        }




    }


}
