using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10253051HW1
{
    class ArrayBasedStacks<T>
    {
  
       private T[] values;
       public int top;

        public ArrayBasedStacks()
        {
           // values=new T[];
            top = -1;
        }
        public ArrayBasedStacks(int size)
        {
            values = new T[size];
            top = -1;
        }
        public void Push(T item)
        {
            values[++top] = item;

        }
        public T Pop()
        {
            if (isEmpty())
            {
                throw new Exception("Stack is Empty");
                
                
            }
            return values[top--];
            
        }
        public T Peek()
        {
            if (isEmpty())
            {
                throw new Exception("Stack is Empty");


            }
            return values[top];


        }
        public bool isEmpty()
        {
            if (top == -1)
                return true;
            
            return false; 
        
        }
        public bool isFull()
        {
            if (top > -1)
                return true;
            
            return false; }
        public int Count()
        {
            if (top != -1)
                return top + 1;
            
            return -1;
        
        }

       

        public T get(int i)
        {

            if (i == 0)
                throw new Exception("error...!");


                return values[i - 1];
        }

      
    }
}
