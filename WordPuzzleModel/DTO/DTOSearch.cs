using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleModel.DTO
{
    public class DTOSearch
    {
        public string word { get; set; }
        public List<List<string>> puzzle { get; set; }
    }
}
