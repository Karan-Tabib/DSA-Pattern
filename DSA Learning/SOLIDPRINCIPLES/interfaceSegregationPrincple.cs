using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.SOLIDPRINCIPLES
{

    /* INTERFACE SEGRAGATION PRINCIPLE
     * 
     * No Client/ Code should be force to depend on method or properties  which is not concerns with them. 
     * 
     * here reporting is concern with only Read method still he has to implement all method which are not required.
     * creating IDAl object will give access to all method which is also not correct.
     * 
     *Answer
     * creating new interface for read method .split interfaces.
     */
    public interface IDal
    {
        void Add();
        void Remove();
        void Update();
    }
    public interface IReporting
    {
        void Read();
    }
    class SQLDal : IDal, IReporting
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }

    class OracleDal : IDal, IReporting
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }

    class Reporting : IReporting
    {
        public void Read()
        {
            //code
        }
        
    }

    internal class interfaceSegregationPrincple
    {
        static void interfaceSegregationPrincple_Main(string[] args)
        {
            IReporting dal = new Reporting();
            dal.Read();
        }
    }
}
