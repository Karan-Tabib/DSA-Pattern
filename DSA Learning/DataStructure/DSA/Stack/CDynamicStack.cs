using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Stack
{
    public class CDynamicStack : CustomStack
    {
        public CDynamicStack() : base()
        {

        }

        public CDynamicStack(int size) : base(size)
        {

        }
        public override bool push(int item)
        {
            if (isFull())
            {
                //double the array
                int[] temp = new int[data.Length * 2];

                for (int i = 0; i < data.Length; i++)
                {
                    temp[i] = data[i];
                }
                data = temp;

            }

            return base.push(item);
        }

    }
}
