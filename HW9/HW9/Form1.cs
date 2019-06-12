using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW9
{
    public partial class Form1 : Form
    {
        private static double result_value;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox_Result.Text = textBox_Result.Text + button.Text; // 숫자 입력 시 버튼의 글자를 그대로 입력시킨다.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void opertion_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox_Result.Text = textBox_Result.Text + " " + button.Text + " "; // 공백으로 연산자와 숫자를 구별할 것이므로 연산자는 공백을 전 후로 넣어준다.
        }

        private void get_result(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string input_value = textBox_Result.Text; // 텍스트 박스에 입력된 값을 가져온다.

            label1.Text = resolve(input_value); // 전달받은 값을 resolve메소드에 넣어 식을 계산하고 값을 리턴받아서 라벨에 표시한다.
        }
        public string resolve(string input_value)
        {
            Stack<string> stack = new Stack<string>(); // 연산자를 담을 스택을 구현한다.
            List<string> postfix = new List<string>(); // 후위표기식을 담을 리스트를 구현한다.
            string oper_check = ""; // 연산자를 확인할 변수를 선언한다.
            double num1, num2, postfix_result = 0; // 계산할 때 사용할 임의의 두 수를 담을 변수를 선언한다.
            string oper = ""; // 계산할 때 연산자를 담을 변수를 선언한다.
            int status = 0; // 괄호가 있는 상태를 구별해줄 변수를 선언한다.

            string result = "0 + "; // 식이 하나도 없을 경우 오류가 발생하므로 0 +라는 식을 추가해 오류를 방지해준다.
            result += textBox_Result.Text;

            string[] splited = result.Split(' '); // 공백으로 문자열을 분리하여 저장한다.

            try
            {
                for (int i = 0; i < splited.Length; i++)
                {
                    double a = 0; // double형 체크를 할 때 임시로 필요해서 선언해둔다.

                    if (splited[i].Equals("log"))
                    {
                        i++;// 다음에오는 상수를 없애줘야하기 때문에 인덱스를 더해서 스킵한다.
                        postfix.Add(Math.Log10(double.Parse(splited[i])).ToString());
                    }
                    else if (splited[i].Equals("sin"))
                    {
                        i++;// 다음에오는 상수를 없애줘야하기 때문에 인덱스를 더해서 스킵한다.
                        postfix.Add(Math.Sin(double.Parse(splited[i])).ToString());
                    }
                    else if (splited[i].Equals("cos"))
                    {
                        i++;// 다음에오는 상수를 없애줘야하기 때문에 인덱스를 더해서 스킵한다.
                        postfix.Add(Math.Cos(double.Parse(splited[i])).ToString());
                    }
                    else if (splited[i].Equals("tan"))
                    {
                        i++;// 다음에오는 상수를 없애줘야하기 때문에 인덱스를 더해서 스킵한다.
                        postfix.Add(Math.Tan(double.Parse(splited[i])).ToString());
                    }
                    else if (splited[i].Equals("fact"))
                    {
                        i++;// 다음에오는 상수를 없애줘야하기 때문에 인덱스를 더해서 스킵한다.
                        double fact_num = double.Parse(splited[i]);
                        double fact_result = 1;
                        if (fact_num > 1)
                        {
                            while (fact_num > 1) // 팩토리얼 계산 시 반복문을돌면서 기존값에 1씩줄어드는 값을 계속 곱해주며 1이되면 종료한다.
                            {
                                fact_result *= fact_num;
                                fact_num--;
                            }
                            postfix.Add(fact_result.ToString());
                        }
                        else
                            postfix.Add(fact_result.ToString());
                    }
                    else if (splited[i].Equals("sqrt")) // 루트 다음에 오는 수를 루트로 변환시키기 위해 인덱스를 더한 후 값을 가져와서 변환시킨다.
                    {
                        i++;// 다음에오는 상수를 없애줘야하기 때문에 인덱스를 더해서 스킵한다.
                        postfix.Add(Math.Sqrt(double.Parse(splited[i])).ToString());
                    }
                    else if (splited[i].Equals("^"))
                    {
                        postfix.RemoveAt(postfix.Count - 1); // 기준으로 입력된 수를 리스트에서 제거한다.
                        double value = double.Parse(splited[i - 1]); // 기준이 될 수를 가져와서 저장한다.
                        for (int j = 0; j < int.Parse(splited[i + 1]) - 1; j++)
                        {
                            value *= double.Parse(splited[i - 1]); // 지수승 만큼 가져온 값을 곱해서 계산한다.
                        }
                        i++;// 다음에오는 상수를 없애줘야하기 때문에 인덱스를 더해서 스킵한다.
                        postfix.Add(value.ToString());
                    }
                    else if (splited[i].Equals("π"))
                    {
                        double pie = Math.PI; //Math클래스의 PI값을 가져온다.
                        postfix.Add(pie.ToString());
                    }
                    else if (double.TryParse(splited[i], out a))
                    {
                        postfix.Add(splited[i]); // 타입이 double일 경우에 그 값을 리스트에 저장한다.
                    }
                    else if (splited[i].Equals("(")) // 괄호가 오면 상태를 1로 바꾸고 괄호를 집어넣는다.
                    {
                        status = 1;
                        stack.Push(splited[i]);
                    }
                    else if (status > 0 && splited[i].Equals(")")) // 상태가 1이상이며 닫는괄호가오면 역순으로 리스트에서 빼낸다.
                    {
                        string temp;
                        while (status > 0)
                        {
                            temp = stack.Pop();
                            if (temp.Equals("(")) // 여는 괄호가나오면 계산한 값을 리스트에 넣고 여는 괄호는 버리고 중단한다.
                                break;
                            else
                                postfix.Add(temp);
                            status--;
                        }
                    }
                    else if (splited[i].Equals("/")) // 나눗셈은 스택에 바로 넣는다.
                    {
                        stack.Push(splited[i]);
                    }
                    else if (splited[i].Equals("*")) // 계산 우선순위를 고려하여 곱하기를 넣거나 스택 0 혹은 나누기를 빼준다.
                    {
                        if (stack.Count != 0 || splited[i].Equals("/"))
                        {
                            while (true)
                            {
                                if (stack.Count == 0)
                                {
                                    stack.Push("*");
                                    break;
                                }
                                oper_check = stack.Pop();
                                if (!oper_check.Equals("/"))
                                {
                                    stack.Push(oper_check);
                                    stack.Push("*");
                                    break;
                                }
                                else
                                    postfix.Add(oper_check);
                            }
                        }
                        else
                        {
                            stack.Push(splited[i]);
                        }
                    }
                    else if (splited[i].Equals("-")) // 계산 우선순위를 고려하여 스택에서 연산자를 빼고 넣는다.
                    {
                        if (stack.Count != 0 || splited[i].Equals("/") || splited[i].Equals("*"))
                        {
                            while (true)
                            {
                                if (stack.Count == 0)
                                {
                                    stack.Push("-");
                                    break;
                                }
                                oper_check = stack.Pop();
                                if (!oper_check.Equals("/") && !oper_check.Equals("*"))
                                {
                                    stack.Push(oper_check);
                                    stack.Push("-");
                                    break;
                                }
                                else
                                    postfix.Add(oper_check);
                            }
                        }
                        else
                        {
                            stack.Push(splited[i]);
                        }
                    }
                    else if (splited[i].Equals("+")) // 계산 우선순위를 고려하여 스택에서 연산자를 빼고 넣는다.
                    {
                        if (stack.Count != 0 || splited[i].Equals("/") || splited[i].Equals("*") || splited[i].Equals("-"))
                        {
                            while (true)
                            {
                                if (stack.Count == 0)
                                {
                                    stack.Push("+");
                                    break;
                                }
                                oper_check = stack.Pop();
                                if (!oper_check.Equals("/") && !oper_check.Equals("*") && !oper_check.Equals("-"))
                                {
                                    stack.Push(oper_check);
                                    stack.Push("+");
                                    break;
                                }
                                else
                                    postfix.Add(oper_check);
                            }
                        }
                        else
                        {
                            stack.Push(splited[i]);
                        }
                    }
                    if (status > 0)
                        status++;
                }
                int count = stack.Count;
                for (int i = 0; i < count; i++)
                {
                    postfix.Add(stack.Pop()); // 스택의 크기만큼 남은 스택의 값을 리스트에 넣는다.
                }

                for (int i = 0; i < postfix.Count; i++)
                {
                    double a = 0;

                    if (!double.TryParse(postfix[i], out a)) // 연산자가 나오게 되면 앞 두 수를 가져와 연산을 시작한다.
                    {
                        num1 = double.Parse(postfix[i - 2]);
                        num2 = double.Parse(postfix[i - 1]);
                        oper = postfix[i];
                        postfix.RemoveAt(i);
                        postfix.RemoveAt(i - 1);
                        postfix.RemoveAt(i - 2);
                        i -= 2;

                        switch (oper) // 만들어진 리스트에서 연산자 바로 앞 두 수를 가져오고 연산자를 가져와 계산후 다시 리스트에 넣는다.
                        {
                            case "+":
                                postfix_result = num1 + num2;
                                break;
                            case "-":
                                postfix_result = num1 - num2;
                                break;
                            case "*":
                                postfix_result = num1 * num2;
                                break;
                            case "/":
                                postfix_result = num1 / num2;
                                break;
                        }
                        postfix.Insert(i, postfix_result.ToString());
                    }
                }
                result_value = double.Parse(postfix_result.ToString()); // 루프가 끝나고나서 최종적으로 나온 값을 결과 값에 저장한다.
                return "계산 결과 : " + postfix_result.ToString(); // 계산결과를 형식에 맞춰 문자열로 리턴시킨다.
            }
            catch
            {
                return "입력된 값이 잘못되었습니다. 다시 입력하세요."; // 식이 맞지않아 오류가 발생할 경우 답에 오류발생문이 출력된다.
            }
        }

        private void each_clear_Click(object sender, EventArgs e) // 연산자/숫자를 한 단위 씩 지워주는 DEL을 구현했다.
        {
            string temp_result = textBox_Result.Text;
            string[] splited_result = temp_result.Split(' '); // 공백을 기준으로 쪼개서 문자열에 저장한다.
            List<string> clear_result = new List<string>();

            foreach (string line in splited_result)
            {
                clear_result.Add(line); // 문자열 배열에 저장되어있던 값들을 리스트에 넣어준다.
            }
            temp_result = "";

            double a = 0;

            if (double.TryParse(clear_result[clear_result.Count - 1], out a))
            {
                for (int i = 0; i < clear_result.Count - 1; i++) // 최종단어가 숫자일 경우 최종 단어를 지운다.
                    temp_result += clear_result[i] + " ";
            }
            else
                for (int i = 0; i < clear_result.Count - 2; i++)
                    temp_result += clear_result[i] + " "; // 최종단어가 숫자가 아닐경우 공백 및 특수자를 같이 지운다.
            textBox_Result.Text = temp_result; // 끝난 값을 텍스트박스에 적용시킨다.
        }

        private void special_Click(object sender, EventArgs e) // 삼각함수, 로그, ! 등의 수식을 입력하면 앞에 입력하든 뒤에입력하든 적용되게 하기위해 구현했다.
        {
            Button button = (Button)sender;
            string temp_result = textBox_Result.Text;
            string[] splited_result = temp_result.Split(' '); // 공백을 기준으로 쪼개서 문자열에 저장한다.
            List<string> special_result = new List<string>();


            foreach (string line in splited_result)
            {
                special_result.Add(line); // 문자열 배열에 저장되어있던 값들을 리스트에 넣어준다.
            }
            temp_result = "";
            string temp_num = special_result[special_result.Count - 1];

            special_result.Insert(special_result.Count - 1, button.Text);

            for (int i = 0; i < special_result.Count - 1; i++)
            {
                temp_result += special_result[i] + " ";
            }
            temp_result += temp_num; // 다시 값들을 입력시켜준 후 마지막 수 앞에 특수기호를 넣어주고 최종 숫자를 넣어준다.
            textBox_Result.Text = temp_result; // 값을 적용시킨다.
        }

        private void change(object sender, EventArgs e) // 부호를 변경해주는 메소드다.
        {
            Button button = (Button)sender;
            string temp_result = textBox_Result.Text;
            string[] splited_result = temp_result.Split(' '); // 공백을 기준으로 쪼개어 배열에 저장한다.
            List<string> change_result = new List<string>();

            foreach (string line in splited_result)
            {
                change_result.Add(line); // 리스트에 쪼개진 값들을 넣는다.
            }
            temp_result = "";
            string temp_num = change_result[change_result.Count-1];

            temp_num = (-double.Parse(temp_num)).ToString(); // 마지막으로 입력된 수의 부호를 바꾸어준다.

            for (int i = 0; i < change_result.Count - 1; i++)
            {
                temp_result += change_result[i] + " "; // 다시 리스트의 값들을 공백을 포함하여 적는다.
            }
            temp_result += temp_num;
            textBox_Result.Text = temp_result; // 완성된 값을 텍스트 박스에 적용시킨다.
        }

        private void result_label(object sender, EventArgs e)
        {

        }

        private void clear_button(object sender, EventArgs e)
        {
            label1.Text = "계산 결과 : 0"; // 클리어를 누르면 계산 결과를 0으로 만든다.
            textBox_Result.Clear();
        }

        private void square(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox_Result.Text = textBox_Result.Text + " ^ "; // 지수승 연산자를 식에 추가한다.
        }

        private void file_save(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Calcdata.txt", true); // 입력된 식을 저장한다.

            sw.WriteLine(textBox_Result.Text);
            sw.Close();
        }

        private void file_load(object sender, EventArgs e)
        {
            string path = "Calcdata.txt";
            string[] create = { };
            if (!File.Exists(path)) // 파일이 없을경우 파일을 생성한다.
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (string line in create)
                    {
                        Console.WriteLine(create);
                    }
                }
            }
            string read_data = "";
            StreamReader sr = new StreamReader(new FileStream("Calcdata.txt", FileMode.Open)); // 저장된 파일의 식을 읽어온다.
            while (sr.EndOfStream == false)
            {
                read_data = sr.ReadLine();
            }
            sr.Close();
            textBox_Result.Text = read_data;
        }

        private void bin_click(object sender, EventArgs e) // 형변환을 활용하여 진수변경 값을 라벨에 입력한다.
        {
            string bin_value = Convert.ToString(Convert.ToInt64(result_value), 2);
            
            label1.Text = "2진수 값 : " + bin_value.ToString();
        }

        private void oct_click(object sender, EventArgs e)
        {
            string bin_value = Convert.ToString(Convert.ToInt64(result_value), 8);

            label1.Text = "8진수 값 : " + bin_value.ToString();
        }

        private void hex_click(object sender, EventArgs e)
        {
            string bin_value = Convert.ToString(Convert.ToInt64(result_value), 16);

            label1.Text = "16진수 값 : " + bin_value.ToString();
        }

    }
}