using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

namespace VuelingExam.Facade.Api.Controllers
{
    public class PoliciesApiController : ApiController
    {

        private readonly IService<PoliciesDto> policiesDto;
        LogMan log = new LogMan();
        static HttpClient client;
        List<Object> lista = new List<object>();
        public PoliciesApiController() : this(new ClientsService())
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(WebConfigurationManager.AppSettings["localhost"])
            };

        }

        public PoliciesApiController(ClientsService clientsService)
        {
            //this.policiesDto = clientsService;
        }

        // GET: api/Policies
        public async Task<Object> GetPolicieslinkUsername()
        {
            List<Object> listPolicies = new List<Object>();
            ClientsDto dataClients;
            PoliciesDto dataPolicies;
            HttpResponseMessage resClients = client.GetAsync(WebConfigurationManager.AppSettings["clientsWeb"]).Result;
            HttpResponseMessage resPolicies = client.GetAsync(WebConfigurationManager.AppSettings["policiesWeb"]).Result;
            resClients.EnsureSuccessStatusCode();
            resPolicies.EnsureSuccessStatusCode();
            try
            {
                //Check status the two url web.
                if (resClients.IsSuccessStatusCode && resPolicies.IsSuccessStatusCode)
                {
                    var clientsJsonString = await resClients.Content.ReadAsStringAsync();
                    var policiesJsonString = await resPolicies.Content.ReadAsStringAsync();
                    DataSet dataSetClients = JsonConvert.DeserializeObject<DataSet>(clientsJsonString);
                    DataSet dataSetPolicies = JsonConvert.DeserializeObject<DataSet>(policiesJsonString);
                    DataTable dataTableClients = dataSetClients.Tables["clients"];
                    DataTable dataTablePolicies = dataSetClients.Tables["policies"];

                    foreach (DataRow row in dataTablePolicies.Rows)
                    {
                        Console.WriteLine(row["clientId"]);
                        dataClients = new ClientsDto(row["clientId"], row["name"], row["email"], row["role"]);
                    }

                    foreach (DataRow row in dataTableClients.Rows)
                    {
                        Console.WriteLine(row["clientId"]);
                        dataPolicies = new PoliciesDto(row["clientId"], row["amountInsured"], row["email"], row["inceptionDate"], row["installmentPayment"], row["clientId"]);
                    }

                    if (dataClients == dataPolicies) {


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

        // GET: api/Policies/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Policies
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Policies/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Policies/5
        public void Delete(int id)
        {
        }
    }
}
