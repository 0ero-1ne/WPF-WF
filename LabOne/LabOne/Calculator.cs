using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LabOne
{
    class Calculator : ICalculator
    {
        public Calculator() { }

        public string ReplaceString(string testString, string oldString, string newString)
        {
            if (testString.Length == 0)
            {
                MessageBox.Show("Нет тестовой строки...");
                return "";
            }

            if (oldString.Length == 0)
            {
                MessageBox.Show("Нет значения подстроки для замены...");
                return "";
            }

            if (newString.Length == 0)
            {
                MessageBox.Show("Нет значения новой подстроки...");
                return "";
            }

            return testString.Replace(oldString, newString);
        }

        public int GetLength(string testString)
        {
            return testString.Length;
        }

        public char GetCharByIndex(string testString, string indexString)
        {
            if (testString.Length == 0)
            {
                MessageBox.Show("Нет тестовой строки...");
                return ' ';
            }

            try
            {
                int index = Convert.ToInt32(indexString);

                if (index < 0 || index > testString.Length)
                {
                    MessageBox.Show("Индекс вышел за пределы длины строки...");
                    return ' ';
                }

                return testString[Convert.ToInt32(indexString)];
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Неправильный формат ввода: " + ex.Message);
            }

            return ' ';
        }

        public (int, int) CountCharsByType(string testString)
        {
            testString = testString.ToLower();

            if (testString.Length == 0)
            {
                MessageBox.Show("Нет тестовой строки...");
                return (-1, -1);
            }

            int vowelsCharsInString = 0;
            int consonantsCharsInString = 0;

            for (int i = 0; i < testString.Length; i++)
            {
                if (IsVowel(testString[i]))
                {
                    vowelsCharsInString++;
                }

                if (IsConsonant(testString[i]))
                {
                    consonantsCharsInString++;
                }
            }

            return (vowelsCharsInString, consonantsCharsInString);
        }

        public string RemoveString(string testString, string oldString)
        {
            if (testString.Length == 0)
            {
                MessageBox.Show("Нет тестовой строки...");
                return "";
            }

            if (oldString.Length == 0)
            {
                MessageBox.Show("Нет удаляемой строки...");
                return "";
            }

            if (!testString.Contains(oldString))
            {
                MessageBox.Show("Данная подстркоа отсутствует в тестовой строке...");
                return "";
            }

            return testString.Replace(oldString, "");
        }

        public int GetNumberOfWords(string testString)
        {
            testString = Regex.Replace(testString, @"\s+", " ");

            if (testString.Length == 0 || testString.Trim().Length == 0)
            {
                MessageBox.Show("Нет тестовой строки...");
                return -1;
            }

            return testString.Trim().Split(' ').Length;
        }

        private bool IsVowel(char ch)
        {
            string vowelsChars = "аеёиоуыэюяaeiouy";

            if (vowelsChars.Contains(ch))
            {
                return true;
            }

            return false;
        }

        private bool IsConsonant(char ch)
        {
            string consonantsChars = "бвгджзйклмнпрстфхцчшщъьbcdfghjklmnpqrstvwxz";

            if (consonantsChars.Contains(ch))
            {
                return true;
            }

            return false;
        }
    }
}
