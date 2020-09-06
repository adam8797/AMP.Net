using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AMP.Net.Models;

namespace AMP.Net
{
    public class AdsModuleAmpClient : AmpClient
    {
        public AdsModuleAmpClient(AmpClient baseClient) : base(baseClient){}

        public async Task<GetInstancesResponse?> GetInstancesAsync(CancellationToken token = default)
        {
            return (await MakeSessionRequestAsync<WrappedResult<GetInstancesResponse>>("/API/ADSModule/GetInstances", new AuthenticatedRequest(), token)).Results.FirstOrDefault();
        }
    }
}