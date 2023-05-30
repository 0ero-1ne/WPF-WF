using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LabTwo
{
    class CourseValidationAttribute : ValidationAttribute
    {
        int[] _validCourses;

        public CourseValidationAttribute(int[] courses)
        {
            _validCourses = courses;
        }

        public override bool IsValid(object value)
        {
            if (_validCourses.Contains((int)value) && value != null)
            {
                return true;
            }

            return false;
        }
    }
}
