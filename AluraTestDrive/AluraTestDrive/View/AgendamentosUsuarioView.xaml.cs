using AluraTestDrive.Converters;
using AluraTestDrive.Models;
using AluraTestDrive.Services;
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
	public partial class AgendamentosUsuarioView : ContentPage
	{
        readonly AgendamentosUsuarioViewModel viewModel;

        public AgendamentosUsuarioView ()
		{
			InitializeComponent ();
            viewModel = new AgendamentosUsuarioViewModel();
            this.BindingContext = viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoSelecionado", async (agendamento) => {

                if (!agendamento.Confirmado)
                {
                    bool reenviar = await DisplayAlert("Reenviar", "Deseja Reenviar o Agendamento?", "Sim", "Não");
                    if (reenviar)
                    {
                        AgendamentoService agendamentoService = new AgendamentoService();
                        await agendamentoService.EnviarAgendamento(agendamento);
                        
                    }
                }

                this.viewModel.AtualizarLista();
                
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", async (agendamento) => {

                await DisplayAlert("Reenviar", "Reenvio com sucesso!", "Ok");
            });

            MessagingCenter.Subscribe<Agendamento>(this, "FalhaAgendamento", async (agendamento) => {

                await DisplayAlert("Reenviar", "Falha ao Reenviar!", "Ok");
            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoSelecionado");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "FalhaAgendamento");
        }
    }
}