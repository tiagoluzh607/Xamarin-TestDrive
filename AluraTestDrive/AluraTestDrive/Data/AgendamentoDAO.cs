using AluraTestDrive.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AluraTestDrive.Data
{
    class AgendamentoDAO
    {
        readonly SQLiteConnection conexao;

        public AgendamentoDAO(SQLiteConnection conexao)
        {
            this.conexao = conexao;
            this.conexao.CreateTable<AgendamentoBD>();
        }

        public void Salvar(Agendamento agendamento) {

            AgendamentoBD agendamentoBD = agendamento.GetAgendamentoDB();
            conexao.Insert(agendamentoBD);
        }
    }
}
