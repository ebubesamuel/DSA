using System;
using System.Text;
using System.Linq;
using DSA_Assignment1.Entities;
using DSA_Assignment1.Core;
using DSA_Assignment1;


namespace DSA_Assignment1
{
    public class Menu
    {
        
        public static void Option()
        {
            
            


            CustomDataList CDL = new CustomDataList();
            CDL.PopulateWithSampleData();
            Console.WriteLine("@@@@@  Menu @@@@@ \n" +
                "1. DisplayList \n" +
                "2. Add Student \n" +
                "3. Get Element \n" +
                "4. Remove First Element  \n" +
                "5. Remove Last Element \n");
                


            Console.WriteLine("Choose an option between 1 to 5");

            int userInput = int.Parse(Console.ReadLine());

            Console.Clear(); 

            
            switch (userInput)
            {
                case 1:
                    CDL.DisplayList();   
                   
                    break;
                case 2:
                    Student student = CreateStudent();
                    CDL.Add(student);  
                    break;
                case 3:
                    int FunctionForIndexRequest = RequestIndex();
                      CDL.GetElement(FunctionForIndexRequest); 
                    break;
                case 4:
                    CDL.RemoveFirst();
                    break;
                case 5:
                    CDL.RemoveLast();
                    break;
                default:
                  
                    throw new Exception("Choose something between 1 - 5 ");
            }

            
        
        }

        public  static int RequestIndex()
        {
            Console.WriteLine("Please input an index: ");
             int requestedIndex = int.Parse(Console.ReadLine());

            return requestedIndex;
        }

        public static Student CreateStudent()
        {
            
            Random rnd = new Random();
            Student student = new Student();
            student.FirstName = $"Ebube";
            student.LastName = $" Samuel";
            student.StudentNumber = (string)rnd.Next(0, 100).ToString();
            student.AverageScore = (float)rnd.NextDouble() * 10;

            return student;

        }
    }
}

