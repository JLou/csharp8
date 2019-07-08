using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoCsharp8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly INumberFactService _numberFactService;

        public ValuesController(INumberFactService numberFactService)
        {
            _numberFactService = numberFactService;
        }

        // GET api/values
        [HttpGet("asyncstream/{amount}")]
        public async Task<IActionResult> GetAsync([FromRoute] int amount)
        {
            var results = new List<string>();
            await foreach (var fact in _numberFactService.GetFactsAsync(amount))
            {
                results.Add($"Here's a fun fact: {fact}");
            }
            return Ok(results);
        }


        [HttpGet("pattern-matching/{color}")]
        public ActionResult<string> PatternMatchingSimple([FromRoute][Required] string color)
        {
            const string UNKNOWN_COLOR = "unknown color";
            var hex = color?.ToUpper() switch
            {
                "NAVY" => "#001f3f",
                "BLUE" => "#0074D9",
                "AQUA" => "#7FDBFF",
                "TEAL" => "#39CCCC",
                "OLIVE" => "#3D9970",
                "GREEN" => "#2ECC40",
                "LIME" => "#01FF70",
                "YELLOW" => "#FFDC00",
                "ORANGE" => "#FF851B",
                "RED" => "#FF4136",
                "MAROON" => "#85144b",
                "FUCHSIA" => "#F012BE",
                "PURPLE" => "#B10DC9",
                "BLACK" => "#111111",
                "GRAY" => "#AAAAAA",
                "SILVER" => "#DDDDDD",
                _ => UNKNOWN_COLOR
            };

            if (hex == UNKNOWN_COLOR)
            {
                return BadRequest(hex);
            }
            return hex;
        }

        [HttpGet("pattern-matching-advanced")]
        public ActionResult<bool> CanCompletePr([FromQuery] PrRequest prRequest)
        {
            return prRequest switch
            {
                (Job.TechLead, _) => true,
                (Job.Developpeur, var reviewers) when reviewers >= 4 => true,
                (Job.Developpeur, var reviewers) when reviewers < 4 => false,
                (Job.Stagiaire, _) => false,
                _ => false
            };
        }
    }

    public enum Job
    {
        TechLead,
        Developpeur,
        Stagiaire,
        Alternant
    }

    public class PrRequest
    {
        public string Role { get; set; }
        public int Reviewers { get; set; }

        public void Deconstruct(out Job role, out int reviewers)
        {
            role = Role.ToUpper() switch
            {
                "TL" => Job.TechLead,
                "DEV" => Job.Developpeur,
                "STAGIAIRE" => Job.Stagiaire,
                _ => Job.Alternant
            };

            reviewers = Reviewers;
        }
    }

}

internal class NumberFactService : INumberFactService
{
    private readonly IHttpClientFactory _clientFactory;

    public NumberFactService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async IAsyncEnumerable<string> GetFactsAsync(int amount)
    {
        var client = _clientFactory.CreateClient("proxy");
        var unusedNumbersList = Enumerable.Range(1, 100).ToList();
        unusedNumbersList.Shuffle();
        var unusedNumbers = new Stack<int>(unusedNumbersList.Take(amount));

        while (unusedNumbers.Count > 0)
        {
            var item = unusedNumbers.Pop();
            var response = await client.GetAsync($"http://numbersapi.com/{item}");
            yield return await response.Content.ReadAsStringAsync();
        }
    }
}



public interface INumberFactService
{
    public IAsyncEnumerable<string> GetFactsAsync(int amount);
}

public static class IListExtensions
{
    private static Random rng = new Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

}
