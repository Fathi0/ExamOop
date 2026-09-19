namespace ExamOop
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static int ReadPositiveInt()
            {
                int value;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                    {
                        return value;
                    }
                    Console.Write("Invalid input. Enter a positive number: ");
                }
            }
            static string ReadString()
            {
                while (true)
                {
                    string value = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        return value;
                    }
                    Console.WriteLine("Input Cannot Be Empty Try Again: ");
                }
            }
            static int ReadChoice(int min, int max)
            {
                int value;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                    {
                        return value;
                    }
                    Console.WriteLine($"Invalid Choice. Enter A Number From {min} to {max}");
                }
            }
            Console.WriteLine("Enter Subject Id: ");
            int subjectId = ReadPositiveInt();
            Console.WriteLine("Enter Subject Name: ");
            string subjectName = ReadString();
            Subject subject = new Subject(subjectId, subjectName);



            Console.WriteLine("Choose Exam Type: ");
            Console.WriteLine("1- Final Exam");
            Console.WriteLine("2-Practical Exam");
            int examType = ReadChoice(1, 2);




            Console.WriteLine("Enter Exam Time: ");
            int time = ReadPositiveInt();



            Console.WriteLine("Enter Number Of Questions: ");
            int numberOfQuestions = ReadPositiveInt();
            Question[] questions = new Question[numberOfQuestions];
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"Question {i + 1}");
                Console.WriteLine("Enter Question Header: ");
                string header = ReadString();
                Console.WriteLine("nter Question Body:");
                string body = ReadString();
                Console.WriteLine("Enter Question Mark:");
                int mark = ReadPositiveInt();
                if (examType == 1)
                {
                    Console.WriteLine("Choose Question Type:");
                    Console.WriteLine("1 - True / False");
                    Console.WriteLine("2- MCQ");
                    int questionType = ReadChoice(1, 2);


                    if (questionType == 1)
                    {
                        Answer[] answers =
                        {
                            new Answer(1,"True"),
                            new Answer(2,"False")
                        };
                        Console.WriteLine("Choose Right Answer:");
                        Console.WriteLine("1-True");
                        Console.WriteLine("2-False");


                        int rightAnswerId = ReadChoice(1, 2);
                        questions[i] = new TrueFalseQuestion(header, body, mark, answers, answers[rightAnswerId - 1]);

                    }
                    else
                    {
                        Console.WriteLine("Enter Number Of Answers:");
                        int numberOfAnswers = ReadPositiveInt();
                        Answer[] answers = new Answer[numberOfAnswers];
                        for (int j = 0; j < numberOfAnswers; j++)
                        {
                            Console.WriteLine($"Enter Answer {{j + 1}}: ");
                            string answerText = ReadString();
                            answers[j] = new Answer(j + 1, answerText);
                        }
                        Console.WriteLine("Enter Right Answer ID:");
                        int rightAnswerId = ReadChoice(1, numberOfAnswers);
                        questions[i] = new MCQQuestion(header, body, mark, answers, answers[rightAnswerId - 1]);
                    }

                }
                else
                {
                    Console.WriteLine("Enter Number Of Answers: ");
                    int numberOfAnswers = ReadPositiveInt();
                    Answer[] answers = new Answer[numberOfAnswers];
                    for (int j = 0; j < numberOfAnswers; j++)
                    {
                        Console.WriteLine($"Enter Anser {j + 1}:");
                        string answerText = ReadString();
                        answers[j] = new Answer(j + 1, answerText);
                    }
                    Console.WriteLine("Enter Right Answer Id: ");
                    int rightAnserId = ReadChoice(1, numberOfAnswers);
                    questions[i] = new MCQQuestion(header, body, mark, answers, answers[rightAnserId - 1]);
                }
            }
            Exam exam;
            if (examType == 1)
            {
                exam = new FinalExam(time, numberOfQuestions, questions, subject);
            }
            else
            {
                exam = new PracticalExam(time, numberOfQuestions, questions, subject);
            }
            subject.CreateExam(exam);
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine("-----------------------------");
            subject.Exam.ShowExam();
            Console.WriteLine("Exam Finished.");
        }
    }
}
