using Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SludinajumuPortals.Models
{
    public class CategoryCatalogModel
    {
        public List<CategoryData> Categories;

        public List<PostingsData> Postings;

        public CategoryData ActiveCategory;

        public PostingsData ActivePosting;
    }
}