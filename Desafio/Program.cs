using Desafio;

Console.WriteLine("Informe sua altura: ");
double altura = double.Parse(Console.ReadLine());

Console.WriteLine("Informe seu peso: ");
double peso = double.Parse(Console.ReadLine());

CalculadoraImc calculadoraImc = new CalculadoraImc(altura, peso);
Console.WriteLine(calculadoraImc.ToString());