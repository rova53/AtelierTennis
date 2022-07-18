using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier.Domain.Entities
{
    public class Country
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }
        public string PICTURE { get; set; }
        public string CODE { get; set; }
    }
}
