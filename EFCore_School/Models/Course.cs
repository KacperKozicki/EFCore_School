using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_School.Models
{
    public class Course
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string? Title { get; set; }


        //public List<Student>? Studencts { get; set; }
        public ICollection<Student>? Studencts { get; set; }
    }
}
