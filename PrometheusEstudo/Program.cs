using Prometheus;

internal class Program
{
    private static void Main(string[] args)
    {
        using var server = new Prometheus.KestrelMetricServer(port: 1234);
        server.Start();

        Console.WriteLine("Open http://localhost:1234/metrics in a web browser.");
        Console.WriteLine("Press enter to exit.");
        int contador = 0;
        while (contador < 1000)
        {
            contador++;
            Rodado();
        }
        Console.ReadLine();

    }

    private static readonly Counter ProcessedJobCount = Metrics
    .CreateCounter("dotnet_app_funcao_rodada", "número de vezes que a função rodado rodou.");

    public static void Rodado()
    {
        ProcessedJobCount.Inc();
    }
}


