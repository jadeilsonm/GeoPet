using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace GeoPetAPI.Shared.Contracts
{
    public class NonLazyloaderContractResolver : DefaultContractResolver
    {
        public new static readonly NonLazyloaderContractResolver Instance = new NonLazyloaderContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyName == "LazyLoader")
            {
                property.ShouldSerialize = i => false;
            }

            return property;
        }
    }
}
