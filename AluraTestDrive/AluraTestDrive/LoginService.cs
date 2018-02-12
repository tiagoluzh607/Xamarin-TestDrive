using AluraTestDrive.Exceptions;
using AluraTestDrive.Models;
using Newtonsoft.Json;
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
                //Prepara o Post
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", login.email),
                    new KeyValuePair<string, string>("senha", login.senha)
                });

                cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");

                HttpResponseMessage resposta = null;

                try
                {
                    //Faz o Post e Obtem a Resposta
                    resposta = await cliente.PostAsync("/login", camposFormulario);
                }catch (Exception){
                    MessagingCenter.Send<LoginException>(new LoginException("Ocorreu um erro de Comunicação com o Servidor.\n\n Por favor verifique sua conexão e tente mais tarde "), "FalhaLogin");
                }

                //Testa a resposta
                if (resposta.IsSuccessStatusCode)
                {
                    //pega usuario da resposta do servidor
                    var respostaString = await resposta.Content.ReadAsStringAsync();
                    UsuarioJson usuarioJson = JsonConvert.DeserializeObject<UsuarioJson>(respostaString);

                    Usuario usuario = usuarioJson.usuario;
                    //passa usuario como parametro
                    MessagingCenter.Send<Usuario>(usuario, "SucessoLogin"); // quem implenta é App.xaml.cs justo para fazer a troca da mainpage e navegação
                }else{
                    MessagingCenter.Send<LoginException>(new LoginException("Usuário ou senha Incorretos"), "FalhaLogin");
                }
            }
        }
    }
}
