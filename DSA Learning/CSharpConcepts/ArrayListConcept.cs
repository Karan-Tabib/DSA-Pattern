using System.Collections;
namespace Learning.CSharpConcepts
{
    internal class ArrayListConcept
    {
        static void Main_Method(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(4);
            arrayList.Remove(1);
            

            ArrayList arralist= new ArrayList { 1,2,3,4,5 };
            List<int> list = arrayList.Cast<int>().ToList();
            List<int> list1 = arrayList.OfType<int>().ToList();
        }
    }
}
