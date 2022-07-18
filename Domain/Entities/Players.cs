using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Atelier.Domain.Entities
{
    public class Players
    {
        [Key, Column("id")]
        public int ID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string SHORTNAME { get; set; }
        public string SEX { get; set; }
        public string PICTURE { get; set; }
        [ForeignKey("COUNTRY")]
        public int ID_COUNTRY { get; set; }
        [ForeignKey("DATA")]
        public int ID_DATA { get; set; }
        public Country COUNTRY { get; set; }
        public Data DATA { get; set; }
    }
}
