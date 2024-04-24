using System.Diagnostics;
using System.Security.Authentication.ExtendedProtection;

namespace C__Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject(1, "C#");
            sub1.CreatExam();

            char x;

            do
            {
                Console.WriteLine("DO you want To Start Exam ( Y | N )");
            } while (!(char.TryParse(Console.ReadLine(),out x) && (x =='y'||x=='n')));

            if(x == 'y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                sub1.SubjectExam.ShowExam();
                sw.Stop();
                Console.WriteLine($"Time You Take IS {sw.Elapsed}");
            }
            Console.WriteLine("Thank You");

        }
        

    }
}