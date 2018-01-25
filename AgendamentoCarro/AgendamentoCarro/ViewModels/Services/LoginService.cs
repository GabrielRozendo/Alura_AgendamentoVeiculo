using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AgendamentoCarro
{
    public class LoginService
    {
        public async Task FazerLogin(Login login)
        {
            using (var cliente = new HttpClient())
            {
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("email", login.Email),
                        new KeyValuePair<string, string>("senha", login.Senha)
                });

                cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                try
                {
                    var resultado = await cliente.PostAsync("/login", camposFormulario);

                    if (resultado.IsSuccessStatusCode)
                        MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
                    else
                        MessagingCenter.Send<LoginException>(new LoginException("Usuário ou senha inválidos"), "FalhaLogin");
                }
                catch
                {
                    MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro de comunicação com o servidor.
Por favor verifique sua conexão e tente novamente."), "FalhaLogin");
                }
            }

        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {

        }
    }
}
