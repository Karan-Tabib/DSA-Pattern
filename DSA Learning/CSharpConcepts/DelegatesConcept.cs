using System.IO;
using System.Threading.Tasks;
namespace Learning.CSharpConcepts
{
    internal class DelegatesConcept
    {
        static void DelegatesConcept_Main(string[] args)
        {
            MyFileSearch obj = new MyFileSearch();
            obj.publisher += Subscriber1;
            obj.publisher += Subscriber2;
            obj.publisher = null;
            Console.WriteLine("File search started ...");

            Task.Run(() => obj.Serach("D:\\Study"));
            Console.WriteLine("Main thread Running!!!!");
            Console.ReadLine();

        }

        public static  void Subscriber1(string filename)
        {
            Console.WriteLine(filename);
        }
        public static void Subscriber2(string filename)
        {
            Console.WriteLine(filename);
        }
    }

    public class MyFileSearch
    {
        public delegate void FileSearchDelegate(string filename);
        public FileSearchDelegate publisher = null;

        public void Serach(string path)
        {
            try
            {
                    foreach(string directory in Directory.GetDirectories(path)){
                        foreach(string filename in Directory.GetFiles(directory))
                        {
                            publisher(filename);
                        }
                    }
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
