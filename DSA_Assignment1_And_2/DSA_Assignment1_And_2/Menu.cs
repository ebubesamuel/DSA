using System;
using System.Text;
using System.Linq;
using DSA_Assignment1_And_2.Entities;
using DSA_Assignment1_And_2.Core;
using DSA_Assignment1_And_2;


namespace DSA_Assignment1_And_2
{
    public class Menu : CustomDataList
    {

        public static void Option()
        {



            CustomDataList CDL = new CustomDataList();
            CDL.PopulateWithSampleData();


            Console.WriteLine("@@@@ Menu @@@@ \n" +
                "1. Display List \n" +
                "2. Add Student \n" +
                "3. Get Element \n" +
                "4. Remove First Element \n" +
                "5. Remove Last Element \n" +
                "6. Remove an Element by its Index \n" +
                "7. Display the List of Students arranged by their First Names \n" +
                "8. Display the List of Students arranged by their Last Names \n" +
                "9. Display the Student with the Lowest Score & List of Students in order of Lowest Scores \n" +
                "10. Display the student with the Highest Score & List of Students in order of Highest Scores \n" +
                "11. Exit\n");


            Console.WriteLine("*** Choose an option between 1 to 11 ***");

            int userInput = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (userInput)
            {
                case 1:

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("*** Below, the list of students ***");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    CDL.DisplayList();
                    break;
                case 2:
                    Console.Clear();
                    Student student = CreateNewStudent();
                    CDL.Add(student);
                    break;
                case 3:
                    Console.Clear();
                    int FunctionToGetStudentByIndexRequest = RequestIndex();
                    CDL.GetElement(FunctionToGetStudentByIndexRequest);
                    break;
                case 4:
                    Console.Clear();
                    CDL.RemoveFirst();
                    break;
                case 5:
                    Console.Clear();
                    CDL.RemoveLast();
                    break;
                case 6:
                    Console.Clear();
                    int FunctionFToRemoveStudentByIndexRequest = RequestIndex();
                    CDL.RemoveByIndex(FunctionFToRemoveStudentByIndexRequest);
                    break;
                case 7:

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("*** Below, the list of students sorted according to their First names ***");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    CDL.SortByStudentsFirstName();
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("*** Below, the list of students sorted according to their Last names ***");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    CDL.SortByStudentsLastName();
                    break;
                case 9:
                    Console.Clear();
                    Console.WriteLine();
                    CDL.GetMinimumElement();
                    break;
                case 10:
                    Console.Clear();
                    Console.WriteLine();
                    CDL.GetMaximumElement();
                    break;
                case 11:
                    Console.Clear();
                    CDL.Exit();
                    break;
                default:
                    throw new Exception("Choose something between 1 - 11 ");
            }



        }



    }
}