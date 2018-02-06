﻿using AluraTestDrive.Models;
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

            MessagingCenter.Subscribe<string>(this, "DisplayAlert", (msg) => {
                DisplayAlert("Agendamento Concluído", msg, "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<string>(this, "DisplayAlert");
        }

    }
}