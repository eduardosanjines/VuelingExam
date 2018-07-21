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
        LogMan log = new LogMan();
        static HttpClient client;
        static HttpResponseMessage res;
        List<Object> lista = new List<object>();
        public ClientsApiController() 
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(WebConfigurationManager.AppSettings["localhost"])
            };

        }

        // GET: api/ClientsApi
        public async Task<Object> GetAll()
        {
            res = client.GetAsync(WebConfigurationManager.AppSettings["clientsWeb"]).Result;
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

                else
                {
                    log.checkHttpStatus();
                }

            }
            catch (Exception ex)
            {
                log.LogError(ex);
                throw new VuelingException("", ex);
            }
            return lista;

        }

        // GET: api/ClientsApi/5
        public async Task<Object> GetById(string id)
        {
            res = client.GetAsync(WebConfigurationManager.AppSettings["clientsWeb"]).Result;
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
                log.LogError(ex);
                throw new VuelingException("", ex);
            }
           return lista;
        }

        // GET: api/ClientsApi/username
        public async Task<Object> GetByUserName(string username)
        {
            res = client.GetAsync(WebConfigurationManager.AppSettings["clientsWeb"]).Result;
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
                        if (row.ItemArray.Contains(username))
                        {
                            lista.Add(row.ItemArray);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex);
                throw new VuelingException("", ex);
            }
            return lista;
        }
    }
}
