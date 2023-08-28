using System.ComponentModel.DataAnnotations;

namespace ControleProdutos.Models
{
    public class LoginModel
    {
        [Key]
        public Int64 Id { get; set; }
        public EmailAddressAttribute EmailAddress { get; set; }
        public string Senha { get; set; }   
        public string Usuario { get; set; } 
        public int? NivelAcesso { get; set; }    
        public int? Estatus { get; set; }
        public bool? EmailConfirmado { get; set; }    
        public bool? TelefoneConfirmado { get; set; } 
        public DateTime DataDeRegistro { get; set; }    
    }
}
