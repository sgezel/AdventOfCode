using System.Transactions;

namespace _2025.Day1
{
    class Dial
    {
        private string _inputFile = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Day1",
            "input.txt"
        );
        private readonly List<string> _inputs = [];

        public Dial()
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

                steps = (steps % MAX) * direction;

                Console.WriteLine($"Current: {current}, input: {input}, steps: {steps}");

                current += steps;

                if (current < 0)
                    current = 100 + current;

                if (current > MAX)
                    current %= MAX;

                Console.WriteLine($"So current is: {current}");

                if (current == 0 || current == 100)
                    answer++;
            }

            Console.WriteLine($"The answer is {answer}");

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
