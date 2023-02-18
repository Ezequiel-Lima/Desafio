using System.ComponentModel;

namespace Desafio.Enums
{
    public enum EClassificarRisco
    {
        [Description("Aumentando")]
        Aumentando,

        [Description("Moderado")]
        Moderado,

        [Description("Grave")]
        Grave,

        [Description("Muito Grave")]
        MuitoGrave
    }
}
