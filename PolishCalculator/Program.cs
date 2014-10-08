using System;

namespace PolishCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static int Calculate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            var tokens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var calculator = new StackCalculator();

            foreach (var token in tokens)
            {
                int integer;

                if (int.TryParse(token, out integer))
                {
                    calculator.Compute(integer);
                }
                else
                {
                    switch (token)
                    {
                        case "+":
                            calculator.Compute(BinaryOperation.Add);
                            break;
                        case "-":
                            calculator.Compute(BinaryOperation.Subtract);
                            break;
                        case "*":
                            calculator.Compute(BinaryOperation.Multiply);
                            break;
                        case "/":
                            calculator.Compute(BinaryOperation.Divide);
                            break;
                        default:
                            throw new InvalidOperationException(string.Format("Unknown operation '{0}'", token));
                    }
                }
            }

            return calculator.Result();
        }
    }
}
