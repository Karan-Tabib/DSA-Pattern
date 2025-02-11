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
    public class SignletonPattern
    {

    }
    internal class Singleton
    {
        private static Singleton _Instance;      //1. Single class whole part
        private List<Country> Countries;
        private static readonly object lockObject = new object();  // 4. Thread Safety
        private Singleton()                     //2. make constructor private
        {

        }

        public static Singleton Instance               // 3. only property available outside world.
        {
            get
            {
                if (_Instance == null)
                {
                    lock (lockObject)
                    {
                        _Instance = new Singleton();
                    }
                }
                return _Instance;
            }
        }

        public List<Country> GetCountries()
        {
            //6. performance lock
            if (Countries == null)
            {
                lock (lockObject)
                {
                    if (Countries == null)              //5 . double Null check
                    {
                        LoadCountries();
                    }
                }
            }
            return Countries;
        }

        private void LoadCountries()
        {

        }
    }

    internal class Country
    {
    }
}
