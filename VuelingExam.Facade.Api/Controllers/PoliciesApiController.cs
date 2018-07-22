using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        DataSet resd = new DataSet();
        static HttpResponseMessage resClients;
        static HttpResponseMessage resPolicies;
        //List<Object> lClients = new List<object>();
        //List<Object> lPolicies = new List<object>();
        //List<Object> nuevaLista = new List<Object>();

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

                    


                    DataRelation dataRelation = new DataRelation("idClients", dataTableClients.Columns["id"],
                        dataTablePolicies.Columns["clientId"]
                        );

                    resd.Relations.Add(dataRelation);

                    //for (int i = 0; i < dataTablePolicies.Rows.Count; i++)
                    //{
                    //    Object oClients = dataTableClients.Rows[i]["id"];
                    //    Object oPolicies = dataTablePolicies.Rows[i]["clientId"];

                    //    if (oPolicies == oClients) {

                    //        oClients = oPolicies;
                    //        //lClients.Add(oClients);
                    //        //lPolicies.Add(oPolicies);
                    //        //nuevaLista.Add(new PoliciesDto(oClients, oPolicies));
                    //    }
                    // }
                    //foreach (DataRow cl in dataTableClients.Rows)
                    //{
                    //    lClients.Add(cl);
                    //}
                    //foreach (DataRow pl in dataTablePolicies.Rows)
                    //{
                    //    lPolicies.Add(pl);
                    //}

               }
                else {
                    log.checkHttpStatus();

                }

            }
            catch (Exception ex) {
                log.LogError(ex);
                throw new VuelingException("", ex);
            }

            return resd;

        }

        // GET: api/PoliciesApi/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
