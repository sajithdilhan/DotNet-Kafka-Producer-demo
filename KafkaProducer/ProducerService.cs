﻿using Confluent.Kafka;

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


    }
}


