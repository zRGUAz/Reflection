using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            student.Name = "Rafael";
            student.University = "FIAP";
            student.RollNumber = 0;

            DisplayPublicProperties(student);

            Console.WriteLine();

            Student student1 = CreateInstance();

            MethodInfo methodInfo = student1.GetType().GetMethod("DisplayInfo");
            methodInfo.Invoke(student1, null);
        }

        public static void DisplayPublicProperties(Student student)
        {
            PropertyInfo[] propriedades = student.GetType().GetProperties();

            foreach (PropertyInfo propriedade in propriedades)
            {
                Console.WriteLine($"{propriedade.Name}: {propriedade.GetValue(student)}");
            }
        }

        public static Student CreateInstance()
        {
            Student student1 = new Student();

            student1.GetType().GetProperty("Name").SetValue(student1, "Leafar");
            student1.GetType().GetProperty("University").SetValue(student1, "UFABC");
            student1.GetType().GetProperty("RollNumber").SetValue(student1, 1);

            return student1;
        }
    }
}