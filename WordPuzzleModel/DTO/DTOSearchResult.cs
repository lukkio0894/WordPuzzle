using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleModel.DTO
{
    public class DTOSearchResult
    {
        public string Word { get; set; }
        public List<LettersModel> Breakdown { get; set; }
    }
}
