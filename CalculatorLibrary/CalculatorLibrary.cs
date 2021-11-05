using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {
            // ログ出力するファイルの作成 binフォルダ内に保存される
            StreamWriter logFile = File.CreateText("calculator.log");

            // 書き込み後Flushを呼び出す
            Trace.AutoFlush = true;

            // 新しくテキストファイル形式でログファイルを作る
            writer = new JsonTextWriter(logFile);

            // 配列ごとにインデント、改行しログに出力する
            writer.Formatting = Formatting.Indented;

            // オブジェクトの始まりを書き込み
            writer.WriteStartObject();

            // 配列名
            writer.WritePropertyName("Operations");

            // 配列の始まりを書き込み
            writer.WriteStartArray();

            // ログへの出力内容
            Trace.WriteLine("Starting Calculator Log");
            Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));
        }
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.
            
            // JSONオブジェクトの先頭を読み込み
            writer.WriteStartObject();

            // Operand1をログに書き込み
            writer.WritePropertyName("Operand1");

            // num1をログに書き込む
            writer.WriteValue(num1);

            // Operand2をログに書き込み
            writer.WritePropertyName("Operand2");

            // num2をログに書き込む
            writer.WriteValue(num2);

            // Operationをログに書き込み
            writer.WritePropertyName("Operation");

            // 入力された文字によって四則演算を行う
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    // Addをログに書き込む
                    writer.WriteValue("Add");
                    break;
                case "s":
                    result = num1 - num2;
                    // Subtractをログに書き込む
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = num1 * num2;
                    // Multiplyをログに書き込む
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    // 0除算ではないかどうかの判断
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        // Divideをログに書き込む
                        writer.WriteValue("Divide");
                    }
                    break;
                // 上記以外の文字などが入力されたとき
                default:
                    break;
            }

            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }
        public void Finish()
        {
            // JSON配列の終了を書き込み
            writer.WriteEndArray();

            // オブジェクトの終わりを書き込み
            writer.WriteEndObject();

            // フォームを閉じる
            writer.Close();
        }
    }
}