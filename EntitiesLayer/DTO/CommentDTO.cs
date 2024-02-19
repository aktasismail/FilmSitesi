using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string? FullName { get; set; }
        public string? CommentText { get; set; }
        public int MovieId { get; set; }
    }
}
