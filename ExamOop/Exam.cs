using System;
using System.Collections.Generic;
using System.Text;

namespace ExamOop
{
    public abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }
        public Subject Subject { get; set; }
        public Exam(int time, int numberOfQuestions, Question[] questions, Subject subject)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
            Subject = subject;
        }
        public abstract void ShowExam();
        public override string ToString()
        {
            return $"Exam Time: {Time} - Questions: {NumberOfQuestions}";
        }
    }
}
