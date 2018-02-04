using System;

namespace Delegate
{
    class Program
    {
        delegate String DelegateWithFunction(String firstName, String lastName);
        static DelegateWithFunction dwf = Fullname;

        delegate String DelegateWithDelegate(String firstName, String lastName);
        delegate String DelegateWithLambda(String firstName, String lastName);

        //Multiple function subscription
        delegate void TestDel();


        static void Main(string[] args)
        {
            //1.
            String info = "1. - Call delegate function with delegate: \t";
            DelegateWithDelegate dwd = new DelegateWithDelegate(
                delegate (String firstName, String lastName)
                {
                    Console.Write(info);
                    return firstName + " " + lastName;
                });
            Console.WriteLine("{0}",
                              dwd.Invoke("Attila", "Dekany"));

            //2.
            info = "2. - Call delegate function with labda: \t";
            DelegateWithLambda dwl = (firstName, lastName) => info + firstName + " " + lastName;
            Console.WriteLine("{0}",
                              dwl.Invoke("Attila", "Dekany"));


            //3. 
            String fullName = dwf.Invoke("Attila", "Dekany");
            Console.WriteLine("{0}", fullName);

            //Multiple
            Program p = new Program();
            TestDel td = new TestDel(FirstFunction); //OR TestDel td = FirstFunction;
            td += SecondFunction;
            td.Invoke();

            Console.WriteLine("\nCall directly");
            System.Delegate[] delegates = td.GetInvocationList();
            if(delegates[1] != null)
            delegates[1].DynamicInvoke(new object[] { });
        }

        static String Fullname(String firstName, String lastName)
        {
            Console.Write("3. - Call delegate function with function: \t");
            return firstName + " " + lastName;
        }

        static void FirstFunction()
        {
            Console.WriteLine("FirstFunction was called.");
        }
        static void SecondFunction()
        {
            Console.WriteLine("SecondFunction was called.");
        }
    }
}
