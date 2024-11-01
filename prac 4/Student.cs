using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_4
{
    public class Student
    {
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        private int birth;
        public int Birth { 
            get
            {
                return birth;
            }
            set
            {
                if (!(value >= DateTime.Today.Year - 100 && value <= DateTime.Today.Year))
                    throw new ArgumentException();
                birth = value;
            }
        }
        private int course;
        public int Course {
            get
            {
                return course;
            }
            set
            {
                if (!(value > 0 && value <= 5))
                    throw new ArgumentException();
                course = value;
            }
        }
        public string Group { get; set; }

        public Student(string lastname, string firstname, string patronymic, int birth, int course, string group)
        {
            Firstname = firstname;
            Lastname = lastname;
            Patronymic = patronymic;
            Birth = birth;
            Course = course;
            Group = group;
        }

        public override string ToString()
        {
            return $"Фамилия: {Lastname}\n" +
                $"Имя: {Firstname}\n" +
                $"Отчество: {Patronymic}\n" +
                $"Год рождения: {Birth}\n" +
                $"Курс: {Course}\n" +
                $"Группа: {Group}\n";
        }

    }
}
