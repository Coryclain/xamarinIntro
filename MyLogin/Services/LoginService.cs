using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyLogin.Models;
using Newtonsoft.Json;

namespace MyLogin.Services
{
    public class LoginService
    {

        public async Task<LoginResult> userLogin(Login login)
        {
            string url = "https://apidev.venn.mx/Venn/api/login";

            LoginResult loginResult = new LoginResult()
            {
                status = "El usuario o password son incorrectos",
                success = false,
                loginSuccess = new LoginSuccess()
            };

            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            try
            {
                using (client)
                {
                    var json = JsonConvert.SerializeObject(login);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage resp = null;
                    resp = await client.PostAsync(url, content);

                    if(resp.IsSuccessStatusCode)
                    {
                        var resultado = await resp.Content.ReadAsStringAsync();
                        loginResult.loginSuccess = JsonConvert.DeserializeObject<LoginSuccess>(resultado);
                        loginResult.success = true;
                    }

                    return loginResult;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return loginResult;
            }

        }
    }
}
