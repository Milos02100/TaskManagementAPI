
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagmentApi.Models
{
    [Table("Board")]
    public class Board
    {
        [Key]
        [Column("BoardID")]
        public int BoardID{get;set;}

        [Column("Title")]
        [MaxLength(100)]
        public string Title{get;set;}
        
        public virtual List<Task> Tasks{get;set;}
    }
}