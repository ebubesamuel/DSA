
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DSA_Assignment1_And_2;
using DSA_Assignment1_And_2.Entities;

namespace DSA_Assignment1_And_2.Core
{
	public class CustomDataList : IComparer<Student>
	{
		public Student[] students = new Student[] { };
		private string[] ListOfFirstNames = new string[10] { "Ebube", "Oliseh", "Axel", "Kosi", "Joshua", "Jonathan", "Uchenna", "Jeffrey", "Solomon", "Franklin" };
		private string[] ListOfLastNames = new string[10] { "Samuel", "Utulu", "Ogio", "Okoli", "Ohikere", "Aghomon", "Ejezie", "Nnogo", "Uranta", "Maduabuchi" };
		private int StudentDataindex = 0;
		public int Length;
		public Student First;
		public Student Last;
		Random rnd = new Random();
		public int i;

		public void PopulateWithSampleData()
		{

			int length = 10;
			students = new Student[length];

			for (int i = 0; i < length; ++i)
			{
				students[i] = new Student
				{
					FirstName = ListOfFirstNames[i],
					LastName = ListOfLastNames[i],
					StudentNumber = $"{i + 1}",
					AverageScore = (float)rnd.NextDouble() * 10
				};
				StudentDataindex++;
			}
			Length = students.Length;
			First = students[0];
			Last = students[students.Length - 1];
		}



		public void Add(Student addedStudent)
		{

			IncreaseArraySize();

			students[StudentDataindex] = addedStudent;
			Last = students[StudentDataindex];
			StudentDataindex++;
			Length = StudentDataindex;
			Console.WriteLine($"The added student is: {addedStudent}");
			Console.WriteLine();
			Console.WriteLine("*** Below, the list of students including new student ***");
			Console.WriteLine("--------------------------------------------------------------------------------------------------");
			foreach (var element in students)
			{
				Console.WriteLine(element);
			}
		}



		public void IncreaseArraySize()
		{

			if (StudentDataindex >= students.Length)
			{
				Student[] increasedArray = new Student[students.Length + 1];
				Array.Copy(students, 0, increasedArray, 0, students.Length);
				students = increasedArray;
				Length = students.Length;
			}

		}



		public Student GetElement(int index)
		{
			if (index < 0 || index >= StudentDataindex)
			{

				Console.WriteLine("XXX ERROR\t INCORRECT INDEX INPUTTED\t ERROR XXX");
			}
			for (int i = 0; i < students.Length; i++)
			{
				if (i == index)
				{
					Console.WriteLine(students[i]);
					return students[i];
				}
			}

			return null;
		}



		public Student RemoveByIndex(int index)
		{

			if (index < 0 || index >= StudentDataindex)
			{

				Console.WriteLine("XXX ERROR\t INCORRECT INDEX INPUTTED\t ERROR XXX");

			}
			Student removedStudent = students[index];

			for (int i = index; i < StudentDataindex - 1; i++)
			{
				students[i] = students[i + 1];

			}

			students[StudentDataindex - 1] = default;
			StudentDataindex--;
			Length = StudentDataindex;
			Last = students[StudentDataindex - 1];
			Console.WriteLine($"The Removed student by index is: {removedStudent}");
			Console.WriteLine();
			Console.WriteLine("*** Below, the list of students without the student which his/her index was requested ***");
			Console.WriteLine("--------------------------------------------------------------------------------------------------");
			foreach (var element in students)
			{
				Console.WriteLine(element);
			}

			return removedStudent;

		}
		public void RemoveFirst()
		{
			IncreaseArraySize();
			Student removedStudent = students[0];
			students[0] = null;
			for (int i = 0; i < students.Length - 1; ++i)
			{
				students[i] = students[i + 1];
			}
			First = students[0];
			StudentDataindex--;
			Length = StudentDataindex;
			Last = students[StudentDataindex - 1];
			Console.WriteLine($"The first student: {removedStudent}" + " HAS BEEN REMOVED!");
			Console.WriteLine();
			Console.WriteLine("*** Below, the list of students without the first student ***");
			Console.WriteLine("--------------------------------------------------------------------------------------------------");
			foreach (var element in students)
			{
				Console.WriteLine(element);
			}

		}
		public void RemoveLast()
		{
			IncreaseArraySize();

			for (int i = students.Length - 1; i < StudentDataindex - 1; i++)
			{
				students[i] = students[i + 1];
			}

			Student removedStudent = students[StudentDataindex - 1];
			students[StudentDataindex - 1] = default;
			StudentDataindex--;
			Length = StudentDataindex;
			Last = students[StudentDataindex - 1];
			Console.WriteLine($"The last student: {removedStudent}" + " HAS BEEN REMOVED!");
			Console.WriteLine();
			Console.WriteLine("*** Below, the list of students without the last student ***");
			Console.WriteLine("--------------------------------------------------------------------------------------------------");
			foreach (var element in students)
			{
				Console.WriteLine(element);
			}

		}
		public void DisplayList()
		{

			foreach (var element in students)
			{
				Console.WriteLine(element);
			}
		}
		public static int RequestIndex()
		{
			Console.WriteLine("Please input an index from 0 - 9: ");
			int requestedIndex = int.Parse(Console.ReadLine());

			return requestedIndex;
		}
		public static Student CreateNewStudent()
		{
			Random rnd = new Random();
			int length = 10;
			Student student = new Student();
			Console.WriteLine();
			Console.WriteLine("PLEASE FILL OUT THE REQUIREMENTS FOR A NEW STUDENT:");
			Console.WriteLine("Firstname: ");
			student.FirstName = Console.ReadLine();
			Console.WriteLine("Lastname: ");
			student.LastName = Console.ReadLine();
			Console.WriteLine("StudentsID#: ");
			student.StudentNumber = $"{length + 1}";
			Console.WriteLine("Average Score");
			student.AverageScore = (float)rnd.NextDouble() * 10;

			return student;

		}


