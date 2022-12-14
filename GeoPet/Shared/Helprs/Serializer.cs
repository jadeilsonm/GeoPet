using GeoPetAPI.Shared.Contracts;
using Newtonsoft.Json;

namespace GeoPetAPI.Shared.Helprs
{
    public static class Serializer
    {
        public static string Serializar(Object obj)
        {

            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                ContractResolver = new NonLazyloaderContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

        }
    }
}
