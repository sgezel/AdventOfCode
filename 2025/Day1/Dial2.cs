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
                int realSteps= 0;

                if (input[..1].Equals("L", StringComparison.CurrentCultureIgnoreCase))
                    direction = -1;

                int steps = Convert.ToInt32(input[1..]);

                answer += Math.Abs(steps) / MAX;

                //if (direction == -1 && Math.Abs(steps) > current)
                //    answer += 1 + Math.Abs(steps) / MAX;

                realSteps = steps * direction + current;
                steps = (steps % MAX) * direction;

                Console.WriteLine($"Current: {current}, input: {input}, steps: {steps}");

                current += steps;

                if (current < 0)
                    current = MAX + current;

                if (current > MAX)
                {
                    
                    current %= MAX;
                }

                if (current == 0 || current == 100)
                    answer++;

                Console.WriteLine($"So current is: {current}, answer is {answer}");

            }

                Console.WriteLine($"My final answer is {answer}");

            //6223
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
