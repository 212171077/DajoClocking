using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DajoChicking.Services
{
    public class PeopleServices
    {
        public List<Person>getPeople()
        {
            var list = new List<Person>
            {
                 new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                }
            };

            return list;
        }
    }
}
