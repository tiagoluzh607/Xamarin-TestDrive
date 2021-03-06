﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AluraTestDrive.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public bool Confirmado { get; set; }

        private DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento
        {
            get { return dataAgendamento; }
            set { dataAgendamento = value; }
        }
        public TimeSpan HoraAgendamento { get; set; }

        public string DataFormatada
        {
            get{
                return DataAgendamento.Add(HoraAgendamento).ToString("dd/MM/yyyy HH:mm"); 
            }
        }



        public AgendamentoBD GetAgendamentoDB()
        {
            AgendamentoBD agendamentoBD = new AgendamentoBD(Id, Nome, Fone, Email, Veiculo.Nome, Veiculo.Preco, DataAgendamento, HoraAgendamento);
            agendamentoBD.Confirmado = this.Confirmado;
            return agendamentoBD;
        }

        public Agendamento()
        {

        }

        public Agendamento(string nome, string fone, string email, string modelo, decimal preco)
            :this()
        {
            this.Nome = nome;
            this.Fone = fone;
            this.Email = email;

            this.Veiculo = new Veiculo();
            this.Veiculo.Nome = modelo;
            this.Veiculo.Preco = preco;
        }

        public Agendamento(int id, string nome, string fone, string email, string modelo, decimal preco, DateTime dataAgendamento, TimeSpan horaAgendamento)
            : this(nome,fone,email,modelo,preco)
        {
            this.Id = id;
            this.DataAgendamento = dataAgendamento;
            this.HoraAgendamento = horaAgendamento;
        }


    }


}
