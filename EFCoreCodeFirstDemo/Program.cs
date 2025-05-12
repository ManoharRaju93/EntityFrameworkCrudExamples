using EFCoreCodeFirstDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new EFCoreDbContext();

            // Adding two new Branches
            //AddBranches(context);

            // Adding two new Students
            // AddStudents(context);

            // Retrieve and display all students
            try
            {
                GetAllStudents(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); 
            }

            // Update a student's information
           UpdateStudent(context, 1); // Assuming 1 is the StudentId

            // Delete a student by ID
            DeleteStudent(context, 2); // Assuming 2 is the StudentId

            // Final retrieval to confirm operations
            GetAllStudents(context);

            Console.WriteLine("All operations completed successfully!");
        }

        private static void AddBranches(EFCoreDbContext context)
        {
            var branch2 = new Branch
            {
                BranchName = "Electronics Engineering",
                Description = "Focuses on electrical systems and circuit design.",
                PhoneNumber = "987-654-3210",
                Email = "ee@dotnettutorials.net"
            };
            var branch1 = new Branch
            {
                BranchName = "Computer Engineering",
                Description = "Focuses on Computer systems and circuit design.",
                PhoneNumber = "895-654-3210",
                Email = "csdotnettutorials.net"
            };

            context.Branches.Add(branch2);
            context.Branches.Add(branch1);

            context.SaveChanges();
        }
        private static void AddStudents(EFCoreDbContext context)
        {
            // Retrieve the branches from the context
            var csBranch = context.Branches.FirstOrDefault(b => b.BranchName == "Computer Science");
            var eeBranch = context.Branches.FirstOrDefault(b => b.BranchName == "Electrical Engineering");

            // Create two new Student objects
            var student1 = new Student
            {
                FirstName = "Harsha",
                LastName = "R",
                DateOfBirth = new DateTime(2000, 1, 15),
                Gender = "Male",
                Email = "Harsha@dotnettutorials.net",
                PhoneNumber = "895-1234",
                EnrollmentDate = DateTime.Now,
                Branch = csBranch // Assign the Computer Science branch
            };

            var student2 = new Student
            {
                FirstName = "Manohar",
                LastName = "R",
                DateOfBirth = new DateTime(1999, 10, 22),
                Gender = "Male",
                Email = "Manohar@dotnettutorials.net",
                PhoneNumber = "555-4530",
                EnrollmentDate = DateTime.Now,
                Branch = eeBranch // Assign the Electrical Engineering branch
            };

            // Add the students to the context
            context.Students.Add(student1);
            context.Students.Add(student2);

            // Save changes to the database
            context.SaveChanges();
            Console.WriteLine("Students added successfully!");
        }

        private static void GetAllStudents(EFCoreDbContext context)
        {
            // Retrieve all students from the context
            var students = context.Students.Include(s => s.Branch).ToList();

            // Display the students in the console
            Console.WriteLine("All Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"\t{student.StudentId}: {student.FirstName} {student.LastName}, Branch: {student.Branch?.BranchName}");
            }
        }

        private static void GetStudentById(EFCoreDbContext context, int studentId)
        {
            // Retrieve a single student by ID
            var student = context.Students.Include(s => s.Branch).FirstOrDefault(s => s.StudentId == studentId);

            if (student != null)
            {
                Console.WriteLine($"Student found: {student.FirstName} {student.LastName}, Branch: {student.Branch?.BranchName}");
            }
            else
            {
                Console.WriteLine($"Student with ID {studentId} not found.");
            }
        }

        private static void UpdateStudent(EFCoreDbContext context, int studentId)
        {
            // Retrieve the student from the context
            var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);

            if (student != null)
            {
                // Update the student's information
                student.LastName = "UpdatedLastName";
                student.Email = "updated.email@dotnettutorials.net";

                // Save changes to the database
                context.SaveChanges();
                Console.WriteLine($"Student with ID {studentId} updated successfully.");
            }
            else
            {
                Console.WriteLine($"Student with ID {studentId} not found.");
            }
        }

        private static void DeleteStudent(EFCoreDbContext context, int studentId)
        {
            // Retrieve the student from the context
            var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);

            if (student != null)
            {
                // Remove the student from the context
                context.Students.Remove(student);

                // Save changes to the database
                context.SaveChanges();
                Console.WriteLine($"Student with ID {studentId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Student with ID {studentId} not found.");
            }
        }
    }
}
