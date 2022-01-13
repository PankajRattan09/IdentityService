using Newtonsoft.Json;
using Xunit.Abstractions;

namespace IdentityService.API.Test.Entities
{
    public class MemberDataSerializer<T> : IXunitSerializable
    {
        public T Object { get; private set; }
        public MemberDataSerializer()
        {

        }
        public MemberDataSerializer(T objectToSer)
        {
            Object = objectToSer;
        }
        public void Deserialize(IXunitSerializationInfo info)
        {
            Object = JsonConvert.DeserializeObject<T>(info.GetValue<string>("objValue"));
        }

        public void Serialize(IXunitSerializationInfo info)
        {
            var json = JsonConvert.SerializeObject(Object);
            info.AddValue("objValue", json);
        }
    }
}
