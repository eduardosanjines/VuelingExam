using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;
using VuelingExam.Application.Dto;
using VuelingExam.Application.Services;
using VuelingExam.Application.Services.Contracts;
using VuelingExam.Common.Layer;
using VuelingExam.Domain.Entities;

namespace VuelingExam.Facade.Api.Controllers
{
    public class ClientsApiController : ApiController
    {
        private readonly IService<ClientsDto> clientsDto;
        LogMan log = new LogMan();
        static HttpClient client;
        public ClientsApiController() : this(new ClientsService())
        {

            client = new HttpClient
            {
                BaseAddress = new Uri(WebConfigurationManager.AppSettings["localhost"])
            };

        }

        public ClientsApiController(ClientsService clientsService)
        {
            this.clientsDto = clientsService;
        }

        // GET: api/ClientsApi
        public async Task<ClientsDto> GetAsync()
        {
            List<string> listClients = new List<string>();
            ClientsDto clientsDto = new ClientsDto();
            HttpResponseMessage res = client.GetAsync(WebConfigurationManager.AppSettings["localhost"]).Result;
            res.EnsureSuccessStatusCode();
 
            try
            {
                if (res.IsSuccessStatusCode)
            {
                    var clientsJsonString = await res.Content.ReadAsStringAsync();

                    DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(clientsJsonString);
                    DataTable dataTable = dataSet.Tables["clients"];
                    
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine(row.ItemArray);
                        listClients.Add(row.ItemArray.ToString());
                        clientsDto = new ClientsDto(row);
                    }

                    //var deserialized = JsonConvert.DeserializeObject<List<ClientsDto>>(listClients.ToString());
                    //listClientsDto = listClients;
                }
            }
            catch (Exception ex) {
                log.logError(ex);
                throw new VuelingException("", ex);
            }
      

            return clientsDto;

        }

        // GET: api/ClientsApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ClientsApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ClientsApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ClientsApi/5
        public void Delete(int id)
        {
        }
    }
}
