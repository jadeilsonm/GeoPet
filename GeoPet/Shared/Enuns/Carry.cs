using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace GeoPetAPI.Shared.Enuns
{
    public enum Carry
    {
        [Description("Baixo porte")]
        low,
        [Description("Médio porte")]
        medium,
        [Description("Alto porte")]
        high
    }
}
