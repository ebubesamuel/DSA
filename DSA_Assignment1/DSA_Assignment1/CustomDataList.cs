using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DSA_Assignment1;
using DSA_Assignment1.Entities;

namespace DSA_Assignment1.Core
{
	public class CustomDataList
	{
		private Student[] students = new Student[] { };
		private int StudentDataindex = 0;
		public int Length;
		public Student First;
		public Student Last;

		
		public void PopulateWithSampleData()
		{
			Random rnd = new Random();

			int length = 10;
			students = new Student[length];

			for (int i = 0; i < length; ++i)
			{
				students[i] = new Student
				{
					FirstName = $"Ebube",
					LastName = $"Samuel",
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
			Console.WriteLine($"The added student is:{addedStudent}");
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



		public void RemoveByIndex(int index)
		{

			if (index < 0 || index >= StudentDataindex)
			{

				throw new ArgumentOutOfRangeException("Incorrect index inputted");

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

		}
		public  void RemoveFirst()
		{

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

		}
		public  void RemoveLast()
		{


			for (int i = students.Length - 1; i < StudentDataindex - 1; i++) 
			{
				students[i] = students[i + 1]; 
			}
			Student removedStudent = students[StudentDataindex - 1];
			StudentDataindex--;
			Length = StudentDataindex;
			Last = students[StudentDataindex - 1];
			Console.WriteLine($"The last student: {removedStudent}" + " HAS BEEN REMOVED!");

		}
		public  void DisplayList()
		{

			foreach (var element in students)
			{
				Console.WriteLine(element);
			}
		}
		
	}
}


