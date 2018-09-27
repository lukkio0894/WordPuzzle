using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using WordPuzzleAPI.Utils;
using WordPuzzleModel;
using WordPuzzleModel.Decrypter;
using WordPuzzleModel.DTO;
using WordPuzzleModel.Reader;
using WordPuzzleModel.Service;

namespace WordPuzzleAPI.Controllers
{
    public class WordPuzzleController : ApiController
    {
        [HttpGet]
        public string CheckStatus()
        {
            return "OK";
        }

        [HttpGet]
        public IEnumerable<char[]> Puzzle()
        {
            DecrypterService puzzleService = new DecrypterService(new JsonBaseReader(), new JsonValuesReader(), new MarkovDecrypter());
            return puzzleService.GetMatrix(ConfigurationManagerHelper.GetKey("ValuesPath"), ConfigurationManagerHelper.GetKey("BasePath"), ConfigurationManagerHelper.GetKey("CypherPath")).Select(E => E.ToCharArray());
        }

        [HttpPost]
        [HttpOptions]
        public DTOSearchResult SearchWord([FromBody]DTOSearch word)
        {
            PuzzleService service = new PuzzleService();
            return service.SearchWord(word);
        }

        [HttpGet]
        public List<string> GetWords()
        {
            PuzzleService service = new PuzzleService();
            return service.GetWords(ConfigurationManagerHelper.GetKey("WordsPath"));
        }

    }
}
