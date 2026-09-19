using System;
using System.Collections.Generic;
using System.Text;

namespace ExamOop
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions, Question[] questions, Subject subject) : base(time, numberOfQuestions, questions, subject)
        {

        }
        public override void ShowExam()
        {
            Console.WriteLine("-------Practical Exam------");
            foreach (Question question in Questions)
            {
                question.ShowQuestion();
                Console.WriteLine($"Right Answer: {question.RightAnswer}");
            }
        }
    }
}
