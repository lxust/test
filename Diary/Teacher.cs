using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class Teacher
    {
        public Teacher(string? name, string? surname, string? subject, string password, string login)
        {
            Name = name;
            Surname = surname;
            Subject = subject;
            Puples = new List<Puple>();
            Password = password;
            Login = login;
        }
        public string? Name;