using System;
using System.Text;
using System.Collections.Generic;
using DSA_Assignment1.Core;

namespace DSA_Assignment1.Entities
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public float AverageScore { get; set; }

        public override string ToString()
        {
            return $"Firstname is: {FirstName}, Lastname is: {LastName}, students ID# is: {StudentNumber}, students average score is: {AverageScore}";
        }
    }
}


