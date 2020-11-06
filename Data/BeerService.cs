using KagoolTest.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KagoolTest.Data
{
    public class BeerService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _clientFactory;


        public BeerService(IConfiguration configuration, ILogger logger, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _logger = logger;
            _clientFactory = clientFactory;
        }       



        /// <summary>
        /// Get a list of random products
        /// </summary>
        /// <returns></returns>
        public async Task<List<Beer>> GetProducts()
        {
            try
            {
                var uri = "beers/?page=1&per_page=8";

                HttpClient client = _clientFactory.CreateClient("Gateway");

                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                List<Beer> beers = await response.Content.ReadAsAsync<List<Beer>>();

                return beers;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetProducts() ex: " + ex);
            }

            return null;
        }
    }
}