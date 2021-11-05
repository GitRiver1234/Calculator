using System;
using CalculatorLibrary;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // 最初の表示内容
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            // CalculatorLibraryのCalclator()を呼び出し
            Calculator calculator = new Calculator();

            while (!endApp)
            {
                // 初期値の設定
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // 1つ目の数字
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;

                // 入力した値がdouble型に変換できない場合、もう一度入力を求める
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                // 2つ目の数字
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;

                // 入力した値がdouble型に変換できない場合、もう一度入力を求める
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                // 四則演算のどれをするか聞く
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                // 入力された文字の取得
                string op = Console.ReadLine();

                try
                {
                    // CalculatorLibraryのDoOperation実行
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op); 

                    // 正常な計算ができているかの判断
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: " + result + "\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // 続けて計算するかどうか
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }

            // CalclatorLibraryのFinish()の実行
            calculator.Finish();
            return;
        }
    }
}
