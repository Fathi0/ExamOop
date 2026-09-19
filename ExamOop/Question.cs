using System;
using System.Collections.Generic;
using System.Text;

namespace ExamOop
{
    public class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] Answers { get; set; }
        public Answer RightAnswer { get; set; }
        public Question(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = answers;
            RightAnswer = rightAnswer;
        }
        public virtual void ShowQuestion()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            foreach (Answer answer in Answers)
            {
                Console.WriteLine(answer);
            }
        }
        public override string ToString()
        {
            return $@"{Header}
{Body}
Mark:{Mark}";
        }
        public object Clone()
        {
            return new Question(Header, Body, Mark, Answers, RightAnswer);
        }
        public int CompareTo(Question? other)
        {
            if (other == null)
                return 1;
            return Mark.CompareTo(other.Mark);
        }
    }
}
