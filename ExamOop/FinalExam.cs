using System;
using System.Collections.Generic;
using System.Text;

namespace ExamOop
{
    public class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions, Question[] questions, Subject subject) : base(time, numberOfQuestions, questions, subject)
        {

        }
        public override void ShowExam()
        {
            Console.WriteLine("------------Final Exam--------------");
            int grade = 0;
            foreach (Question question in Questions)
            {
                question.ShowQuestion();
                Console.WriteLine("Enter Your Answer Id: ");
                int userAnswer = int.Parse(Console.ReadLine());
                if (userAnswer == question.RightAnswer.AnswerId)
                {
                    grade += question.Mark;
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Grade: {grade}");
        }
    }
}
