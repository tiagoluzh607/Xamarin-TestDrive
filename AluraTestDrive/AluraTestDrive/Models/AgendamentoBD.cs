﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AluraTestDrive.Models
{
    public class AgendamentoBD
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }


        private DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento
        {
            get { return dataAgendamento; }
            set { dataAgendamento = value; }
        }
        public TimeSpan HoraAgendamento { get; set; }

        public AgendamentoBD(string nome, string fone, string email, string modelo, decimal preco ,DateTime dataAgendamento, TimeSpan horaAgendamento)
        {
            this.Nome = nome;
            this.Fone = fone;
            this.Email = email;
            this.Modelo = modelo;
            this.Preco = preco;
            this.DataAgendamento = dataAgendamento;
            this.HoraAgendamento = horaAgendamento;
        }
    }
}