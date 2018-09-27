using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleModel.Decrypter
{
    public class MarkovDecrypter : IDecrypter
    {
        public List<string> Decrypt(List<List<RulesModel>> rules, string[] cyphers)
        {
            for (int i = 0; i < cyphers.Length; i++)
            {
                List<RulesModel> cypherRules = rules[i];
                cyphers[i] = MarkovAlgorithm(cypherRules, cyphers[i]);
            }
            return cyphers.ToList();
        }

        public string MarkovAlgorithm(List<RulesModel> rules, string cypher)
        {
            RulesModel rule = rules.FirstOrDefault(R => cypher.Contains(R.Source));
            if (rule == null)
            {
                return cypher;
            }
            cypher = cypher.Replace(rule.Source, rule.Replacement);
            if (rule.IsTermination)
            {
                return cypher;
            }
            return MarkovAlgorithm(rules, cypher);
        }

        private List<string> LoadData()
        {
            List<List<ValuesModel>> values = JsonConvert.DeserializeObject<List<List<ValuesModel>>>(File.ReadAllText(@"C:\Users\LUIS_\source\repos\MarkovAlgo\MarkovAlgo\values.json"));
            List<BaseModel> rules = JsonConvert.DeserializeObject<List<BaseModel>>(File.ReadAllText(@"C:\Users\LUIS_\source\repos\MarkovAlgo\MarkovAlgo\base.json"));
            List<List<RulesModel>> finalRules = values.Select(L => L.Select(V => { BaseModel rule = rules[V.Rule]; return new RulesModel() { Source = rule.Source, Replacement = rule.Replacement, Order = V.Order, IsTermination = V.IsTermination }; }).OrderBy(R => R.Order).ToList()).ToList();
            string[] cyphers = JsonConvert.DeserializeObject<string[]>(File.ReadAllText(@"C:\Users\LUIS_\source\repos\MarkovAlgo\MarkovAlgo\cypher.json"));
            for (int i = 0; i < cyphers.Length; i++)
            {
                List<RulesModel> cypherRules = finalRules[i];
                cyphers[i] = MarkovAlgorithm(cypherRules, cyphers[i]);
            }

            return cyphers.ToList();
        }


    }
}
