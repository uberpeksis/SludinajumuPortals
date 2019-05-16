using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Data
{
    public class CategoryData
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? ParentCategoryId { get; set; }

        public int Count { get; set; }
    }
}
