using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Learning.DesignPatterns
    {
        /*
         * Singleton pattern helps to create single instance of object/class.
         * 
         */
   
        internal class LazySingleton
        {
            private static LazySingleton _Instance;      //1. Single class whole part
            private Lazy<List<Country>> Countries;
            private static readonly object lockObject = new object();  // 4. Thread Safety
            private LazySingleton()                     //2. make constructor private
            {
                Countries = new Lazy<List<Country>>(()=>LoadCountries());
            }

            public static LazySingleton Instance               // 3. only property available outside world.
            {
                get
                {
                    if (_Instance == null)
                    {
                        lock (lockObject)
                        {
                            _Instance = new LazySingleton();
                        }
                    }
                    return _Instance;
                }
            }

            public List<Country> GetCountries()
            {
               
                return Countries.Value;
            }

            private List<Country> LoadCountries()
            {
               List<Country> con = new List<Country>();
                con.Add(new Country("INDIA"));
                con.Add(new Country("UK"));
                con.Add(new Country("US"));

                return con;
            }
        }

        internal class Country
        {
            public string Name { get; set; }    
            public Country(string name)
            {
                Name = name;
            }
        }
    }

    internal class LazySingletonpattern
    {
    }
}
