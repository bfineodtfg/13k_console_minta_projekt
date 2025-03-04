using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace _13k_console_minta_projekt
{
    public class HttpRequests
    {
        HttpClient client = new HttpClient();
        private async Task<string> Everything(string url, string requestType, object jsonData = null)
        {

            string serverUrl = "http://127.1.1.1:3000/" + url;
            try
            {
                HttpResponseMessage response = null;
                if (requestType.ToLower() == "get")
                {
                    response = await client.GetAsync(serverUrl);
                }
                else if (requestType.ToLower() == "post")
                {
                    string jsonString = JsonConvert.SerializeObject(jsonData);
                    HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Application/JSON");
                    response = await client.PostAsync(serverUrl, sendThis);
                }
                else if (requestType.ToLower() == "put")
                {
                    string jsonString = JsonConvert.SerializeObject(jsonData);
                    HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Application/JSON");
                    response = await client.PutAsync(serverUrl, sendThis);
                }
                else if (requestType.ToLower() == "delete")
                {
                    response = await client.DeleteAsync(serverUrl);
                }
                response.EnsureSuccessStatusCode();
                string stringResult = await response.Content.ReadAsStringAsync();
                return stringResult;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }

        public async Task<string> Delete(int id) {
            string Result = "";
            string url = "deleteFruit/" + id;
            try
            {
                string result = await Everything(url, "get");
                Result = JsonConvert.DeserializeObject<jsonResponseData>(result).message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return Result;
        }
        public async Task<List<string>> listFruits()
        {
            List<string> lista = new List<string>();
            string url = "fruits";
            try
            {
                string result = await Everything(url, "get");
                lista = JsonConvert.DeserializeObject<List<jsonResponseData>>(result).Select(fruit => fruit.nev).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return lista;
        }
        public async Task<string> Registration(string username, string password)
        {
            string url = "register";
            try
            {
                var jsonData = new
                {
                    registerName = username,
                    registerPassword = password
                };

                string result = await Everything(url, "post", jsonData);
                string message = JsonConvert.DeserializeObject<jsonResponseData>(result).message;

                return message;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<string> Login(string username, string password)
        {
            string url = "login";
            try
            {
                var jsonData = new
                {
                    loginName = username,
                    loginPassword = password
                };

                string result = await Everything(url, "post", jsonData);

                string message = JsonConvert.DeserializeObject<jsonResponseData>(result).message;
                Token.token = JsonConvert.DeserializeObject<jsonResponseData>(result).token;

                return message;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public async Task<List<jsonResponseData>> GetPersonalFruits()
        {
            List<jsonResponseData> fruits = new List<jsonResponseData>();
            string url = "personalFruits";
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);

                string result = await Everything(url, "get");
                fruits = JsonConvert.DeserializeObject<List<jsonResponseData>>(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return fruits;
        }

        public async Task<string> AddFruits(string fruitName, int fruitPrice, int fruitWeight)
        {
            string url = "addFruit";
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);

                var jsonData = new
                {
                    gyumolcsNev = fruitName,
                    gyumolcsAr = fruitPrice,
                    gyumolcsSuly = fruitWeight
                };

                string result = await Everything(url, "post", jsonData);

                string message = JsonConvert.DeserializeObject<jsonResponseData>(result).message;
                return message;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<string> UpdateFruits(string fruitName, int fruitPrice, int fruitWeight)
        {
            string url = "addFruit";
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);

                var jsonData = new
                {
                    gyumolcsNev = fruitName,
                    gyumolcsAr = fruitPrice,
                    gyumolcsSuly = fruitWeight
                };

                string result = await Everything(url, "put", jsonData);

                string message = JsonConvert.DeserializeObject<jsonResponseData>(result).message;
                return message;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
