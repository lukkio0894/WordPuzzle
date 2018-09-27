using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleModel.Decrypter
{
    public interface IDecrypter
    {
        List<string> Decrypt(List<List<RulesModel>> rules, string[] cyphers);
    }
}
