
using KafkaProducer;

string input = string.Empty;
var producer = new ProducerService();
do
{
    Console.WriteLine("Enter message");
    input = Console.ReadLine() ?? string.Empty;
    producer.SendMessage(input);
}
while (!input.Equals("Exit", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Exiting....");
Environment.Exit(0);