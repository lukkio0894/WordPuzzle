using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPuzzleModel.DTO;

namespace WordPuzzleModel.Service
{
    public class PuzzleService
    {
        public  DTOSearchResult SearchWord(DTOSearch word)
        {
            if (word != null)
            {
                PuzzleModel puzzle = new PuzzleModel();
                puzzle.FillPuzzle(word.puzzle.Select(E => string.Concat(E)).ToList());
                var z = puzzle.ContainsWord(word.word);
                DTOSearchResult result = new DTOSearchResult() { Word = word.word, Breakdown = z.Reverse().ToList() };
                return result;
            }
            return null;
        }

        public List<string> GetWords(string path)
        {
            return JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(path));
        }
    }
}
