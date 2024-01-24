using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentLibrary.Object;

namespace StudentLibrary.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(int studentID);
        void InsertStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int studentID);
        IEnumerable<Student> SearchStudent(Student student, bool DOBFlag);
        IEnumerable<Student> FilterStudent(Student student, bool DOBFlag);
        bool GetLogin(Admin admin);
    }
}
