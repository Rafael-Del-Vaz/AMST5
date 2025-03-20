using System;

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

    // Construtor
    public Locacao(string modelo, int horaInicial, int horaFinal)
    {
        Modelo = modelo;
        HoraInicial = horaInicial;
        HoraFinal = horaFinal;
    }

    // Método para validar as horas
    public void ValidarHoras()
    {
        if (HoraInicial < 0 || HoraInicial > 23 || HoraFinal < 0 || HoraFinal > 23)
        {
            Console.WriteLine("Horas inválidas! As horas devem estar entre 0 e 23.");
        }
    }

    // Método para calcular o valor da locação
    public void CalcularValores()
    {
        Duracao = HoraFinal - HoraInicial;

        // Caso a hora final seja menor que a hora inicial, a locação ultrapassa a meia-noite.
        if (Duracao <= 0)
        {
            Duracao += 24; // Ajustando a duração para considerar o cruzamento de meia-noite.
        }

        // Calculando o valor da locação
        ValorLocacao = Duracao * ValorPorHora;

        // Aplicando imposto com base no valor da locação
        Imposto = ValorLocacao <= 100 ? ValorLocacao * 0.20 : ValorLocacao * 0.15;

        // Total final da locação
        Total = ValorLocacao + Imposto;
    }

    // Exibindo o recibo
    public void ExibirRecibo()
    {
        Console.WriteLine("\n--- RECIBO DE LOCAÇÃO ---");
        Console.WriteLine($"Modelo do carro: {Modelo}");
        Console.WriteLine($"Duração: {Duracao} horas");
        Console.WriteLine($"Valor da locação: R$ {ValorLocacao:F2}");
        Console.WriteLine($"Imposto: R$ {Imposto:F2}");
        Console.WriteLine($"Total a pagar: R$ {Total:F2}");
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

        // Validação de horas
        locacao.ValidarHoras();

        // Calcular os valores da locação
        locacao.CalcularValores();

        // Exibir recibo
        locacao.ExibirRecibo();
    }
}