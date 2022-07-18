using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier.Domain.Entities
{
    public class Data
    {
        [Key, Column("id")]
        public int ID { get; set; }
        public int RANK { get; set; }
        public int POINTS { get; set; }
        public int WEIGHT { get; set; }
        public int HEIGHT { get; set; }
        public int AGE { get; set; }
        [Column("LAST")]
        public string LAST_STR { get; set; }
        [NotMapped]
        public int[] LAST {
            get => default(int[]);
            set 
            {
                LAST_STR = string.Join(",", value);
            }
        }
    }
}
