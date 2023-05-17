using System.Globalization;
using System.IO;

namespace Laba5_2semestr.klym;

public partial class Task2
{


    struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char sex;
        public string dateOfBirth;

        // конструктор для структури Student
        public Student(string lineWithAllData)
        {
            string[] data = lineWithAllData.Split(' '); // роздiлити строку з даними про студента за пробiлами
            surName = data[0];
            firstName = data[1];
            patronymic = data[2];
            sex = Convert.ToChar(data[3]);
            dateOfBirth = data[4];
        }
    }

    public void Main()
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        string fileName = "data.txt"; // iм'я файлу з даними про студентiв
        int currentYear = DateTime.Now.Year; // поточний рiк
        int legalAge = 18; // вiк, з якого можна вступати до вузу

        // Перевiрити, чи iснує файл
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found!");
            return;
        }

        // Вiдкрити файл
        StreamReader streamReader = new StreamReader(fileName);

        // Прочитати перший рядок (заголовок) i проiгнорувати його
        string line = streamReader.ReadLine();

        // Прочитати наступнi рядки та створити з них масив студентiв
        Student[] students = new Student[0];
        while ((line = streamReader.ReadLine()) != null)
        {
            Student student = new Student(line);

            // Перевiрити, що студент є чоловiком та йому виповнилося 18 рокiв
            DateTime dateOfBirth = DateTime.ParseExact(student.dateOfBirth, "dd.MM.yyyy", null);
            int age = currentYear - dateOfBirth.Year;
            if (student.sex == 'M' || student.sex == 'М' || student.sex == 'Ч' && age >= legalAge)
            {
                // Додати студента до масиву
                Array.Resize(ref students, students.Length + 1);
                students[students.Length - 1] = student;
            }
        }

        // Закрити файл
        streamReader.Close();

        // Вивести список студентiв
        Console.WriteLine("Список студентiв старшi 18 рокiв:");
        foreach (Student student in students)
        {
            Console.WriteLine($"{student.surName} {student.firstName} {student.patronymic} {student.sex} {student.dateOfBirth}");
        }
        Console.WriteLine();
    }
}


