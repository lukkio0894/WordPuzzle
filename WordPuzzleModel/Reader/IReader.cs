using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleModel.Reader
{
    public interface IReader <T>
    {
        List<T> Read(string path);
    }
}
