using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleModel
{
    public class RulesModel
    {
        public int Order { get; set; }
        public bool IsTermination { get; set; }
        public string Source { get; set; }
        public string Replacement { get; set; }
    }
}
