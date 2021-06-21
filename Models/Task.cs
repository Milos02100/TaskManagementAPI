
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManagmentApi.Models{

    [Table("Task")]
    public class Task
    {
        [Key]
        [Column("TaskID")]
        public int TaskID { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Note")]
        public string Note { get; set; }

        [Column("Date")]
        public string Date { get; set; }

        [Column("Important")]
        public bool Important { get; set; }
        
        [Column("Status")]
        public int Status { get; set; }

        public Developer Developer{get;set;}

        [JsonIgnore]
        public Board Board { get; set; }
    }
}