using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleModel
{
    public class PuzzleModel
    {
        public List<LettersModel> Letters { get; set; }

        public PuzzleModel()
        {
            this.Letters = new List<LettersModel>();
        }

        public void FillPuzzle(List<string> matrix)
        {
            int row = 0;
            foreach (string line in matrix)
            {

                for (int i = 0; i < line.Length; i++)
                {
                    string letter = line.Substring(i, 1);
                    LettersModel letterM = new LettersModel() { Column = i, Row = row, Value = letter };
                    Letters.Add(letterM);
                }
                row++;
            }

        }


        public Stack<LettersModel> ContainsWord(string word)
        {
            Stack<LettersModel> stack = new Stack<LettersModel>();
            ContainsWord(word, 1, Letters.Where(L => L.Value.Equals(word.Substring(0, 1))).ToList(), stack);
            return stack;
        }

        public bool ContainsWord(string word, int index, List<LettersModel> matches, Stack<LettersModel> stack)
        {
            if (index == word.Length)
            {
                stack.Push(matches.FirstOrDefault());
                return true;
            }
            foreach (var lastMatch in matches)
            {
                List<LettersModel> newMatches = Letters.Where(L =>
              (L.Row == lastMatch.Row - 1 && L.Column == lastMatch.Column) ||
              (L.Row == lastMatch.Row - 1 && L.Column == lastMatch.Column - 1) ||
              (L.Row == lastMatch.Row - 1 && L.Column == lastMatch.Column + 1) ||
              (L.Row == lastMatch.Row && L.Column == lastMatch.Column - 1) ||
              (L.Row == lastMatch.Row && L.Column == lastMatch.Column + 1) ||
              (L.Row == lastMatch.Row + 1 && L.Column == lastMatch.Column) ||
              (L.Row == lastMatch.Row + 1 && L.Column == lastMatch.Column - 1) ||
              (L.Row == lastMatch.Row + 1 && L.Column == lastMatch.Column + 1)).ToList();
                newMatches = newMatches.Where(L => L.Value.Equals(word.Substring(index, 1))).ToList();
                if (newMatches.Count > 0)
                {
                    stack.Push(lastMatch);
                    if(ContainsWord(word, index + 1, newMatches, stack))
                    {
                        return true;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }

           
            return false;
        }
    }
}
