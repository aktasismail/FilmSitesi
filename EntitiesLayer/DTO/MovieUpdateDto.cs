using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
    public record MovieUpdateDto:MovieValidationDto
    {
        [Required]
        public int Id { get; set; }
    }
}
