using GCDealershipWebApp.Models;
using GCDealershipWebApp.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCDealershipWebApp.Service
{
    public interface IDealerService
    {
        Task<IEnumerable<DealershipModelData>> GetDataAsync();

        Task<IEnumerable<DealerSearch>> SearchDealer(DealerSearch viewModel);
    }
}