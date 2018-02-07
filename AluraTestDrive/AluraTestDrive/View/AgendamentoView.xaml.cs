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

        /* Comands */

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<AgendamentoViewModel>(this, "Agendar", async (msg) => {

                bool confirma = await DisplayAlert("Confirmar Agendamento?", "Deseja mesmo Confirmar o agendamento?", "Sim", "Não");

                if (confirma)
                {
                    ViewModel.SalvaAgendamentoAsync();
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", (msg) => {
                DisplayAlert("Agendamento", "Agendamento salvo com sucesso!", "Ok");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", (msg) => {
                DisplayAlert("Agendamento", "Que Constrangedor! Erro ao Agendar o Teste Drive, confira os dados e teste mais tarde!\n\n\n Erro: "+msg.Message, "Ok");
            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<object>(this, "DisplayAlert");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "FalhaAgendamento");
        }

    }
}