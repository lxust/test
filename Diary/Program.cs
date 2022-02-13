using Diary;

Teacher? teacher = null;
List<Teacher> teachers = new List<Teacher>();



while (true)
{
    Console.Write(">> ");
    string? command = Console.ReadLine();
    if (command == "/register" && teacher == null)
    {
        string? name;
        string? surname;
        string? subject;
        string? password;
        string? login;

        Console.Write("Введите имя: ");
        name = Console.ReadLine();
        Console.Write("Введите фамилию: ");
        surname = Console.ReadLine();
        Console.Write("Введите предмет: ");
        subject = Console.ReadLine();
        Console.Write("Введите пароль: ");
        password = Console.ReadLine();

        if (password == null)
            continue;

        Console.Write("Введите логин: ");
        login = Console.ReadLine();

        if (login == null)
            continue;

        Teacher t = new Teacher(name, surname, subject, password, login);
        teachers.Add(t);
        teacher = t;
        Console.WriteLine("Успешная регистрация и вход!");
    }
    else if (command == "/login" & teacher == null)
    {
        string? password;
        string? login;

        Console.Write("Введите пароль: ");
        password = Console.ReadLine();

        Console.Write("Введите логин: ");
        login = Console.ReadLine();

        if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
        {
            var t = teachers.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (t == null)
                Console.WriteLine("Неверные данные!");
            else
            {
                teacher = t;
                Console.WriteLine("Успешная авторизация!");
            }

        }
    }
    // Коммент
    else if ((command == "/login" || command == "/register") && teacher != null)
        Console.WriteLine("Выйдите с аккаунта");
    if (teacher != null)
    {
        if (command == "/q")
        {
            teacher = null;
            Console.WriteLine("Успешный выход!");
        }
        else if (command == "/addpuple")
        {
            Console.Write("Введите имя: ");
            string? name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string? surname = Console.ReadLine();
            Console.Write("Введите возраст: ");
            string? stringAge = Console.ReadLine();
            int age = 0;
            string? _class = null;
            if (!Int32.TryParse(stringAge, out age))
            {
                Console.WriteLine("Ошибка данных!");
            }
            else
            {
                Console.Write("Введите класс: ");
                _class = Console.ReadLine();
            }
            
            if (!string.IsNullOrEmpty(_class) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && (age > 5))
            {
                Puple puple = new Puple(name, surname, age, _class);
                if (puple != null)
                    teacher.Puples.Add(puple);
            }
            
        }
        else if (command == "/showpuple")
        {
            Console.WriteLine("Список учеников: ");
            foreach (var puple in teacher.Puples)
            {
                Console.WriteLine($"ФИО: {puple.Surname} {puple.Name}\tКласс: {puple.Class}");
            }
        }
        else if (command == "/addgrade")
        {
            Console.Write("Введите класс: ");
            string? _class = Console.ReadLine();
            //var puples = teacher.Puples.Select(puple => puple.Class == _class).ToList();
            var puples = teacher.Puples.Where(x => x.Class == _class).Select(x => x).ToList();

            Console.WriteLine($"Ученики класса {_class}: ");
            foreach (var puple in puples)
                Console.WriteLine($"\t{puple.Surname} {puple.Name}");

            Console.Write("Введите имя: ");
            string? name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string? surname = Console.ReadLine();

            Puple? _puple = puples.FirstOrDefault(x => x.Name == name && x.Surname == surname);

            if (_puple != null)
            {
                Console.Write("Оценка: ");
                int grade = Convert.ToInt32(Console.ReadLine());
                _puple.Grades.Add(grade);
            }
            else
                Console.WriteLine("Ученик не найден!");
        }
    }
}
