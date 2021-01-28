using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace microservice.Models
{
    [Table("CLIENTS")]
    public class Client
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}