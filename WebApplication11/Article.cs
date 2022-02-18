using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11
{
    public class Article
    {
        [Key]
        public string codart { get; set; }


       
        public string desart { get; set; } = string.Empty;
        public string unite { get; set; } = string.Empty;
        public string famart { get; set; } = string.Empty;
        public string sousfam { get; set; } = string.Empty;

        public string codtva { get; set; } = string.Empty;
        
    }
}
