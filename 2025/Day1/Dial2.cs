using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Emit;
using System.Transactions;

namespace _2025.Day1
{
    class Dial2
    {
        private string _inputFile = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Day1",
            "input.txt"
        );
        private readonly List<string> _inputs = [];

        public Dial2()
        {
            ReadInput();
            DoAction();
        }

        private void DoAction()
        {
            const int MAX = 100;
            int current = 50;

            int answer = 0;

            foreach (string input in _inputs)
            {
                int direction = 1;

                if (input[..1].Equals("L", StringComparison.CurrentCultureIgnoreCase))
                    direction = -1;

                int steps = Convert.ToInt32(input[1..]);

                if (direction == 1)
                {
                    for (int i = 0; i < steps; i++)
                    {
                        current++;

                        if (current == MAX)
                            current = 0;

                        if (current == 0)
                            Console.WriteLine($">>> {current} <<<");
                        else 
                            Console.WriteLine($"{current}");


                        if (current == 0)
                            answer++;
                    }
                }

                if (direction == -1)
                {
                    for (int i = 0; i < steps; i++)
                    {
                        current--;

                        if (current < 0)
                            current = MAX - 1;

                         if (current == 0)
                            Console.WriteLine($">>> {current} <<<");
                        else 
                            Console.WriteLine($"{current}");

                        if (current == 0)
                            answer++;
                    }
                }

                Console.WriteLine("---");
            }

            Console.WriteLine($"My final answer is {answer}");
        }

        public void ReadInput()
        {
            if (!File.Exists(_inputFile))
            {
                throw new FileNotFoundException($"File not found: {_inputFile}");
            }

            foreach (string line in File.ReadAllLines(_inputFile))
                _inputs.Add(line);

            Console.WriteLine($"read  {_inputs.Count} lines.");
        }
    }
}
