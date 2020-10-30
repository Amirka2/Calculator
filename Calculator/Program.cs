using System;
using System.IO;
using System.Text;

namespace Calculator
{
    class Program
    {
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
            else if(elements.Length < 3)
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
        static double Calculation(string[] input)
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
                Console.WriteLine("Результат = " + result);
            }
            else
            {
                Console.WriteLine("Некорректный ввод!");
            }

            return result;
        }

        static void Start()
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
                        elements = Transformation(Read());
                    }
                    else
                        Calculation(elements);
                } while (true);
            }
            else if (option == "2")
            {
                using (var sr = new StreamReader(@"input.txt", true))                            // создание объекта и автоматическое закрытие методом dispose
                {
                    var input = sr.ReadLine();
                    
                    using (var sw = new StreamWriter(@"output.txt", true))
                    {
                        Console.WriteLine("Результат в текстовом документе. Путь: Calculator/bin/Debug/output.txt");
                        sw.WriteLine(Calculation(Transformation(input)));
                    }
                }
            }
            else
            {
                Console.WriteLine("Выберите одно из двух!");
                Start();
            }
        }
        static void Main(string[] args)
        {
           Start();
        }
    }
}
