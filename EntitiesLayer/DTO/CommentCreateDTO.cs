using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
    public record CommentCreateDTO
    {
        public string? FullName { get; set; }
        public string? CommentText { get; set; }
        public int MovieId { get; set; }
    }
}
