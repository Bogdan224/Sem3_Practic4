using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prac_4
{
    internal class Program
    {
        static string[] month = { "June", "Jule", "August", "September", "October", "November", "December", "January", "February", "March", "April", "May" };
        static void Main(string[] args)
        {
            //Task10();
            //Task11();
            //Task12();
            Task13();
        }

       private static void Task10()
        {
            
            int n = 4;
            var selectmonth = from m in month
                              where m.Length > n
                              select m;

            foreach (var m in selectmonth)
            {
                Console.WriteLine(m);
            }

        }
        private static void Task11()
        {

            var selectmonth = from m in month
                              where m == "June" || m == "Jule" || m == "August" || m == "December" || m == "January" || m == "February"
                              select m;
            foreach (var m in selectmonth)
            {
                Console.WriteLine(m);
            }
        }

        private static void Task12()
        {
            var selectmonth = from m in month
                              orderby m
                              select m;

            foreach (var m in selectmonth)
            {
                Console.WriteLine(m);
            }
        }

        private static void Task13()
        {
            int n = 4;
            var selectmonth = from m in month
                              where m.Length > n && m.ToLower().Contains("u")
                              select m;
            foreach (var m in selectmonth)
            {
                Console.WriteLine(m);
            }
        }
     
        
    }

    
    

    

}

