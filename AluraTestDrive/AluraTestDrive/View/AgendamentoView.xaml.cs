using AluraTestDrive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluraTestDrive.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoView : ContentPage
	{
        public Agendamento agendamento { get; set; }

        public Veiculo Veiculo {
            get {
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

        public DateTime DataAgendamento
        {
            get { return agendamento.DataAgendamento; }
            set { agendamento.DataAgendamento = value; }
        }

        public TimeSpan HoraAgendamento { get { return agendamento.HoraAgendamento; } set { agendamento.HoraAgendamento = value; } }

        public AgendamentoView (Veiculo veiculo)
		{
			InitializeComponent ();
            agendamento = new Agendamento();
            this.agendamento.Veiculo = veiculo;
            this.BindingContext = this;
            
		}

        private void Button_Agendar_Clicked(object sender, EventArgs e)
        {
            string conteudo = string.Format(
            @"Veiculo: {0} 
            Nome: {1}
            Fone: {2}
            E-mail: {3}
            Data Agendamento: {4}
            Hora Agendamento: {5}",
            Veiculo.Nome ,Nome, Fone, Email, DataAgendamento.ToString("dd/MM/yyyy"), HoraAgendamento);

            DisplayAlert("Agendamento Concluído", conteudo, "OK");
        }

	}
}