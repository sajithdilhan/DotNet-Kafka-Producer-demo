using Confluent.Kafka;

namespace KafkaProducer
{
    public class Person :ISerializer<Person>, IDeserializer<Person>
    {
        public string Name  { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }

        public Person Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            throw new NotImplementedException();
        }

        public byte[] Serialize(Person data, SerializationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
