using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string? FullName { get; set; }
        public string? CommentText { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movies Movies { get; set; }

    }
}
