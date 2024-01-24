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
        public IEnumerable<Student> SearchStudent(Student student, bool DOBFlag) => StudentDBContext.Instance.Search(student, DOBFlag);
        public IEnumerable<Student> FilterStudent(Student student, bool DOBFlag) => StudentDBContext.Instance.Filter(student, DOBFlag);
        public bool GetLogin(Admin admin) => StudentDBContext.Instance.GetLogin(admin);
    }
}
