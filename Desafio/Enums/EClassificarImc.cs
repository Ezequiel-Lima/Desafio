using System.ComponentModel;

namespace Desafio.Enums
{
    public enum EClassificarImc
    {
        [Description("Magreza Grau III")]
        MagrezaGrauIII,

        [Description("Magreza Grau II")]
        MagrezaGrauII,

        [Description("Magreza Grau I")]
        MagrezaGrauI,

        [Description("Eutrofia")]
        Eutrofia,

        [Description("Sobrepeso")]
        Sobrepeso,

        [Description("Obesidade Grau I")]
        ObesidadeGrauI,

        [Description("Obesidade Grau II")]
        ObesidadeGrauII,

        [Description("Obesidade Grau III")]
        ObesidadeGrauIII
    }
}
