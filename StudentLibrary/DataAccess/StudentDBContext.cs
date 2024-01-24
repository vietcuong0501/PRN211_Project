using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using StudentLibrary.Object;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace StudentLibrary.DataAccess
{
    public class StudentDBContext : BaseDAL
    {
        private static StudentDBContext instance = null;
        private static readonly object instanceLock = new object();
        private StudentDBContext() { }
        public static StudentDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StudentDBContext();
                    }
                    return instance;
                }
            }
        }
        
        public IEnumerable<Student> GetStudentList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "SELECT * FROM Student";
            var students = new List<Student>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while(dataReader.Read())
                {
                    students.Add(new Student
                    {
                        StudentID = dataReader.GetInt32(0),
                        StudentName = dataReader.GetString(1),
                        Gender = dataReader.GetString(2),
                        DOB = dataReader.GetDateTime(3),
                        Major = dataReader.GetString(4)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return students;
        }

        public Student GetStudentByID(int studentID)
        {
            Student student = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT * FROM Student WHERE StudentID = @StudentID";
            try
            {
                var param = dataProvider.CreateParameter("@StudentID", 4, studentID, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if(dataReader.Read())
                {
                    student = new Student
                    {
                        StudentID = dataReader.GetInt32(0),
                        StudentName = dataReader.GetString(1),
                        Gender = dataReader.GetString(2),
                        DOB = dataReader.GetDateTime(3),
                        Major = dataReader.GetString(4)
                    };
                }
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return student;
        }

        public void AddNew(Student student)
        {
            try
            {
                Student st = GetStudentByID(student.StudentID);
                if(st == null)
                {
                    string SQLInsert = "INSERT INTO Student VALUES (@StudentID, @StudentName, @Gender, @DOB, @Major)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@StudentID", 4, student.StudentID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@StudentName", 50, student.StudentName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Gender", 10, student.Gender, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@DOB", 50, student.DOB, DbType.Date));
                    parameters.Add(dataProvider.CreateParameter("@Major", 50, student.Major, DbType.String));
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The Student already exsisted");
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(Student student)
        {
            try
            {
                Student st = GetStudentByID(student.StudentID);
                if(st != null)
                {
                    string SQLUpdate = "UPDATE Student SET StudentName = @StudentName, Gender = @Gender, DOB = @DOB, Major = @Major WHERE StudentID = @StudentID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@StudentID", 4, student.StudentID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@StudentName", 50, student.StudentName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Gender", 10, student.Gender, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@DOB", 50, student.DOB, DbType.Date));
                    parameters.Add(dataProvider.CreateParameter("@Major", 50, student.Major, DbType.String));
                    dataProvider.Update(SQLUpdate, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The Student does not exsist");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Remove(int studentID)
        {
            try
            {
                Student st = GetStudentByID(studentID);
                if(st != null)
                {
                    string SQLDelete = "DELETE FROM Student WHERE StudentID = @StudentID";
                    var param = dataProvider.CreateParameter("@StudentID", 4, studentID, DbType.Int32);
                    dataProvider.Delete(SQLDelete, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("The Student does not exsist");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public IEnumerable<Student> Search(Student student, bool DOBFlag)//SELECT WHERE
        {
            IDataReader dataReader = null;
            string SQLSearch = "SELECT * FROM Student";
            var searchResult = new List<Student>();
            var parameters = new List<SqlParameter>();
            try
            {
                if (student.StudentID != 0 || !student.StudentName.Equals(string.Empty) || !student.Gender.Equals(string.Empty) || !DOBFlag || !student.Major.Equals(string.Empty))
                {
                    SQLSearch += " WHERE ";
                    if(student.StudentID != 0)
                    {
                        SQLSearch += "StudentID = @StudentID AND ";
                        parameters.Add(dataProvider.CreateParameter("@StudentID", 4, student.StudentID, DbType.Int32));
                    }
                    if (!student.StudentName.Equals(string.Empty))
                    {
                        SQLSearch += "StudentName = @StudentName AND ";
                        parameters.Add(dataProvider.CreateParameter("@StudentName", 50, student.StudentName, DbType.String));
                    }
                    if (!student.Gender.Equals(string.Empty))
                    {
                        SQLSearch += "Gender = @Gender AND ";
                        parameters.Add(dataProvider.CreateParameter("@Gender", 10, student.Gender, DbType.String));
                    }
                    if (!DOBFlag)
                    {
                        SQLSearch += "DOB = @DOB AND ";
                        parameters.Add(dataProvider.CreateParameter("@DOB", 50, student.DOB, DbType.Date));
                    }
                    if (!student.Major.Equals(string.Empty))
                    {
                        SQLSearch += "Major = @Major AND ";
                        parameters.Add(dataProvider.CreateParameter("@Major", 50, student.Major, DbType.String));
                    }
                    SQLSearch = SQLSearch.Substring(0, SQLSearch.Length - 5);
                }

                dataReader = dataProvider.GetDataReader(SQLSearch, CommandType.Text, out connection, parameters.ToArray());
                while (dataReader.Read())
                {
                    searchResult.Add(new Student
                    {
                        StudentID = dataReader.GetInt32(0),
                        StudentName = dataReader.GetString(1),
                        Gender = dataReader.GetString(2),
                        DOB = dataReader.GetDateTime(3),
                        Major = dataReader.GetString(4)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //dataReader.Close();
                CloseConnection();
            }
            return searchResult;
        }

        public IEnumerable<Student> Filter(Student student, bool DOBFlag)//SELECT WHERE
        {
            IDataReader dataReader = null;
            string SQLFilter = "SELECT * FROM Student";
            var searchResult = new List<Student>();
            var parameters = new List<SqlParameter>();
            try
            {
                if (student.StudentID != 0 || !student.StudentName.Equals(string.Empty) || !student.Gender.Equals(string.Empty) || !DOBFlag || !student.Major.Equals(string.Empty))
                {
                    SQLFilter += " WHERE ";
                    if (student.StudentID != 0)
                    {
                        SQLFilter += "StudentID LIKE '%@StudentID%' AND ";
                        parameters.Add(dataProvider.CreateParameter("@StudentID", 4, student.StudentID, DbType.Int32));
                    }
                    if (!student.StudentName.Equals(string.Empty))
                    {
                        SQLFilter += "StudentName LIKE '%@StudentName%' AND ";
                        parameters.Add(dataProvider.CreateParameter("@StudentName", 50, student.StudentName, DbType.String));
                    }
                    if (!student.Gender.Equals(string.Empty))
                    {
                        SQLFilter += "Gender LIKE '%@Gender%' AND ";
                        parameters.Add(dataProvider.CreateParameter("@Gender", 10, student.Gender, DbType.String));
                    }
                    if (!DOBFlag)
                    {
                        SQLFilter += "DOB LIKE '%@DOB%' AND ";
                        parameters.Add(dataProvider.CreateParameter("@DOB", 50, student.DOB, DbType.Date));
                    }
                    if (!student.Major.Equals(string.Empty))
                    {
                        SQLFilter += "Major LIKE '%@Major%' AND ";
                        parameters.Add(dataProvider.CreateParameter("@Major", 50, student.Major, DbType.String));
                    }

                    SQLFilter = SQLFilter.Substring(0, SQLFilter.Length - 5);
                }

                dataReader = dataProvider.GetDataReader(SQLFilter, CommandType.Text, out connection, parameters.ToArray());
                while (dataReader.Read())
                {
                    searchResult.Add(new Student
                    {
                        StudentID = dataReader.GetInt32(0),
                        StudentName = dataReader.GetString(1),
                        Gender = dataReader.GetString(2),
                        DOB = dataReader.GetDateTime(3),
                        Major = dataReader.GetString(4)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //dataReader.Close();
                CloseConnection();
            }
            return searchResult;
        }

        public bool GetLogin(Admin admin)
        {
            bool result;
            try
            {
                var parameters = new List<SqlParameter>();
                IDataReader dataReader = null;
                string SQLSelect = "SELECT * FROM [Admin] WHERE Username = '@UserName' AND Password = '@Password'";
                parameters.Add(dataProvider.CreateParameter("@Username", 50, admin.Username, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Password", 50, admin.Password, DbType.String));
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                if (dataReader.Read())
                {
                    result =  true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //dataReader.Close();
                CloseConnection();
            }
            return result;
        }
    }
}
