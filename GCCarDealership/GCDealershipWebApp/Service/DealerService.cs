﻿using GCDealershipWebApp.Service.Models;
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

        public async Task<IEnumerable<DealershipModelData>> GetDataAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<DealershipModelData>>("");
        }
    }
}