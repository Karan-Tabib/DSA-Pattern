
namespace Learning.CSharpConcepts
{
    public class CEmployee
    {
        public int Id;
        public string name;

        public CEmployee(int id,string empname)
        {
            this.Id = id;
            this.name = empname;
        }
    }
    internal class ShallowDeepCopy
    {

        public CEmployee[] Employees;
        public ShallowDeepCopy()
        {
            Employees = new CEmployee[2];
            Employees[0] = new CEmployee(1, "karan");
            Employees[1] = new CEmployee(2, "Tabib");
        }
        public void CreaeteShallowCopy()
        {
            Console.WriteLine("-----------------SHALLOW COPY----------------------------");
            Display(Employees);
            CEmployee[] shallowEmps = (CEmployee[])Employees.Clone();
            shallowEmps[0].name = "Sagar";
            Display(shallowEmps);
            Display(Employees);
        }

        public void CreaeteDeepCopy()
        {
            Console.WriteLine("-----------------DEEP Copy----------------------------");
            Display(Employees);
            CEmployee[] deepCopy = new CEmployee[Employees.Length];
            int count = 0;
            for (int i=0;i< Employees.Length;i++)
            {
                deepCopy[count++] = new CEmployee(Employees[i].Id, Employees[i].name);
            }
            deepCopy[0].name = "Myname";
            Display(deepCopy);
            Display(Employees);
        }

        public void Display(CEmployee[] emps)
        {
            foreach(CEmployee e in emps) { 
                Console.WriteLine("ID->"+e.Id+" Name->" +e.name);
            }
        }

        public static void Main_Method(string[] args)
        {
            ShallowDeepCopy obj= new ShallowDeepCopy();
            obj.CreaeteShallowCopy();
            obj.CreaeteDeepCopy();
            Console.WriteLine();
            
        }
    }
}
