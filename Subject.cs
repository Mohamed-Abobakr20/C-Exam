using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C__Exam
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam SubjectExam { get; set; }

        public Subject(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }

        public void CreatExam()
        {
            int examType, time, numberOfQuestions;
            do
            {
                Console.WriteLine("Please Enter Type OF Exam 1 For Final || 2 For Practical");
            } while (!(int.TryParse(Console.ReadLine(), out examType) && (examType is 1 or 2)));

            do
            {
                Console.WriteLine("Please Enter Time OF Exam Between 30 and 180 Minutes");
            } while (!(int.TryParse(Console.ReadLine(), out time) && (time >= 30 && time <= 180)));
            do
            {
                Console.WriteLine("Please Enter Number OF Questions");
            } while (!(int.TryParse(Console.ReadLine(), out numberOfQuestions) && (numberOfQuestions >0)));

            if(examType == 1)
            {
                SubjectExam = new FinalExam(time, numberOfQuestions);

            }else
                SubjectExam = new PracticalExam(time, numberOfQuestions);

            Console.Clear();
            SubjectExam.CreateListOfQuestions();
        }
    }
}
