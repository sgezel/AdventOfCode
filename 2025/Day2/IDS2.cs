using System.Transactions;

namespace _2025.Day2
{
    class IDS2
    {
        private string _inputFile = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Day2",
            "input.txt"
        );
        private readonly List<string> _inputs = [];

        public IDS2()
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

                    if (strLen > 1)
                    {
                        Console.WriteLine($"checking {i}");

                        bool valid = true;

                        for (int j = 1; j <= strLen / 2; j++)
                        {
                            string part = i.ToString()[..j];

                            if ((strLen - part.Length) % j == 0)
                            {
                                for (var k = j; k < strLen - part.Length; k += j)
                                {
                                    var partToCheck = i.ToString().Substring(k, j);


                                    if (!part.Equals(partToCheck))
                                    {
                                        valid = false;
                                        break;
                                    }
                                }
                            }

                            if(!valid)
                                break;
                        }

                        if (valid)
                            Console.WriteLine(i + " is valid");
                        
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
