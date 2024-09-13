using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.CrudAdvanced.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Idade { get; set; }
        public bool IsDeleted { get; set; } = false;

        public string? CepCode { get; set; }           
        public string? Logradouro { get; set; }       
        public string? Complemento { get; set; }      
        public string? Unidade { get; set; }           
        public string? Bairro { get; set; }           
        public string? Localidade { get; set; }       
        public string? Uf { get; set; }                
        public string? Estado { get; set; }            
        public string? Regiao { get; set; }           
        public string? Ibge { get; set; }              
        public string? Gia { get; set; }              
        public string? Ddd { get; set; }              
        public string? Siafi { get; set; }            

    }
}
