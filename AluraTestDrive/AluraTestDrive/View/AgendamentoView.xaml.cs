using AluraTestDrive.Models;
using AluraTestDrive.ViewModels;
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
        public AgendamentoViewModel ViewModel { get; set; }

        public AgendamentoView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.ViewModel;


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
            ViewModel.agendamento.Veiculo.Nome , 
            ViewModel.agendamento.Nome, 
            ViewModel.agendamento.Fone, 
            ViewModel.agendamento.Email, 
            ViewModel.agendamento.DataAgendamento.ToString("dd/MM/yyyy"), 
            ViewModel.agendamento.HoraAgendamento);

            DisplayAlert("Agendamento Concluído", conteudo, "OK");
        }

	}
}