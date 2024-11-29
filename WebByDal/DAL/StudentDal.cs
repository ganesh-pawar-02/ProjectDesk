using Microsoft.Data.SqlClient;
using WebByDal.Models;

namespace WebByDal.DAL
{
    public class StudentDal
    {
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=College;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False";

        public List<Student> GetStudents()
        {
            string qry = "select * from Student";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(qry, conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> list = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student();
                student.Id = Convert.ToInt32(reader["Id"]);
                student.Name = reader["Name"].ToString();
                student.Project = reader["Project"].ToString();
                list.Add(student);

            }
            conn.Close();
            return list;

        }
        public int AddStudent(Student student)
        {
            SqlConnection conn = new SqlConnection(connString);
            string qry = "insert into Student (Name,Project) Values ('{0}','{1}')";
            string qryTxt = string.Format(qry, student.Name, student.Project);

            SqlCommand cmd = new SqlCommand(qryTxt, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            return rows;

        }
        public Student GetStudent(int id)
        {
            List<Student> list = GetStudents();
            Student foundStudent = (from student in list
                                    where student.Id == id
                                    select student).First();
            return foundStudent;
        }
        public int UpdateStudent(Student s)
        {
            SqlConnection con = new SqlConnection(connString);
            string qry = "update Student set Name= '{1}', Project='{2}' where Id= {0}";
            string qryTxt=string.Format(qry, s.Id,s.Name,s.Project);
            SqlCommand cmd = new SqlCommand(qryTxt, con);
            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();
            return rows;
        }
        public int DeleteStudent(int id)
        {
            SqlConnection con = new SqlConnection(connString);
            string qry = "delete from Student where Id= {0}";
            string aryTxt=string.Format(qry, id);
            con.Open();
            SqlCommand cmd=new SqlCommand(aryTxt, con);
            int rows=cmd.ExecuteNonQuery();
            con.Close();
            return rows;

        }
    }
}
