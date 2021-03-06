﻿using AluraTestDrive.Models;
using AluraTestDrive.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AluraTestDrive
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new LoginView();
		}

		protected override void OnStart ()
		{
            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin", (usuario) => {

                //MainPage = new NavigationPage(new ListagemView());
                MainPage = new MasterDetailView(usuario);
            });
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
