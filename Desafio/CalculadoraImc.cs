using System.Text;
using Desafio.Enums;
using Desafio.Extensions;

namespace Desafio
{
    public class CalculadoraImc
    {
        public double Imc { get; private set; }

        public CalculadoraImc(double altura, double peso)
        {
            Calcular(altura, peso);
        }

        public void Calcular(double altura, double peso)
        {
            ValidarImc(altura, peso);
            Imc = Math.Round(peso / (altura * altura), 2);
        }

        private string ClassificarImc()
        {            
            var imcClassificacoes = new Dictionary<(double, double), string>()
            {
                { (double.MinValue, 16), EClassificarImc.MagrezaGrauIII.GetDescription() },
                { (16, 16.9), EClassificarImc.MagrezaGrauII.GetDescription() },
                { (17, 18.4), EClassificarImc.MagrezaGrauI.GetDescription() },
                { (18.5, 24.9), EClassificarImc.Eutrofia.GetDescription() },
                { (25, 29.9), EClassificarImc.Sobrepeso.GetDescription() },
                { (30, 34.9), EClassificarImc.ObesidadeGrauI.GetDescription() },
                { (35, 40), EClassificarImc.ObesidadeGrauII.GetDescription() },
                { (40, double.MaxValue), EClassificarImc.ObesidadeGrauIII.GetDescription() }
            };

            foreach (var (range, descricao) in imcClassificacoes)
            {
                if (Imc >= range.Item1 && Imc <= range.Item2)
                    return descricao;
            }

            throw new ArgumentException("IMC invalido");
        }

        private string ClassificarRisco()
        {
            var imcNiveisRiscos = new Dictionary<(double, double), string>()
            {
                { (25, 29.9), EClassificarRisco.Aumentando.GetDescription() },
                { (30, 34.9), EClassificarRisco.Moderado.GetDescription() },
                { (35, 40), EClassificarRisco.Grave.GetDescription() },
                { (40, double.MaxValue), EClassificarRisco.MuitoGrave.GetDescription() }
            };

            foreach (var (range, descricao) in imcNiveisRiscos)
            {
                if (Imc >= range.Item1 && Imc <= range.Item2)               
                    return descricao;              
            }

            return null;
        }

        public void ValidarImc(double altura, double peso)
        {
            const double alturaMinima = 0.5;
            const double alturaMaxima = 3;
            const double pesoMinimo = 0.5;
            const double pesoMaximo = 500;

            if (altura < alturaMinima || altura > alturaMaxima)
                throw new ArgumentException($"A altura deve estar entre {alturaMinima} e {alturaMaxima}.");

            if (peso < pesoMinimo || peso > pesoMaximo)
                throw new ArgumentException($"O peso deve estar entre {pesoMinimo} e {pesoMaximo}.");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"\nIMC é {Imc}");
            stringBuilder.AppendLine($"{ClassificarImc()}");

            if (!string.IsNullOrEmpty(ClassificarRisco()))
                stringBuilder.AppendLine($"Risco: {ClassificarRisco()}");

            return stringBuilder.ToString();
        }
    }
}