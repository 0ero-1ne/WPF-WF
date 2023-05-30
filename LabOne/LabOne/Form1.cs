using System;
using System.Windows.Forms;

namespace LabOne
{
    public partial class Form1 : Form
    {
        Calculator calculator = new Calculator();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            string oldString = textBox2.Text;
            string newString = textBox5.Text;

            string result = calculator.ReplaceString(inputText, oldString, newString);

            if (result.Length == 0)
            {
                return;
            }

            MessageBox.Show("Новая строка: " + result);
            ClearTextBoxes(textBox1, textBox2, textBox5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textInput = textBox1.Text;
            string oldString = textBox3.Text;
            string result = calculator.RemoveString(textInput, oldString);

            if (result == "")
            {
                return;
            }

            MessageBox.Show("Новая строка: " + result);
            ClearTextBoxes(textBox1, textBox3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            string index = textBox4.Text;
            char ch = calculator.GetCharByIndex(inputText, index);

            if (ch == ' ')
            {
                return;
            }

            MessageBox.Show(string.Format("Символ по индексу {0}: {1}", index, ch));
            ClearTextBoxes(textBox1, textBox4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Длина строки: " + calculator.GetLength(textBox1.Text));
            ClearTextBoxes(textBox1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            int result = calculator.GetNumberOfWords(inputText);

            if (result == -1)
            {
                return;
            }

            MessageBox.Show("Количество слов в строке: " + result);
            ClearTextBoxes(textBox1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;

            var result = calculator.CountCharsByType(inputText);
            if (result == (-1, -1))
            {
                return;
            }

            MessageBox.Show(string.Format(
                "Количество гласных - {0}\nКоличество согласных - {1}",
                result.Item1, result.Item2
            ));

            ClearTextBoxes(textBox1);
        }

        private void ClearTextBoxes(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Text = "";
            }
        }
    }
}
