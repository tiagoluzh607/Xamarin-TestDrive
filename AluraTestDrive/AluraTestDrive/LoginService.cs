﻿using AluraTestDrive.Exceptions;
using AluraTestDrive.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AluraTestDrive
{
    public class LoginService
    {
        public async Task LogarAsync(Login login)
        {

            using (var cliente = new HttpClient())
            {
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", login.email),
                    new KeyValuePair<string, string>("senha", login.senha)
                });

                cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                var resposta = await cliente.PostAsync("/login", camposFormulario);

                if (resposta.IsSuccessStatusCode)
                {
                    MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin"); // quem implenta é App.xaml.cs justo para fazer a troca da mainpage e navegação
                }
                else
                {
                    MessagingCenter.Send<LoginException>(new LoginException("Usuário ou senha Incorretos"), "FalhaLogin");
                }


            }
        }
    }
}