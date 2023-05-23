using System;
using System.Collections.Generic;

namespace Practice.Delegates
{
    public delegate void TestDelegate();
    public delegate bool TestBoolDelegate(int i);

    class MyClass
    {
        //Delegate Fields
        public TestDelegate? testDelegateFunction;
        public TestBoolDelegate? testBoolDelegateFunction;
        
        //Action is used for function with input but NO RETURN VALUE
        public Action? testAction;
        //Function is used for input WITH RETURN VALUE
        public Func<int, bool>? testFunc;


        //Delegate Functions
        public void MyTestDelegateFunction()
        {
            Console.WriteLine("MyTestDelegateFunction");
        }
        public void MySecondTestDelegateFunction()
        {
            Console.WriteLine("MySecondTestDelegateFunction");
        }
        public bool TestBoolFunction(int i)
        {
            if(i < 5)
            {
                Console.WriteLine("true");
                return true;
            }
            Console.WriteLine("false");
            return false;
        }

        //Exercise Functions
        public void DelegateBasics()
        {
            testDelegateFunction = new TestDelegate(MyTestDelegateFunction);
            testDelegateFunction += MySecondTestDelegateFunction;
            testDelegateFunction();

            testBoolDelegateFunction = TestBoolFunction;
            testBoolDelegateFunction(1);
            testBoolDelegateFunction(10);
        }
        public void AnonymousDelegate()
        {
            //Assigning Anonymous function to delegate
            testDelegateFunction = delegate () { Console.WriteLine("Anonymous Function Called"); };
            testDelegateFunction();
        }
        public void LambdaExpressionDelegate()
        {
            testDelegateFunction = () => { Console.WriteLine("Lambda Expression called"); };
            testDelegateFunction();

            testBoolDelegateFunction = (int i) =>
            {
                if(i < 5)
                {
                    Console.WriteLine("true");
                    return true;
                }
                Console.WriteLine("false");
                return false;
                
            };
            testBoolDelegateFunction(4);
            testBoolDelegateFunction(10);

        }
        public void UsingSystemDelegates()
        {
            testAction = () => { Console.WriteLine("Test Action Called"); };
            testAction();

            testFunc = (int i) => { return i < 5; };
            Console.WriteLine(testFunc(4));
            Console.WriteLine(testFunc(10));
        }

    }
}
