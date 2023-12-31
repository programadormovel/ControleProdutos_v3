﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NHibernate.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ControleProdutos.Models
{
    [Index(nameof(CodigoDeBarras), IsUnique = true)]
    public class ProdutoModel
    {

        public string DataAgora()
        {
            return DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        public Int64 Id { get; set; }

        [StringLength(12, MinimumLength=12, 
            ErrorMessage ="Mínimo de 12 caracteres!")]
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string CodigoDeBarras { get; set; } = string.Empty;
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
		[Required(ErrorMessage = "Campo Obrigatório")]
		public string Descricao { get; set; } = string.Empty;
        [Range(typeof(DateTime), minimum: "24/8/2023", maximum: "24 /8/2024")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data inválida")]
        public DateTime? DataDeValidade { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DataDeRegistro { get; set; }
        [Range(1,11, ErrorMessage="Valores entre 1 e 1000")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int? Quantidade { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Decimal? Valor { get; set; }
        [MaybeNull]
        public string? NomeDaFoto { get; set; }
        [MaybeNull]
        public byte[]? Foto { get; set; }
		[Required(ErrorMessage = "Campo Obrigatório")]
		public bool Ativo { get; set; }
        
    }
}
