using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleModel.Reader
{
    public class JsonValuesReader : IReader<List<ValuesModel>>
    {
        public List<List<ValuesModel>> Read(string path)
        {
            return JsonConvert.DeserializeObject<List<List<ValuesModel>>>(File.ReadAllText(path));
        }
    }
}
