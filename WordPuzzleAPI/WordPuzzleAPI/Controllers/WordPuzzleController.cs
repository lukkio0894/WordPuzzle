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
        public IEnumerable<char[]> Puzzle()
        {
            try
            {
                DecrypterService puzzleService = new DecrypterService(new JsonBaseReader(), new JsonValuesReader(), new MarkovDecrypter());
                return puzzleService.GetMatrix(ConfigurationManagerHelper.GetKey("ValuesPath"), ConfigurationManagerHelper.GetKey("BasePath"), ConfigurationManagerHelper.GetKey("CypherPath")).Select(E => E.ToCharArray());
            }
            catch (Exception)
            {
                return new List<char[]>();
            }
        }

        [HttpPost]
        [HttpOptions]
        public DTOSearchResult SearchWord([FromBody]DTOSearch word)
        {
            try
            {
                PuzzleService service = new PuzzleService();
                return service.SearchWord(word);
            }
            catch (Exception)
            {
                return new DTOSearchResult() { Breakdown = new List<LettersModel>(), Word = string.Empty };
            }
        }

        [HttpGet]
        public List<string> GetWords()
        {
            try
            {
                PuzzleService service = new PuzzleService();
                return service.GetWords(ConfigurationManagerHelper.GetKey("WordsPath"));
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

    }
}
