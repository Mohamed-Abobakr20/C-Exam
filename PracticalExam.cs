using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Exam
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int _time, int _numberOfQuestions) : base(_time, _numberOfQuestions)
        {
        }

        public override void CreateListOfQuestions()
        {
            Questions = new MCQQuestion[NumberOfQuestions];
            for (int i = 0; i < Questions.Length; i++)
            {
                Questions[i] = new MCQQuestion();
                Questions[i].AddQuestion();
            }
            Console.Clear();
        }

        public override void ShowExam()
        {
            foreach (var ques in Questions)
            {
                Console.WriteLine(ques);
                for (int i = 0; i < ques.Answers.Length; i++)
                {
                    Console.WriteLine(ques.Answers[i]);
                }
                Console.WriteLine("==================================");
                int useranwserID;
                do
                {
                    Console.WriteLine("Please Enter Your Answer ID");
                } while (!(int.TryParse(Console.ReadLine(), out useranwserID) && (useranwserID is 1 or 2 or 3)));

                ques.UserAnswer.Id = useranwserID;
                ques.UserAnswer.Text = ques.Answers[useranwserID - 1].Text;
            }

            Console.Clear() ;
            Console.WriteLine("Right Answers");
            for (int i = 0;i < Questions.Length;i++)
            {
                Console.WriteLine($"Question {i + 1} : {Questions[i].Body}");
                Console.WriteLine($"Right Answer IS ==> {Questions[i].RightAnswer.Text}");
                Console.WriteLine("=====================================================");
            }
        }
    }
}
