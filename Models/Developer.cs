
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManagmentApi.Models{

    [Table("Developer")]
    public class Developer{

        [Key]
        [Column("DeveloperID")]
        public int DeveloperID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Gender")]
        public string Gender { get; set; }

        [Column("EmailAddress")]
        public string EmailAddress { get; set; }

        [JsonIgnore]
        public virtual List<Task> Tasks{get;set;}
       
    }
}