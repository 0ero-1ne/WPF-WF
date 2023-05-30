namespace LabTwo
{
    [System.Serializable]
    class Teacher
    {
        public string Pulpit { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Auditorium { get; set; }

        public Teacher
        (
            string pulpit,
            string lastName,
            string firstName,
            string patronymic,
            string auditorium
        )
        {
            Pulpit = pulpit;
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            Auditorium = auditorium;
        }

        public string GetFullName()
        {
            return LastName + " " + FirstName + " " + Patronymic;
        }
    }
}
