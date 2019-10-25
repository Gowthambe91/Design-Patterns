using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

/*Singleton is a Creational Design pattern, */
namespace SingletonDesignPattern
{
    class SingletonDesignProgram
    {
        static void Main(string[] args)
        {
            SingletonClass singletonA = SingletonClass.getInstance(); /*Generally GC decides when the object needs to cleaned up, so when an object of that class is present - It'll 
                                                                        take up the same instance*/
            singletonA.Dispose(); /*Could not do it -  thought to check*/
            SingletonClass singletonB = SingletonClass.getInstance();

            SingletonSealedClass singletonSealedClassA = new SingletonSealedClass(); /*Difference between sealed class and a class with private constructor, 
                                                                                       Both will not have same object, thats the major difference between sealed and private constructor class
                                                                                       that, sealed can be initialised outside, private constructor class cannot be - and Sealed class cannot be
                                                                                       inherited at all*/
            SingletonSealedClass singletonSealedClassB = new SingletonSealedClass();


            /* SingletonStaticClass singletonStaticClassA = new SingletonStaticClass() //Static Classes cannot have instances, by design Static classes are sealed , so cannot be inherited as well.
             SingletonStaticClass singletonStaticClassB = new SingletonStaticClass() */

            SingletonStaticClass.displayFromSingletonStaticClass();

            if (singletonSealedClassA == singletonSealedClassB)
            {
                Console.WriteLine("\nBoth are same objects");
            }
            else
            {
                Console.WriteLine("Both are not same objects");
            }


            if (singletonA == singletonB)
            {
                Console.WriteLine("\nBoth are same objects");
            }

            Console.ReadLine();
        }
    }

    /*Structural code*/
    class SingletonClass : IDisposable // IDisposable is included to check if Dispose works, but needs some more time to dig in dispose()
    {
        private static SingletonClass _instance;

        private SingletonClass()
        {

        }


        public static SingletonClass getInstance()
        {
            if (_instance == null)
            {
                _instance = new SingletonClass();
            }

            return _instance;
        }

        public void Dispose()
        {
            //Dispose();
            GC.Collect();
            //throw new NotImplementedException();
        }
    }

    /*Difference between sealed class and a class with private constructor*/
    sealed class SingletonSealedClass
    {
        // private static SingletonClass _instance;

        //private SingletonClass()
        //{

        //}


        //public static SingletonClass getInstance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new SingletonClass();
        //    }

        //    return _instance;
        //}
    }

    static class SingletonStaticClass
    {
        public static void displayFromSingletonStaticClass()
        {
            Console.WriteLine("Display From Singleton Static Class");
        }
    }

   /* static class SingletonStaticClass2 : SingletonStaticClass /*Static classes can be derived only from object class
    {

    } */

}
