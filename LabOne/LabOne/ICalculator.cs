namespace LabOne
{
    interface ICalculator
    {
        public string ReplaceString(string testString, string oldString, string newString);
        public string RemoveString(string testString, string oldString);
        public int GetLength(string testString);
        public char GetCharByIndex(string testString, string indexString);
        public (int, int) CountCharsByType(string testString);
        public int GetNumberOfWords(string testString);
    }
}
