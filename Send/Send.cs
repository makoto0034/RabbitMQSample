using System.Text;
using RabbitMQ.Client;

// 接続するホストを指定
var factory = new ConnectionFactory { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(
    queue: "hello",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null
    );

const string message = "Hellow World!"; 
// メッセージをバイト列に変換
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(
    exchange: string.Empty,
    routingKey:"hello",
    basicProperties: null,
    body: body
    );

// 上記のコードが完了したら、接続、チャネル、およびソケットが閉じられる。
Console.WriteLine($"[x] Sent {message}");

Console.WriteLine("Press [enter] to exit.");
Console.ReadLine();





