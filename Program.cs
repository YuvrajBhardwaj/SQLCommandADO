using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SQLCommandADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.connection();
            Console.ReadKey();
        }

        static void connection()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con;
            try
            {
                using (con = new SqlConnection(cs))
                {
                    Console.WriteLine("Employee Id: ");
                    string id = Console.ReadLine();
                    //Console.WriteLine("Employee Name: ");
                    //string name = Console.ReadLine();
                    //Console.WriteLine("Employee Gender: ");
                    //string gender = Console.ReadLine();
                    //Console.WriteLine("Employee Age: ");
                    //string age = Console.ReadLine();
                    //Console.WriteLine("Employee Salary: ");
                    //string salary = Console.ReadLine();
                    //Console.WriteLine("Employee City: ");
                    //string city = Console.ReadLine();

                    //string query = "insert into Employee_tbl values(@name,@gender,@age,@salary,@city)";
                    string query = "delete from Employee_tbl where id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    //cmd.Parameters.AddWithValue("@name",name);
                    //cmd.Parameters.AddWithValue("@gender", gender);
                    //cmd.Parameters.AddWithValue("@age", age);
                    //cmd.Parameters.AddWithValue("@salary", salary);
                    //cmd.Parameters.AddWithValue("@city", city);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("Data has been Deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Data Deletion failed.");
                    }
                    con.Close();

                    //string query = "spGetEmployees";
                    //SqlCommand cmd = new SqlCommand(query, con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    //con.Open();
                    //SqlDataReader dr = cmd.ExecuteReader();
                    //while (dr.Read())
                    //{
                    //    Console.WriteLine("ID= " + dr["ID"] + " Name= " + dr["Name"] + " Gender= " + dr["Gender"] + " Age= " + dr["Age"] + " Salary= " + dr["Salary"]);
                    //}
                    //con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            } 
        }
    }
}
