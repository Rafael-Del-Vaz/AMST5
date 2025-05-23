class Carro
{
    public string? Modelo { get; set; }
    public double ValorPorHora { get; set; } = 10.0;
}

class Locacao : Carro
{
    public int HoraInicial { get; set; }
    public int HoraFinal { get; set; }
    
    public int Duracao { get; private set; }
    public double ValorLocacao { get; private set; }
    public double Imposto { get; private set; }
    public double Total { get; private set; }

    public Locacao(string modelo, int horaInicial, int horaFinal)
    {
        Modelo = modelo;
        HoraInicial = horaInicial;
        HoraFinal = horaFinal;
    }


    public void ValidarHoras()
    {
        if (HoraInicial < 0 || HoraInicial > 23 || HoraFinal < 0 || HoraFinal > 23)
        {
            Console.WriteLine("Horas inválidas! As horas devem estar entre 0 e 23.");
        }
    }


    public void CalcularValores()
    {
        Duracao = HoraFinal - HoraInicial;


        if (Duracao <= 0)
        {
            Duracao += 24; 
        }

        ValorLocacao = Duracao * ValorPorHora;

    
        Imposto = ValorLocacao <= 100 ? ValorLocacao * 0.20 : ValorLocacao * 0.15;


        Total = ValorLocacao + Imposto;
    }


    public void ExibirRecibo()
    {
        Console.WriteLine("-Recibo da Locação-");
        Console.WriteLine($"Modelo do carro: {Modelo}");
        Console.WriteLine($"Duração: {Duracao} horas");
        Console.WriteLine($"Valor da locação: R$ {ValorLocacao}");
        Console.WriteLine($"Imposto: R$ {Imposto}");
        Console.WriteLine($"Total a pagar: R$ {Total}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite o modelo do carro: ");
        string modelo = Console.ReadLine();

        Console.Write("Digite a hora inicial da locação (0-23): ");
        int horaInicial = int.Parse(Console.ReadLine());

        Console.Write("Digite a hora final da locação (0-23): ");
        int horaFinal = int.Parse(Console.ReadLine());

        Locacao locacao = new Locacao(modelo, horaInicial, horaFinal);



        locacao.ValidarHoras();

      
        locacao.CalcularValores();

    
        locacao.ExibirRecibo();
    }
}
