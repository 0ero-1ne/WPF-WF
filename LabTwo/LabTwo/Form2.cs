using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LabTwo
{
    public partial class Form2 : Form
    {
        List<Discilpline> disciplines = new();
        List<Discilpline> firstList = new();
        List<Discilpline> secondList = new();
        List<Discilpline> thirdList = new();

        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var input = textBox1.Text.ToLower();
            var selectedDisciplines = disciplines.Where(d => d.Teacher.GetFullName().ToLower().Contains(input));
            firstList = selectedDisciplines.ToList();

            listBox1.Items.Clear();
            foreach (var discipline in selectedDisciplines)
            {
                listBox1.Items.Add(
                    discipline.Title + ": " +
                    discipline.Course.ToString() + " курс - " +
                    discipline.Teacher.GetFullName()
                );
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            var input = textBox4.Text.ToLower();
            var selectedDisciplines = disciplines.Where(d => d.Semester.ToLower().Contains(input));
            secondList = selectedDisciplines.ToList();

            listBox2.Items.Clear();
            foreach (var discipline in selectedDisciplines)
            {
                listBox2.Items.Add(
                    discipline.Title + ": " +
                    discipline.Course.ToString() + " курс - " +
                    discipline.Semester + " сем. " +
                    discipline.Teacher.GetFullName()
                );
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            var input = textBox6.Text;
            var selectedDisciplines = disciplines.Where(d => d.Course.ToString().Contains(input));
            thirdList = selectedDisciplines.ToList();

            listBox3.Items.Clear();
            foreach (var discipline in selectedDisciplines)
            {
                listBox3.Items.Add(
                    discipline.Title + ": " +
                    discipline.Course.ToString() + " курс - " +
                    discipline.Teacher.GetFullName()
                );
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (FileStream fs = new(@"D:\ООП_Мущук\LabTwo\LabTwo\disciplines.json", FileMode.Open))
            {
                DataContractJsonSerializer jsonSerializer = new(typeof(List<Discilpline>));

                disciplines = (List<Discilpline>)jsonSerializer.ReadObject(fs);
                firstList = disciplines;
                secondList = disciplines;
                thirdList = disciplines;
            }

            foreach (var discipline in disciplines)
            {
                listBox1.Items.Add(
                    discipline.Title + ": " +
                    discipline.Course.ToString() + " курс - " +
                    discipline.Teacher.GetFullName()
                );

                listBox2.Items.Add(
                    discipline.Title + ": " +
                    discipline.Course.ToString() + " курс - " +
                    discipline.Semester + " сем. " +
                    discipline.Teacher.GetFullName()
                );

                listBox3.Items.Add(
                    discipline.Title + ": " +
                    discipline.Course.ToString() + " курс - " +
                    discipline.Teacher.GetFullName()
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var input = textBox1.Text.ToLower();
            var selectedDisciplines = disciplines.Where(d => d.Teacher.GetFullName().ToLower().Contains(input))
                .OrderBy(d => d.NumberOfLections);
            firstList = selectedDisciplines.ToList();

            listBox1.Items.Clear();

            foreach (var discipline in selectedDisciplines)
            {
                listBox1.Items.Add(
                    discipline.Title + ": " +
                    discipline.NumberOfLections.ToString() + " лекций - " +
                    discipline.Teacher.GetFullName()
                );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var input = textBox1.Text.ToLower();
            var selectedDisciplines = disciplines.Where(d => d.Teacher.GetFullName().ToLower().Contains(input))
                .OrderBy(d => d.ControlType);
            firstList = selectedDisciplines.ToList();

            listBox1.Items.Clear();

            foreach (var discipline in selectedDisciplines)
            {
                listBox1.Items.Add(
                    discipline.Title + ": " +
                    discipline.ControlType + " - " +
                    discipline.Teacher.GetFullName()
                );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var input = textBox4.Text.ToLower();
            var selectedDisciplines = disciplines.Where(d => d.Semester.ToLower().Contains(input))
                .OrderBy(d => d.ControlType);
            secondList = selectedDisciplines.ToList();

            listBox2.Items.Clear();
            foreach (var discipline in selectedDisciplines)
            {
                listBox2.Items.Add(
                    discipline.Title + ": " +
                    discipline.ControlType + " - " +
                    discipline.Semester + " сем. " +
                    discipline.Teacher.GetFullName()
                );
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var input = textBox4.Text.ToLower();
            var selectedDisciplines = disciplines.Where(d => d.Semester.ToLower().Contains(input))
                .OrderBy(d => d.NumberOfLections);
            secondList = selectedDisciplines.ToList();

            listBox2.Items.Clear();
            foreach (var discipline in selectedDisciplines)
            {
                listBox2.Items.Add(
                    discipline.Title + ": " +
                    discipline.NumberOfLections + " лекций - " +
                    discipline.Semester + " сем. " +
                    discipline.Teacher.GetFullName()
                );
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveList("list1", firstList);
            MessageBox.Show("Список сохранён");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveList("list2", secondList);
            MessageBox.Show("Список сохранён");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveList("list3", thirdList);
            MessageBox.Show("Список сохранён");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var input = textBox6.Text;
            var selectedDisciplines = disciplines.Where(d => d.Course.ToString().Contains(input))
                .OrderBy(d => d.ControlType);
            thirdList = selectedDisciplines.ToList();

            listBox3.Items.Clear();
            foreach (var discipline in selectedDisciplines)
            {
                listBox3.Items.Add(
                    discipline.Title + ": " +
                    discipline.ControlType + " - " +
                    discipline.Teacher.LastName + " " +
                    discipline.Course.ToString() + " курс"
                );
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var input = textBox6.Text;
            var selectedDisciplines = disciplines.Where(d => d.Course.ToString().Contains(input))
                .OrderBy(d => d.NumberOfLections);
            thirdList = selectedDisciplines.ToList();

            listBox3.Items.Clear();
            foreach (var discipline in selectedDisciplines)
            {
                listBox3.Items.Add(
                    discipline.Title + ": " +
                    discipline.NumberOfLections + " лекций - " +
                    discipline.Teacher.LastName + " " +
                    discipline.Course.ToString() + " курс"
                );
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string input = textBox2.Text.ToLower();
                Regex regex = new(input);

                var selectedDisciplines = disciplines.Where(d => regex.IsMatch(d.Teacher.GetFullName().ToLower()));
                firstList = selectedDisciplines.ToList();

                listBox1.Items.Clear();
                foreach (var discipline in selectedDisciplines)
                {
                    listBox1.Items.Add(
                        discipline.Title + ": " +
                        discipline.Course.ToString() + " курс - " +
                        discipline.Teacher.GetFullName()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string input = textBox3.Text.ToLower();
                Regex regex = new(input);

                var selectedDisciplines = disciplines.Where(d => regex.IsMatch(d.Semester));
                secondList = selectedDisciplines.ToList();

                listBox2.Items.Clear();
                foreach (var discipline in selectedDisciplines)
                {
                    listBox2.Items.Add(
                        discipline.Title + ": " +
                        discipline.Course.ToString() + " курс - " +
                        discipline.Teacher.GetFullName()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string input = textBox5.Text.ToLower();
                Regex regex = new(input);

                var selectedDisciplines = disciplines.Where(d => regex.IsMatch(d.Course.ToString()));
                thirdList = selectedDisciplines.ToList();

                listBox3.Items.Clear();
                foreach (var discipline in selectedDisciplines)
                {
                    listBox3.Items.Add(
                        discipline.Title + ": " +
                        discipline.Course.ToString() + " курс - " +
                        discipline.Teacher.GetFullName()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void SaveList(string fileName, List<Discilpline> list)
        {
            DataContractJsonSerializer jsonSerializer = new(typeof(List<Discilpline>));
            using (FileStream fs = new(@"D:\ООП_Мущук\LabTwo\LabTwo\" + fileName + ".json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs, list);
            }
        }
    }
}
