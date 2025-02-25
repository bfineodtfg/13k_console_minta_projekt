using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace _13k_console_minta_projekt
{
    class HttpRequests
    {
        HttpClient client = new HttpClient();
        private async void Everything(string url,string requestType) {
            
            string serverUrl = "http://127.1.1.1:3000/"+url;
            try
            {
                HttpResponseMessage response = null;
                if (requestType == "get")
                {
                    response = await client.GetAsync(serverUrl);
                }
                response.EnsureSuccessStatusCode();
                string stringResult = await response.Content.ReadAsStringAsync();
                List<fruitClass> lista = JsonConvert.DeserializeObject<List<fruitClass>>(stringResult);
                foreach (fruitClass item in lista)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async void listFruits() {
            List<string> lista = new List<string>();
            string url = "http://127.1.1.1:3000/fruits";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string stringResult = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<fruitName>>(stringResult).Select(fruit => fruit.nev).ToList();
                foreach (string item in lista)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async void Registration(string username, string password)
        {
            string url = "http://127.1.1.1:3000/register";
            try
            {
                var jsonData = new
                {
                    registerName = username,
                    registerPassword = password
                };

                string jsonString = JsonConvert.SerializeObject(jsonData);

                HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Application/JSON");

                HttpResponseMessage response = await client.PostAsync(url,sendThis);
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();

                string message = JsonConvert.DeserializeObject<JsonMessage>(result).message;
                
                Console.WriteLine(message);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async void Login(string username, string password)
        {
            string url = "http://127.1.1.1:3000/login";
            try
            {
                var jsonData = new
                {
                    loginName = username,
                    loginPassword = password
                };

                string jsonString = JsonConvert.SerializeObject(jsonData);

                HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Application/JSON");

                HttpResponseMessage response = await client.PostAsync(url, sendThis);
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();

                string message = JsonConvert.DeserializeObject<JsonMessage>(result).message;
                Token.token = JsonConvert.DeserializeObject<JsonMessage>(result).token;

                Console.WriteLine(message);
                


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public async void GetPersonalFruits()
        {
            string url = "http://127.1.1.1:3000/personalFruits";
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();

                List<fruitClass> personalFruits =  JsonConvert.DeserializeObject<List<fruitClass>>(result);

                foreach (fruitClass item in personalFruits)
                {
                    Console.WriteLine(item.nev);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async void AddFruits(string fruitName, int fruitPrice, int fruitWeight)
        {
            string url = "http://127.1.1.1:3000/addFruit";
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);

                var JsonData = new
                {
                    gyumolcsNev = fruitName,
                    gyumolcsAr = fruitPrice,
                    gyumolcsSuly = fruitWeight
                };

                string JsonString = JsonConvert.SerializeObject(JsonData);
                HttpContent sendThis = new StringContent(JsonString,Encoding.UTF8,"Application/JSON");

                HttpResponseMessage response = await client.PostAsync(url, sendThis);
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();

                string message = JsonConvert.DeserializeObject<JsonMessage>(result).message;

                Console.WriteLine(message);
                Console.ReadKey();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public async void UpdateFruits(string fruitName, int fruitPrice, int fruitWeight)
        {
            string url = "http://127.1.1.1:3000/addFruit";
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);

                var JsonData = new
                {
                    gyumolcsNev = fruitName,
                    gyumolcsAr = fruitPrice,
                    gyumolcsSuly = fruitWeight
                };

                string JsonString = JsonConvert.SerializeObject(JsonData);
                HttpContent sendThis = new StringContent(JsonString, Encoding.UTF8, "Application/JSON");

                HttpResponseMessage response = await client.PutAsync(url, sendThis);
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();

                string message = JsonConvert.DeserializeObject<JsonMessage>(result).message;

                Console.WriteLine(message);
                Console.ReadKey();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
