using Confluent.Kafka;

namespace KafkaProducer;

internal class ProducerService
{
    public ProducerService() { }

    private readonly ProducerConfig config = new ProducerConfig
    {
        BootstrapServers = "localhost:9092"
    };

    private readonly string topic = "kafkaproducer.samplemessage";
    public async Task SendMessageAsync(string message)
    {
        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            try
            {
                await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: {e}");
            }
        }
    }

    public async Task SendMessageAsync()
    {
        using (var producer = new ProducerBuilder<Null, Person>(config).Build())
        {
            try
            {
                Person person = new() { Age = 23, Id = 1, Name = "Sajith", Title = "Mr" };
                await producer.ProduceAsync(topic, new Message<Null, Person> { Value =  person });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: {e}");
            }
        }
    }
}


