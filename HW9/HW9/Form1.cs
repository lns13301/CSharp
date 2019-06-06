using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW9
{
    public partial class Form1 : Form
    {
        string result_line = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox_Result.Text = textBox_Result.Text + button.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox_Result.Clear();
        }

        private void opertion_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox_Result.Text = textBox_Result.Text + " " + button.Text + " ";
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void get_result(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string input_value = textBox_Result.Text;

            label1.Text = resolve(input_value);
        }
        public string resolve(string input_value)
        {
            Stack<string> stack = new Stack<string>();
            Stack<string> reverse = new Stack<string>();
            List<string> postfix = new List<string>();
            string oper_check = "";
            double num1, num2, postfix_result = 0;
            string oper = "";
            int status = 0;

            string result = "0 + ";
            result += textBox_Result.Text;

            string[] splited = result.Split(' ');

            for (int i = 0; i < splited.Length; i++)
            {
                double a = 0;

                if (splited[i].Equals("log"))
                {
                    i++;
                    postfix.Add(Math.Log10(double.Parse(splited[i])).ToString());
                }
                else if (splited[i].Equals("sin"))
                {
                    i++;
                    postfix.Add(Math.Sin(double.Parse(splited[i])).ToString());
                }
                else if (splited[i].Equals("cos"))
                {
                    i++;
                    postfix.Add(Math.Cos(double.Parse(splited[i])).ToString());
                }
                else if (splited[i].Equals("tan"))
                {
                    i++;
                    postfix.Add(Math.Tan(double.Parse(splited[i])).ToString());
                }
                else if (splited[i].Equals("fact"))
                {
                    i++;
                    double fact_num = double.Parse(splited[i]);
                    double fact_result = 1;
                    if (fact_num > 1)
                    {
                        while (fact_num > 1)
                        {
                            fact_result *= fact_num;
                            fact_num--;
                        }
                        postfix.Add(fact_result.ToString());
                    }
                    else
                        postfix.Add(fact_result.ToString());
                }
                else if (double.TryParse(splited[i], out a))
                {
                    postfix.Add(splited[i]);
                }
                else if (splited[i].Equals("("))
                {
                    status = 1;
                    stack.Push(splited[i]);
                }
                else if (status > 0 && splited[i].Equals(")"))
                {
                    string temp;
                    while (status > 0)
                    {
                        temp = stack.Pop();
                        if (temp.Equals("("))
                            break;
                        else
                            postfix.Add(temp);
                        status--;
                    }
                }
                else if (splited[i].Equals("/"))
                {
                    stack.Push(splited[i]);
                }
                else if (splited[i].Equals("*"))
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
                else if (splited[i].Equals("-"))
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
                else if (splited[i].Equals("+"))
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
                postfix.Add(stack.Pop());
            }

            for (int i = 0; i < postfix.Count; i++)
            {
                double a = 0;

                if (!double.TryParse(postfix[i], out a))
                {
                    num1 = double.Parse(postfix[i - 2]);
                    num2 = double.Parse(postfix[i - 1]);
                    oper = postfix[i];
                    postfix.RemoveAt(i);
                    postfix.RemoveAt(i - 1);
                    postfix.RemoveAt(i - 2);
                    i -= 2;

                    switch (oper)
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
            return postfix_result.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string temp_result = textBox_Result.Text;
            string[] splited_result = temp_result.Split(' ');
            List<string> clear_result = new List<string>();

            foreach(string line in splited_result)
            {
                clear_result.Add(line);
            }
            temp_result = "";

            double a = 0;

            if(double.TryParse(clear_result[clear_result.Count-1], out a))
            {
                for (int i = 0; i < clear_result.Count - 1; i++)
                    temp_result += clear_result[i] + " ";
            }
            else
                for (int i = 0; i < clear_result.Count - 2; i++)
                    temp_result += clear_result[i] + " ";
            textBox_Result.Text = temp_result;
        }

        private void special_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string temp_result = textBox_Result.Text;
            string[] splited_result = temp_result.Split(' ');
            List<string> special_result = new List<string>();


            foreach (string line in splited_result)
            {
                special_result.Add(line);
            }
            temp_result = "";
            string temp_num = special_result[special_result.Count - 1];

            special_result.Insert(special_result.Count - 1, button.Text);

            for (int i = 0; i < special_result.Count - 1; i++)
            {
                temp_result += special_result[i] + " ";
            }
            temp_result += temp_num;
            textBox_Result.Text = temp_result;
        }
    }
}