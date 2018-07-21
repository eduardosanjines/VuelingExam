using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using VuelingExam.Application.Dto;
using VuelingExam.Common.Layer;
using VuelingExam.Domain.Entities;

namespace VuelingExam.Infrastructure.Repository.Repository
{
    public class PoliciesRepository
    {

        static HttpClient client;
        static HttpResponseMessage resClients;
        static HttpResponseMessage resPolicies;
        List<Object> lResultado = new List<object>();
        LogMan log = new LogMan();

        public PoliciesRepository()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(WebConfigurationManager.AppSettings["localhost"])
            };

        }

        public async Task<Object> Get() {
            resClients = client.GetAsync(WebConfigurationManager.AppSettings["clientsWeb"]).Result;
            resClients.EnsureSuccessStatusCode();
            resPolicies = client.GetAsync(WebConfigurationManager.AppSettings["policiesWeb"]).Result;
            resPolicies.EnsureSuccessStatusCode();

            if (resClients.IsSuccessStatusCode && resPolicies.IsSuccessStatusCode)
            {
                List<Object> lClients = new List<object>();
                List<Object> lPolicies = new List<object>();
               
                var clientsJsonString = await resClients.Content.ReadAsStringAsync();
                var policiesJsonString = await resPolicies.Content.ReadAsStringAsync();
                DataSet dataSetClients = JsonConvert.DeserializeObject<DataSet>(clientsJsonString);
                DataSet dataSetPolicies = JsonConvert.DeserializeObject<DataSet>(policiesJsonString);
                DataTable dataTableClients = dataSetClients.Tables["clients"];
                DataTable dataTablePolicies = dataSetClients.Tables["policies"];

                List<ClientsEntity> cli = new List<ClientsEntity>();
                List<PoliciesEntity> pol = new List<PoliciesEntity>();

                foreach (DataRow cl in dataTableClients.Rows)
                {
                    lClients.Add(cl.ItemArray);
                    
                }
                foreach (DataRow pl in dataTablePolicies.Rows)
                    {
                        lPolicies.Add(pl.ItemArray);
                    }

                if (lClients == lPolicies)
                {
                    lResultado.Add(lPolicies);
                }

            }

            return lResultado;

        }


}
}
