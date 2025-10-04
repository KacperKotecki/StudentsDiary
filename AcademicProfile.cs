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
                switch (Degree)
                {
                    case "I stopnia licencjat":

                        if (value < 1 || value > 3)
                            throw new ArgumentOutOfRangeException("Dla studiów licencjackich, proszę podać wartość od 1 do 3");
                        else
                            _year = value;

                        break;
                    case "I stopnia inżynier":

                        if (value < 1 || value > 3)
                            throw new ArgumentOutOfRangeException("Dla studiów inżynierskich, proszę podać wartość od 1 do 3");
                        else
                            _year = value;

                        break;
                    case "magisterskie":

                        if (value < 1|| value > 2)
                            throw new ArgumentOutOfRangeException("Dla studiów magisterskich, proszę podać wartość od 1 do 2");
                        else
                            _year = value;

                        break;
                    case "Jednolite magisterskie":

                        if (value < 1 || value > 5)
                            throw new ArgumentOutOfRangeException("Dla studiów jednolitych magisterskich, proszę podać wartość od 1 do 5");
                        else
                            _year = value;

                        break;
                    case "Studia podyplomowe":

                        if (value < 1 || value > 2)
                            throw new ArgumentOutOfRangeException("Dla studiów podyplomowych, proszę podać wartość 1 lub 2");
                        else
                            _year = value;

                        break;
                    case "Doktoranckie":

                        if (value < 1 || value > 4)
                            throw new ArgumentOutOfRangeException("Dla studiów doktoranckich, proszę podać wartość od 1 do 4");
                        else
                            _year = value;

                        break;
                    default:
                        throw new InvalidOperationException($"Nie można ustawić roku, ponieważ stopień studiów {Degree} jest nieznany lub nieustawiony.");
                        break;

                        
                }


            }

        }



        public string Group { get; set; }

        public string Specialization { get; set; }

    }
}
