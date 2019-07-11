using System;

namespace Snippets
{
    public class Patterns
    {
        const string UNKNOWN_COLOR = "unknown color";

        #region pattern-simple
        public static void Simple()
        {
            const string color= "LIME";
            var hex = color.ToUpper() switch
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
            Console.WriteLine(hex);
        }
        #endregion

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

        public static void Complex()
        {
            #region pattern-complex
            bool CanCompletePr(PrRequest prRequest)
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

            Console.WriteLine(CanCompletePr(new PrRequest{ Reviewers = 2, Role = "DEV"}));
            Console.WriteLine(CanCompletePr(new PrRequest{ Reviewers = 4, Role = "DEV"}));
            Console.WriteLine(CanCompletePr(new PrRequest{ Reviewers = 0, Role = "TL"}));
            Console.WriteLine(CanCompletePr(new PrRequest{ Reviewers = 14, Role = "STAGIAIRE"}));
            #endregion

        }
    }
}