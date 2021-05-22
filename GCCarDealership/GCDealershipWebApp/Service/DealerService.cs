using GCDealershipWebApp.Models;
using GCDealershipWebApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GCDealershipWebApp.Service
{
    public class DealerService : IDealerService
    {
        private readonly HttpClient _client;

        public DealerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<DealershipModelData>> GetDealerData()
        {
            return await _client.GetFromJsonAsync<IEnumerable<DealershipModelData>>("");
        }

        public async Task<IEnumerable<DealerSearch>> SearchDealer(DealerSearch viewModel)
        {
            string queryString = viewModel?.GetQueryString();

            return await _client.GetFromJsonAsync<IEnumerable<DealerSearch>>($"search?{queryString}");
        }
    }
}
