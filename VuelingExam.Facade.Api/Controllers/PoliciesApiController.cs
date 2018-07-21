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
using VuelingExam.Domain.Entities;
using VuelingExam.Infrastructure.Repository.Repository;

namespace VuelingExam.Facade.Api.Controllers
{
    public class PoliciesApiController : ApiController
    {
        LogMan log = new LogMan();
        static HttpClient client;
        static HttpResponseMessage resClients;
        static HttpResponseMessage resPolicies;
        List<Object> lClients = new List<object>();
        List<Object> lPolicies = new List<object>();
        List<Object> lnqClients = new List<object>();
        List<Object> lnqPolicies = new List<object>();

        public PoliciesApiController()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(WebConfigurationManager.AppSettings["localhost"])
            };

        }

        // GET: api/PoliciesApi
        public async Task<Object> GetAll()
        {

            resClients = client.GetAsync(WebConfigurationManager.AppSettings["clientsWeb"]).Result;
            resClients.EnsureSuccessStatusCode();
            resPolicies = client.GetAsync(WebConfigurationManager.AppSettings["policiesWeb"]).Result;
            resPolicies.EnsureSuccessStatusCode();

            try
            {

                if (resClients.IsSuccessStatusCode && resPolicies.IsSuccessStatusCode)
                {
                    var clientsJsonString = await resClients.Content.ReadAsStringAsync();
                    var policiesJsonString = await resPolicies.Content.ReadAsStringAsync();
                    DataSet dataSetClients = JsonConvert.DeserializeObject<DataSet>(clientsJsonString);
                    DataSet dataSetPolicies = JsonConvert.DeserializeObject<DataSet>(policiesJsonString);
                    DataTable dataTableClients = dataSetClients.Tables["clients"];
                    DataTable dataTablePolicies = dataSetPolicies.Tables["policies"];

                    foreach (DataRow cl in dataTableClients.Rows)
                    {
                        lClients.Add(cl);

                    }
                    foreach (DataRow pl in dataTablePolicies.Rows)
                    {
                        lPolicies.Add(pl);
                    }

                    //lnqClients = lClients.Except(lPolicies).ToList();
                    //lnqPolicies = lPolicies.Except(lClients).ToList();

                    if (lPolicies.Contains("clientId") == lPolicies.Contains("id"))
                    {
                        //I can't compare List
                        lClients = lPolicies;

                    }

                }
                else {
                    log.checkHttpStatus();

                }

            }
            catch (Exception ex) {
                log.LogError(ex);
                throw new VuelingException("", ex);
            }

            return lPolicies;

        }

        // GET: api/PoliciesApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PoliciesApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PoliciesApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PoliciesApi/5
        public void Delete(int id)
        {
        }
    }
}
