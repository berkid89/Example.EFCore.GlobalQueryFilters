using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Example.EFCore.GlobalQueryFilters.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDeleted { get; set; }
    }
}
