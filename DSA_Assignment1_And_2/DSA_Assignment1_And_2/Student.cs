
using System;
using System.Text;
using System.Collections.Generic;
using DSA_Assignment1_And_2.Core;

namespace DSA_Assignment1_And_2.Entities
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public float AverageScore { get; set; }

        public override string ToString()
        {
            return $"Firstname: {FirstName} \t Lastname: {LastName} \t Students ID#: {StudentNumber}\t  Average score is: {AverageScore}";
        }
    }
}