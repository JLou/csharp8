# Pattern matching

## Simple case with constants: 

```cs --project ./Snippets/Snippets.csproj --source-file ./Snippets/PatternMatching.cs --region pattern-simple
```

## More complex case
Showing off destructuring, tuple matching, property patterns.

Here are the models we're going to use:
```cs
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
```

The rule is, TechLeads don't need reviewers, developpers need 4, and temps can't validate PRs in any case. This translates into the following code:
```cs --project ./Snippets/Snippets.csproj --source-file ./Snippets/PatternMatching.cs --region pattern-complex
```

#### Next: [Async Streams  &raquo;](./asynchronous-streams.md)   Prev: [Setup  &laquo;](./setup.md)   Home: [Home](readme.md)