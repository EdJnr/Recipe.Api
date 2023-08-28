using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Dtos.Comments
{
    public class GetCommentDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? AddedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
