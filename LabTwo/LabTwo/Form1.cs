using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace LabTwo
{
    public partial class Form1 : Form
    {
        List<Discilpline> disciplines = new();
        DataContractJsonSerializer disciplinesJsonSerializer = new(typeof(List<Discilpline>));

        List<Teacher> teachers = new();
        DataContractJsonSerializer teachersJsonSerializer = new(typeof(List<Teacher>));

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, System.EventArgs e)
        {
            textBox1.Focus();
        }

        private void label2_Click(object sender, System.EventArgs e)
        {
            comboBox2.Focus();
        }

        private void label3_Click(object sender, System.EventArgs e)
        {
            textBox3.Focus();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, System.EventArgs e)
        {

        }

        private void label4_Click(object sender, System.EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void label5_Click(object sender, System.EventArgs e)
        {

        }

        private void label6_Click(object sender, System.EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void label7_Click(object sender, System.EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Вы не ввели название дисциплины...");
                textBox1.Focus();
                return;
            }

            if (textBox3.TextLength == 0)
            {
                MessageBox.Show("Вы не ввели значение курса...");
                textBox3.Focus();
                return;
            }

            if (textBox3.Text != "1" && textBox3.Text != "2" && textBox3.Text != "3" && textBox3.Text != "4")
            {
                MessageBox.Show("Вы ввели неправильное значение курса...");
                textBox3.Focus();
                return;
            }

            if (!radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Вы не выбрали тип контроля...");
                return;
            }

            string semestr = comboBox2.Text;

            if (semestr != "1" && semestr != "2" && semestr != "1-2")
            {
                MessageBox.Show("Вы выбрали неправильное значение семестра...");
                label2.Focus();
                return;
            }

            if (listBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Вы выбрали неправильное значение преподавателя...");
                label7.Focus();
                return;
            }

            disciplines.Add(
                new Discilpline(
                    textBox1.Text,
                    comboBox2.SelectedItem.ToString(),
                    System.Convert.ToInt32(textBox3.Text),
                    listBox1.SelectedItem.ToString(),
                    trackBar1.Value,
                    radioButton2.Checked ? radioButton2.Text : radioButton3.Text,
                    teachers[listBox2.SelectedIndex]
                )
            );

            using (FileStream fs = new(@"D:\ООП_Мущук\LabTwo\LabTwo\disciplines.json", FileMode.OpenOrCreate))
            {
                disciplinesJsonSerializer.WriteObject(fs, disciplines);
                MessageBox.Show("Дисциплина успешно добавлена...");
            }

            textBox1.Text = "";
            textBox3.Text = "";
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            trackBar1.Value = 1;
            comboBox2.SelectedIndex = 0;
            listBox1.ClearSelected();
            listBox2.ClearSelected();
            listBox3.Items.Clear();

            foreach (var discipline in disciplines)
            {
                listBox3.Items.Add(
                    discipline.Title + ": " +
                    discipline.Speciality + " - " +
                    discipline.Course.ToString() + " курс - " +
                    discipline.Teacher.GetFullName()
                );
            }

            label14.Text = string.Format(
                "Количество дисциплин - {0}\nКоличество лекторов - {1}\nТекущее время - {2}",
                disciplines.Count, teachers.Count, GetCurrentDate()
            );
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            listBox2.Items.Clear();
            for (int i = 0; i < teachers.Count; i++)
            {
                listBox2.Items.Add(teachers[i].GetFullName());
            }

            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            listBox2.ClearSelected();
            listBox1.ClearSelected();
            listBox3.Enabled = false;

            label5.Text += ": " + trackBar1.Value.ToString() + " л.";

            using (FileStream fs = new(@"D:\ООП_Мущук\LabTwo\LabTwo\disciplines.json", FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    return;
                }
                disciplines = (List<Discilpline>)disciplinesJsonSerializer.ReadObject(fs);
            }

            using (FileStream fs = new(@"D:\ООП_Мущук\LabTwo\LabTwo\teachers.json", FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    return;
                }
                teachers = (List<Teacher>)teachersJsonSerializer.ReadObject(fs);
            }

            listBox2.Items.Clear();
            foreach (var teacher in teachers)
            {
                listBox2.Items.Add(teacher.GetFullName());
            }

            foreach (var discipline in disciplines)
            {
                listBox3.Items.Add(
                    discipline.Title + ": " +
                    discipline.Speciality + " - " +
                    discipline.Course.ToString() + " курс - " +
                    discipline.Teacher.GetFullName()
                );
            }

            label14.Text = string.Format(
                "Количество дисциплин - {0}\nКоличество лекторов - {1}\nТекущее время - {2}",
                disciplines.Count, teachers.Count, GetCurrentDate()
            );
        }

        private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, System.EventArgs e)
        {
            label5.Text = "Количество лекций: " + trackBar1.Value.ToString() + " л.";
        }

        private void listBox3_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, System.EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
                Color.Black, 1, ButtonBorderStyle.Solid, // left
                Color.Black, 1, ButtonBorderStyle.Solid, // top
                Color.Black, 1, ButtonBorderStyle.Solid, // right
                Color.Black, 1, ButtonBorderStyle.Solid  // bottom
            );
        }

        private void label8_Click(object sender, System.EventArgs e)
        {

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            string teacherSurname = textBox2.Text;
            string teacherName = textBox4.Text;
            string teacherLastName = textBox5.Text;
            string teacherAuditorium = textBox6.Text;
            string teacherPulpit = comboBox1.SelectedItem.ToString();

            if (teacherSurname.Length == 0)
            {
                MessageBox.Show("Вы ввели неправильное значение фамилии преподавателя...");
                textBox2.Focus();
                return;
            }

            if (teacherName.Length == 0)
            {
                MessageBox.Show("Вы ввели неправильное значение имени преподавателя...");
                textBox4.Focus();
                return;
            }

            if (teacherLastName.Length == 0)
            {
                MessageBox.Show("Вы ввели неправильное значение отчества преподавателя...");
                textBox5.Focus();
                return;
            }

            if (teacherAuditorium.Length == 0)
            {
                MessageBox.Show("Вы ввели неправильное значение аудитории преподавателя...");
                textBox6.Focus();
                return;
            }

            teachers.Add(new Teacher(teacherPulpit, teacherSurname, teacherName, teacherLastName, teacherAuditorium));
            using (FileStream fs = new(@"D:\ООП_Мущук\LabTwo\LabTwo\teachers.json", FileMode.OpenOrCreate))
            {
                teachersJsonSerializer.WriteObject(fs, teachers);
            }

            MessageBox.Show("Лектор добавлен...");
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.SelectedIndex = 0;


            listBox2.Items.Clear();
            foreach (var teacher in teachers)
            {
                listBox2.Items.Add(teacher.GetFullName());
            }

            label14.Text = string.Format(
                "Количество дисциплин - {0}\nКоличество лекторов - {1}\nТекущее время - {2}",
                disciplines.Count, teachers.Count, GetCurrentDate()
            );
        }

        private void textBox2_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void label9_Click(object sender, System.EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void label10_Click(object sender, System.EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void label11_Click(object sender, System.EventArgs e)
        {

        }

        private void label13_Click(object sender, System.EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Версия программы - V 1.0\nРазработчик - Воликов Дмитрий Анатольевич");
            textBox1.Focus();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            Form2 searchFrom = new();
            searchFrom.Show();
        }

        private void label14_Click(object sender, System.EventArgs e)
        {

        }

        private string GetCurrentDate()
        {
            DateTime date = DateTime.Now;
            return date.Day + "/" + date.Month + "/" + date.Year + " " + date.Hour + ":" + date.Minute;
        }
    }
}
