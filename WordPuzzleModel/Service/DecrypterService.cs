using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPuzzleModel.Decrypter;
using WordPuzzleModel.Reader;

namespace WordPuzzleModel.Service
{
    public class DecrypterService
    {
        private readonly IReader<BaseModel> BaseReader;
        private readonly IReader<List<ValuesModel>> ValuesReader;
        private readonly IDecrypter Decrypter;

        public DecrypterService(IReader<BaseModel> baseReader, IReader<List<ValuesModel>> valuesReader, IDecrypter decrypter)
        {
            this.BaseReader = baseReader;
            this.ValuesReader = valuesReader;
            this.Decrypter = decrypter;
        }

        public List<string> GetMatrix(string valuesPath, string rulesPath, string cyphersPath)
        {
            List<List<RulesModel>> rules = LoadRules(valuesPath, rulesPath);
            string[] cyphers = JsonConvert.DeserializeObject<string[]>(File.ReadAllText(cyphersPath));
            return Decrypter.Decrypt(rules, cyphers);
        }


        private List<List<RulesModel>> LoadRules(string valuesPath, string rulesPath)
        {
            List<List<ValuesModel>> values = ValuesReader.Read(valuesPath);
            List<BaseModel> rules = BaseReader.Read(rulesPath);
            List<List<RulesModel>> finalRules = values.Select(L => L.Select(V => { BaseModel rule = rules[V.Rule]; return new RulesModel() { Source = rule.Source, Replacement = rule.Replacement, Order = V.Order, IsTermination = V.IsTermination }; }).OrderBy(R => R.Order).ToList()).ToList();
            return finalRules;
        }


    }
}
