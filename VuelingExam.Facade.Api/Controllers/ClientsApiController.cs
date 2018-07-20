using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                BaseAddress = new Uri("http://www.mocky.io/v2/5808862710000087232b75ac")
            };

        }

        public ClientsApiController(ClientsService clientsService)
        {
            this.clientsDto = clientsService;
        }

        // GET: api/ClientsApi
        public async Task<List<ClientsEntity>> GetAsync()
        {
            List<ClientsEntity> listClientsDto = new List<ClientsEntity>();
            HttpResponseMessage res = client.GetAsync(WebConfigurationManager.AppSettings["localhost"]).Result;
            res.EnsureSuccessStatusCode();
            if (res.IsSuccessStatusCode)
            {

            }
            try
            {

                var alumnoJsonString = await res.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<List<ClientsEntity>>(alumnoJsonString);
                listClientsDto = deserialized;
              

            }
            catch (Exception ex) {
                log.logError(ex);
                throw new VuelingException("", ex);
            }
            return listClientsDto.ToList();

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
