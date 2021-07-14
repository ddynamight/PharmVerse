using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Categories.Models.Results
{
    public class DeleteCategoryCommandResult
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Message { get; set; }

    }
}
