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
        static List<Student> students = new List<Student>
            {
                new Student("Колганов", "Богдан", "Евгеньевич", 2004, 2, "АВТ-313"),
                new Student("Маст", "Денис", "Евгеньевич", 2005, 2, "АВТ-313"),
                new Student("Гидульянов", "Кирилл", "Unknown", 2006, 2, "АВТ-313"),
                new Student("Иванов", "Иван", "Иванович", 2003, 4, "ИВ-15"),
                new Student("Кунц", "Богдан", "Владимирович", 2004, 3, "ФТ-124")
            };
        static string[] month = { "June", "Jule", "August", "September", "October", "November", "December", "January", "February", "March", "April", "May" };
        static void Main(string[] args)
        {
            //Task1_0();
            //Task1_1();
            //Task1_2();
            //Task1_3();
            Task4();
        }

        private static void Task1_0()
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
        private static void Task1_1()
        {

            var selectmonth = from m in month
                              where m == "June" || m == "Jule" || m == "August" || m == "December" || m == "January" || m == "February"
                              select m;
            foreach (var m in selectmonth)
            {
                Console.WriteLine(m);
            }
        }

        private static void Task1_2()
        {
            var selectmonth = from m in month
                              orderby m
                              select m;

            foreach (var m in selectmonth)
            {
                Console.WriteLine(m);
            }
        }

        private static void Task1_3()
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

        private static void Task4()
        {
            Console.Clear();
            Console.WriteLine("Список студентов:\n" +
                "1 - Вывести список студентов заданного курса\n" +
                "2 - Вывести самого молодого студента\n" +
                "3 - Вывести количество студентов заданной группы\n" +
                "4 - Вывести первого студента с заданным именем\n" +
                "5 - Вывести список студентов, упорядоченных по фамилии\n" +
                "0 - Выход"
                );
            Console.Write("Введите номер операции -> ");
            int choise = -1;
            try
            {
                choise = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choise)
                {
                    case 1:
                        List<Student> tmp = FindStudentsByCourse();
                        if (tmp.Count == 0)
                            Console.WriteLine("На заданном курсе нет человек");
                        else PrintList(tmp);
                        break;
                    case 2:
                        Console.WriteLine(FindYungestStudent().ToString());
                        break;
                    case 3:
                        Console.Write("Введите группу -> ");
                        string group = Console.ReadLine();
                        int count = FindCountOfStudentsInGroup(group);
                        if (count > 0)
                            Console.WriteLine($"В группе {group} {count} человек");
                        else
                            Console.WriteLine("Заданная группа не найдена!");
                        break;
                    case 4:
                        Console.Write("Введите имя студента -> ");
                        string name = Console.ReadLine();
                        Student student = FindFirstStudentByFirstname(name);
                        if (student is null)
                            Console.WriteLine("Студент с заданным именем не найден!");
                        else
                            Console.WriteLine(student.ToString());
                        break;
                    case 5:
                        PrintList(OrderStudentsByLastname());
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Ошибка! Попробуйте снова.");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Ошибка! Попробуйте снова.");
            }
            Console.WriteLine("Нажмите Enter чтобы продолжить...");
            Console.ReadLine();
            Task4();
        }
        static List<Student> FindStudentsByCourse()
        {
            try
            {
                Console.Write("Введите номер курса -> ");
                int course = Convert.ToInt32(Console.ReadLine());
                return students.FindAll((s) => { return s.Course == course; });
            }
            catch
            {
                Console.WriteLine("Ошибка! Введите номер курса еще раз.");
                return FindStudentsByCourse();
            }
        }
        static Student FindYungestStudent()
        {
            var studentsInList = students.OrderBy((s) => { return s.Birth; });
            return studentsInList.First();

        }
        static int FindCountOfStudentsInGroup(string group)
        {
            return students.FindAll((s) => { return s.Group.ToLower() == group.ToLower(); }).Count;
        }
        static Student FindFirstStudentByFirstname(string name)
        {
            return students.FirstOrDefault((s) => { return s.Firstname.ToLower() == name.ToLower(); });
        }
        static List<Student> OrderStudentsByLastname()
        {
            return students.OrderBy((s) => { return s.Lastname; }).ToList();
        }
        static void PrintList(List<Student> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

