using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentLibrary.DataAccess;
using StudentLibrary.Object;

namespace StudentLibrary.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Student GetStudentByID(int StudentID) => StudentDBContext.Instance.GetStudentByID(StudentID);
        public IEnumerable<Student> GetStudents() => StudentDBContext.Instance.GetStudentList();
        public void InsertStudent(Student student) => StudentDBContext.Instance.AddNew(student);
        public void DeleteStudent(int StudentID) => StudentDBContext.Instance.Remove(StudentID);
        public void UpdateStudent(Student student) => StudentDBContext.Instance.Update(student);
        public IEnumerable<Student> SearchStudent(Student student) => StudentDBContext.Instance.Search(student);
        public IEnumerable<Student> FilterStudent(Student student) => StudentDBContext.Instance.Filter(student);
    }
}
