using Microsoft.Identity.Client.Extensions.Msal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace ControleProdutos.Models
{
    public class ProdutoModel
    {
        public Int64 Id { get; set; }
        public string CodigoDeBarras { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeValidade { get; set; }
        public DateTime DataDeRegistro { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        [MaybeNull]
        public string NomeDaFoto { get; set; }
        [MaybeNull]
        public byte[] Foto { get; set; }
        public bool Ativo { get; set; }

    }
}
