using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleModel.Reader
{
    public class JsonBaseReader : IReader<BaseModel>
    {
        public List<BaseModel> Read(string path)
        {
           return JsonConvert.DeserializeObject<List<BaseModel>>(File.ReadAllText(path));
        }
    }
}
