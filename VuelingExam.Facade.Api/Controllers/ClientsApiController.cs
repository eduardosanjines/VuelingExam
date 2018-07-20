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
        List<Object> lista = new List<object>();
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
        public async Task<Object> GetAsync()
        {
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
                    lista.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                log.logError(ex);
                throw new VuelingException("", ex);
            }
            return lista;

        }

        // GET: api/ClientsApi/5
        public async Task<Object> GetAsync(string id)
        {
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

                        if (row.ItemArray.Contains(id)) {

                            lista.Add(row.ItemArray);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                log.logError(ex);
                throw new VuelingException("", ex);
            }
           return lista;
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
