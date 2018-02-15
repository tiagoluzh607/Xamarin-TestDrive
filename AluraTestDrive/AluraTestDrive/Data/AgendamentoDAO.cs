using AluraTestDrive.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluraTestDrive.Data
{
    class AgendamentoDAO
    {
        readonly SQLiteConnection conexao;

        private List<Agendamento> list;

        public List<Agendamento> Lista
        {
            get { //Precisamos Converter a lista AgendamentoBD em Agendamento 

                List<AgendamentoBD> agendamentosBD = conexao.Table<AgendamentoBD>().ToList(); // o model precisar ter um construtor sem parametros
                List<Agendamento> agendamentos = new List<Agendamento>();
                agendamentos.Clear();

                foreach (var agendamentoBD in agendamentosBD)
                {
                    agendamentos.Add(agendamentoBD.GetAgendamento());
                }
                
                return agendamentos;
            }
            set { list = value; }
        }


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
