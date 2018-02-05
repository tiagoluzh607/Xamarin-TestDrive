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

        public Veiculo veiculo { get; set; }

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

        public AgendamentoView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.veiculo = veiculo;
            this.BindingContext = this;
            
		}

        private void Button_Agendar_Clicked(object sender, EventArgs e)
        {
            string conteudo = string.Format(
            @"Nome: {0}
            Fone: {1}
            E-mail: {2}
            Data Agendamento: {3}
            Hora Agendamento: {4}",
            Nome, Fone, Email, dataAgendamento.ToString("dd/MM/yyyy"), HoraAgendamento);

            DisplayAlert("Agendamento Concluído", conteudo, "OK");
        }

	}
}