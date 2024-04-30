using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AgendaApp.Tests.Helpers
{
    /// <summary>
    /// Classe auxiliar para desenvolvimento dos testes
    /// </summary>
    public class TestHelper
    {
        /// <summary>
        /// Método para retornar um obj HTTP CLIENTE para fazer requisiçoes para servicos da api
        /// </summary>
        public static HttpClient CreateClient 
            => new WebApplicationFactory<Program>().CreateClient();

        /// <summary>
        /// Método para serializar os dados de um obejto
        /// e retornar no formato JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static StringContent CreateContent<T>(T obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

        /// <summary>
        /// Método para deserializar os dados de um objeto retornado em uma chamada feita pela API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static T ReadContent<T>(HttpResponseMessage message)
            => JsonConvert.DeserializeObject<T>(message.Content.ReadAsStringAsync().Result);
    }
}
