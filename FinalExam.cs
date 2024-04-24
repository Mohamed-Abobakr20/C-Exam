using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Exam
{
    public class FinalExam : Exam
    {
        public FinalExam(int _time, int _numberOfQuestions) : base(_time, _numberOfQuestions)
        {
        }

        public override void CreateListOfQuestions()
        {
            Questions = new Question[NumberOfQuestions];
            for (int i = 0; i < Questions.Length; i++)
            {
                int choice;
                do
                {
                    Console.WriteLine("Please Enter Type Of Question You Whanr (1 ==> MCQ || 2 ==> True Or Flase)");

                } while (!(int.TryParse(Console.ReadLine(), out choice) && (choice is 1 or 2)));

                Console.Clear();

                if (choice == 1)
                {
                    Questions[i] = new MCQQuestion();
                    Questions[i].AddQuestion();
                }
                else
                {
                    Questions[i] = new TFQuestion();
                    Questions[i].AddQuestion();
                }

            }
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

                int useranwserID;

                if (ques.GetType() == typeof(MCQQuestion))
                {
                    do
                    {
                        Console.WriteLine("Please Enter Your Answer ID");
                    } while (!(int.TryParse(Console.ReadLine(), out useranwserID) && (useranwserID is 1 or 2 or 3)));
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Please Enter Your Answer ID 1 For True || 2 For False");
                    } while (!(int.TryParse(Console.ReadLine(), out useranwserID) && (useranwserID is 1 or 2)));

                }
                ques.UserAnswer.Id = useranwserID;
                ques.UserAnswer.Text = ques.Answers[useranwserID - 1].Text;

            }

            Console.Clear();

            int grade = 0 , totalMark = 0 ;

            for(int i = 0;i < Questions.Length; i++)
            {
                totalMark += Questions[i].Mark;
                if (Questions[i].UserAnswer.Id == Questions[i].RightAnswer.Id) 
                {
                    grade += Questions[i].Mark;
                }
                Console.WriteLine($"Question {i+1} : {Questions[i].Body}");
                Console.WriteLine($"Your Answer IS ==> {Questions[i].UserAnswer.Text}");
                Console.WriteLine($"Right Answer IS ==> {Questions[i].RightAnswer.Text}");
            }
            Console.WriteLine($"your Grade is {grade} from {totalMark}");
        }
    }
}
