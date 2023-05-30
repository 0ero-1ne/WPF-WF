using System.Runtime.Serialization;

namespace LabTwo
{
    [System.Serializable]
    class Discilpline
    {
        public string Title { get; set; }
        public string Semester { get; set; }

        [CourseValidation(new int[] { 1, 2, 3, 4 }, ErrorMessage = "Вы ввели неправильное значение курса...")]
        public int Course { get; set; }

        public string Speciality { get; set; }
        public int NumberOfLections { get; set; }
        public string ControlType { get; set; }
        [DataMember]
        public Teacher Teacher { get; set; }

        public Discilpline
        (
            string title,
            string semester,
            int course,
            string speciality,
            int numberOfLections,
            string controlType,
            Teacher teacher
        )
        {
            Title = title;
            Semester = semester;
            Course = course;
            Speciality = speciality;
            NumberOfLections = numberOfLections;
            ControlType = controlType;
            Teacher = teacher;
        }
    }
}
