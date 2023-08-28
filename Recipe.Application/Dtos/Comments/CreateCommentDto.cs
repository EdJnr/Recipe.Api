using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Dtos.Comments
{
    public class CreateCommentDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? AddedBy { get; set; }
    }
}
