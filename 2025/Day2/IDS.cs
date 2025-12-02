using System.Transactions;

namespace _2025.Day2
{
    class IDS
    {
        private string _inputFile = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Day2",
            "input.txt"
        );
        private readonly List<string> _inputs = [];

        public IDS()
        {
            ReadInput();
            DoAction();
        }

        private void DoAction()
        {
            long answer = 0;

            foreach (string input in _inputs[0].Split(','))
            {
                string[] rangeArr = input.Split("-");

                long start = Convert.ToInt64(rangeArr[0]);
                long end = Convert.ToInt64(rangeArr[1]);

                for (long i = start; i <= end; i++)
                {
                    int strLen = i.ToString().Length;
                    if (strLen % 2 == 0)
                    {
                        string a = i.ToString()[..(strLen / 2)];
                        string b = i.ToString()[(strLen / 2)..];

                        if (a.Equals(b))
                        {
                            answer += i;
                        }
                    }
                }
            }

            Console.WriteLine($"the answer is {answer}");
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