		public int Compare(Student student1, Student student2)
		{
			throw new NotImplementedException();
		}



		public int CompareByStudentID(Student student1, Student student2)
		{
			return student1.StudentNumber.CompareTo(student2.StudentNumber);
		}


		public int CompareByStudentAverageScore(Student student1, Student student2)
		{
			return student1.AverageScore.CompareTo(student2.AverageScore);
		}


		public int CompareByStudentFirstName(Student student1, Student student2)
		{
			return student1.FirstName.CompareTo(student2.FirstName);
		}


		public int CompareByStudentLastName(Student student1, Student student2)
		{
			return student1.LastName.CompareTo(student2.LastName);
		}


		public void SortByStudentsFirstName()
		{
			Student tempStudent;
			for (int i = 0; i < students.Length - 1; i++)
			{
				for (int j = i + 1; j < students.Length; j++)
				{
					if (CompareByStudentFirstName(students[i], students[j]) > 0)
					{
						tempStudent = students[i];
						students[i] = students[j];
						students[j] = tempStudent;
					}
				}
			}
			foreach (var element in students)
			{
				Console.WriteLine(element);
			}
		}
		public void SortByStudentsLastName()
		{
			Student tempStudent;
			for (int i = 0; i < students.Length - 1; i++)
			{
				for (int j = i + 1; j < students.Length; j++)
				{
					if (CompareByStudentLastName(students[i], students[j]) > 0)
					{
						tempStudent = students[i];
						students[i] = students[j];
						students[j] = tempStudent;
					}
				}
			}
			foreach (var element in students)
			{
				Console.WriteLine(element);
			}
		}



		public void GetMinimumElement()
		{
			Student tempStudent;

			for (int i = 0; i < students.Length - 1; i++)
			{
				for (int j = i + 1; j < students.Length; j++)
				{
					if (CompareByStudentAverageScore(students[i], students[j]) > 0)
					{
						tempStudent = students[i];
						students[i] = students[j];
						students[j] = tempStudent;
					}
				}
			}

			for (int i = 0; i < students.Length; i++)
			{
				if ((students[0].AverageScore, 2) == (students[i].AverageScore, 2))
				{

					Console.WriteLine($"The student with the lowest score: {students[i]}");
					Console.WriteLine();
				}
				else
				{
					break;
				}
			}
			Console.WriteLine("*** Below, the list of students sorted from lowest to highest average score ***");
			Console.WriteLine("--------------------------------------------------------------------------------------------------");
			foreach (var element in students)
			{
				Console.WriteLine(element);
			}
		}

		public void GetMaximumElement()
		{
			Student tempStudent;


			for (int i = 0; i < students.Length - 1; i++)

			{
				for (int j = i + 1; j < students.Length; j++)

				{

					if (CompareByStudentAverageScore(students[j], students[i]) > 0)
					{


						tempStudent = students[j];
						students[j] = students[i];
						students[i] = tempStudent;
					}
				}
			}



			for (int j = students.Length - 1; j > 0; j--)
			{
				if ((students[students.Length - 1].AverageScore, 2) == (students[j].AverageScore, 2))
				{

					Console.WriteLine($"The student with the highest score: {students[i]}");
					Console.WriteLine();
				}
				else
				{
					break;
				}
				Console.WriteLine("*** Below, the list of students sorted from highest to lowest average score ***");
				Console.WriteLine("--------------------------------------------------------------------------------------------------");
				foreach (var element in students)
				{
					Console.WriteLine(element);
				}
			}
		}
		public void Exit()
		{
			Console.WriteLine("\tPage Exited ");
			Console.WriteLine("\tThank you for your patronage!!");
		}

	}
}

