using System;

namespace Calculator
{
    class Program
    {
        public Program()
        {
        }

        static string Read()
        {
            Console.Write("Введите выражение: ");
            var input = Console.ReadLine();
            return input;
        }

        static bool Check(string[] elements)
        {
            if(elements[1] == "/" && elements[2] == "0")
                return false;
            else if(elements.Length < 3)                            //проверка работает некорректно
                return false;
            
            bool check = true;
            double c;

            foreach(var el in elements)
            {
                if((el == "+") || (el == "-") || (el == "*") || (el == "/"))
                    continue;
                check = Double.TryParse(el, out c);
                if(!check)
                    break;
            }

            return check;
        }

        static string[] Transformation(string expression)
        {
            expression = expression.Trim();
            while (expression.Contains("  "))
            {
                expression = expression.Replace("  ", " ");
            }
            string[] elements = expression.Split(' ');
            
            return elements;
        }

        static bool SignCheck(string[] input)
        {
            var sign = input[1];
            var check = false;
            if ((sign == "+") || (sign == "-") || (sign == "*") || (sign == "/") || (sign == "%"))
                check = true;
            else
                check = false;
            return check;
        }
        static void Calculation(string[] input)
        {
            double result = 0;
            if (SignCheck(input))
            {
                if (input[1] == "+")
                    result = Convert.ToDouble(input[0]) + Convert.ToDouble(input[2]);
                else if (input[1] == "-")
                    result = Convert.ToDouble(input[0]) - Convert.ToDouble(input[2]);
                else if(input[1] == "*")
                    result = Convert.ToDouble(input[0]) * Convert.ToDouble(input[2]);
                else if(input[1] == "/")
                    result = Convert.ToDouble(input[0]) / Convert.ToDouble(input[2]);
                else if (input[1] == "%")
                    result = Convert.ToDouble(input[0]) % Convert.ToDouble(input[2]);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Некорректный ввод!");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ввод с консоли: 1 \nВвод с файла: 2");
            var option = Console.ReadLine();
            if (option == "1")
            {
                do
                {
                    var input = Read();
                    var elements = Transformation(input);
                    
                    if (!Check(elements))
                    {
                        Console.WriteLine("Некорректный ввод!");
                        input = Read();
                        elements = Transformation(input);
                    }
                    else
                        Calculation(elements);
                } while (true);
            }
            else if (option == "2")
            {

            }
        }
    }
}
