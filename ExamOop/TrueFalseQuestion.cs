using System;
using System.Collections.Generic;
using System.Text;

namespace ExamOop
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark, Answer[] answers, Answer righAnswer) : base(header, body, mark, answers, righAnswer)
        {

        }
    }
}
