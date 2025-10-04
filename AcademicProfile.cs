using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsDiary
{
    public class AcademicProfile
    {
        public string ProfileName { get; set; }

        public string Degree { get; set; }// typ studiów (inż, mgr, lic)
        private int _year;
        
        public int Year
        {
            get
            {
                return _year;
            }

            set
            {

                
                if (Degree != null&& AcademicDataSources.YearForDegree.ContainsKey(Degree))
                {
                    var (Min, Max) = AcademicDataSources.YearForDegree[Degree];
                    if (value < Min || value > Max)
                    {
                        throw new ArgumentOutOfRangeException($"Rok studiów musi być w zakresie od {Min} do {Max} dla studiów {Degree}");
                    }
                    else
                    {
                        _year = value;
                    }
                }
                else
                {
                    throw new InvalidOperationException("Ustaw profil studiów przed ustawieniem roku studiów.");
                    
                }

                


            }

        }



        public string Group { get; set; }
        public string Specialization { get; set; }

        public override string ToString()
        {
            return $"{ProfileName}, {Degree}, rok {Year}, grupa {Group}, specjalizacja: {Specialization}";
        }

    }
}
