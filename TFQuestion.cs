using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Exam
{
    public class TFQuestion : Question
    {
        public TFQuestion() //[ 1-true 0 , 2-false 1 ]
        {
            Answers = new Answer[2];
            Answers[0]= new Answer(1,"True");
            Answers[1]= new Answer(2,"False");
        }

        public override string Header => $"True Or False Question";

        public override void AddQuestion()
        {
            Console.WriteLine(Header);

            do
            {
                Console.WriteLine("Please Enter The Question's Body");
                Body = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(Body));

            int mark;
            
            do
            {
                Console.WriteLine("Please Enter Mark OF Question");
                
            } while (!(int.TryParse(Console.ReadLine(), out mark) && (mark>0)));

            Mark = mark;

            int rightAnswerId;
            do
            {
                Console.WriteLine(" Please Enter The Right Answer ID ( 1 For True , 2 For False)");
            } while (!(int.TryParse(Console.ReadLine(),out rightAnswerId) && (rightAnswerId is 1 or 2)));

            RightAnswer.Id = rightAnswerId;
            RightAnswer.Text = Answers[rightAnswerId - 1].Text; //[true 0 , false 1 ]
            Console.Clear();

        }
    }
}
