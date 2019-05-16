using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Data
{
    public class PostingsData
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public string Address { get; set; }

        public DateTime DateAdded { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Descirption { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }

        public string Image { get; set; }
    }
}
