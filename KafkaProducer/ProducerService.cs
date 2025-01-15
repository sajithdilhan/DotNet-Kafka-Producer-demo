using Confluent.Kafka;

namespace KafkaProducer
{
    internal class ProducerService
    {
        public ProducerService() { }

        private readonly ProducerConfig config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        private readonly string topic = "kafkaproducer.samplemessage";
        public void SendMessage(string message)
        {
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    producer.ProduceAsync(topic, new Message<Null, string> { Value = message })
                        .GetAwaiter()
                        .GetResult();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Something went wrong: {e}");
                }
            }
        }

        public void SendMessage()
        {
            using (var producer = new ProducerBuilder<Null, Person>(config).Build())
            {
                try
                {
                    Person person = new Person { Age = 23, Id = 1, Name = "Sajith", Title = "Mr" };
                    producer.ProduceAsync(topic, new Message<Null, Person> { Value =  person })
                        .GetAwaiter()
                        .GetResult();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Something went wrong: {e}");
                }
            }
        }
    }
}


