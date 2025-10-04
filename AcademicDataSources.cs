using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDiary
{
    public static class AcademicDataSources
    {
        public static readonly List<string> Profiles = new List<string> {
        "Informatyka",
        "Automatyka i Robotyka",
        "Elektronika i Telekomunikacja",
        "Mechatronika",
        "Budownictwo",
        "Architektura",
        "Zarządzanie",
        "Finanse i Rachunkowość",
        "Psychologia"
        };


        public static readonly List<string> Degrees = new List<string> {
            "I stopnia licencjat",
            "I stopnia inżynier",
            "magisterskie",
            "Jednolite magisterskie",
            "Studia podyplomowe",
            "Doktoranckie"  };


        public static readonly Dictionary<string, (int Min, int Max)> YearForDegree = new Dictionary<string, (int Min, int Max)>
        {
            { "I stopnia licencjat", (1, 3) },
            { "I stopnia inżynier", (1, 3) },
            { "magisterskie", (1, 2) },
            { "Jednolite magisterskie", (1, 5) },
            { "Studia podyplomowe", (1, 2) },
            { "Doktoranckie", (1, 4) }
        };

        public static readonly List<string> Groups = new List<string>
        {
            "UL_S1A", "UL_K1B", "UL_G1C","UL_M2D", "UL_P2E", "UL_T3F"
        };


        public static readonly Dictionary<string, List<string>> SpecializationsByProfile = new Dictionary<string, List<string>>
        {
            {"Informatyka", new List<string> { "Programowanie", "Bazy danych", "Cyberbezpieczeństwo" } },
            { "Automatyka i Robotyka", new List<string> { "Robotyka przemysłowa", "Automatyzacja procesów", "Systemy sterowania" } },
            { "Elektronika i Telekomunikacja", new List<string> { "Telekomunikacja mobilna", "Elektronika cyfrowa"} },
            { "Mechatronika", new List<string> { "Systemy mechatroniczne", "Robotyka medyczna", "Automatyzacja produkcji" } },
            { "Budownictwo", new List<string> { "Konstrukcje budowlane", "Inżynieria środowiska", "Zarządzanie budową" } },
            { "Architektura", new List<string> { "Projektowanie architektoniczne", "Urbanistyka", "Architektura krajobrazu" } },
            { "Zarządzanie", new List<string> { "Zarządzanie projektami", "Zarządzanie zasobami ludzkimi", "Marketing" } },
            { "Finanse i Rachunkowość", new List<string> { "Rachunkowość finansowa", "Analiza finansowa", "Podatki" } },
            { "Psychologia", new List<string> { "Psychologia kliniczna", "Psychologia pracy i organizacji", "Psychologia rozwojowa" } }

        };
    }

}
