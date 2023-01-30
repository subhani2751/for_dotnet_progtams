using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Ajax_First_pro.DAL
{
    public class DBlayar
    {
        public int Save(Models.ModelLayar em)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            con.Open();
            /*var date = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(em.DOB))*/;
            //var sqr = string.Format(@"INSERT INTO AjaxEmp2 values({0},'{1}',{2},'{3}','{4}','{5}','{6}','{7}');", em.ID, em.Name, em.Salary, date, em.Email, em.Address, em.Gender, em.Qualification);
            //SqlCommand cmd = new SqlCommand(sqr, con);
            SqlCommand cmd = new SqlCommand("Save_E", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", em.ID);
            cmd.Parameters.AddWithValue("@Name", em.Name);
            cmd.Parameters.AddWithValue("@Salary", em.Salary);
            var date = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(em.DOB));
            cmd.Parameters.AddWithValue("@DOB", date);
            cmd.Parameters.AddWithValue("@Email", em.Email);
            cmd.Parameters.AddWithValue("@Address", em.Address);
            cmd.Parameters.AddWithValue("@Gender", em.Gender);
            cmd.Parameters.AddWithValue("@Qual", em.Qualification);
            int i=cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Update(Models.ModelLayar em)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Update_E", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", em.ID);
            cmd.Parameters.AddWithValue("@Name", em.Name);
            cmd.Parameters.AddWithValue("@Salary", em.Salary);
            var date = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(em.DOB));
            cmd.Parameters.AddWithValue("@DOB", date);
            cmd.Parameters.AddWithValue("@Email", em.Email);
            cmd.Parameters.AddWithValue("@Address", em.Address);
            cmd.Parameters.AddWithValue("@Gender", em.Gender);
            cmd.Parameters.AddWithValue("@Qual", em.Qualification);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Delete(int id=1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete_E", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public Models.ModelLayar Search(int id)
        {
            Models.ModelLayar em = new Models.ModelLayar();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Search_E", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    em.ID = Convert.ToInt32(dr[0]);
                    em.Name = Convert.ToString(dr[1]);
                    em.Salary = Convert.ToDouble(dr[2]);
                    var date = string.Format("{0:dd/MM/yyyy}", dr[3]);
                    em.DOB = Convert.ToString(date);
                    em.Email = Convert.ToString(dr[4]);
                    em.Address = Convert.ToString(dr[5]);
                    em.Gender = Convert.ToString(dr[6]);
                    em.Qualification = Convert.ToString(dr[7]);
                }
            }
            con.Close();
            return em;
        }
        public List<Models.ModelLayar> All()
        {
            List<Models.ModelLayar> eml = new List<Models.ModelLayar>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("All_E", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Models.ModelLayar em = new Models.ModelLayar();
                    em.ID = Convert.ToInt32(dr[0]);
                    em.Name = Convert.ToString(dr[1]);
                    em.Salary = Convert.ToDouble(dr[2]);
                    var date = string.Format("{0:dd/MM/yyyy}", dr[3]);
                    em.DOB = Convert.ToString(date);
                    em.Email = Convert.ToString(dr[4]);
                    em.Address = Convert.ToString(dr[5]);
                    em.Gender = Convert.ToString(dr[6]);
                    em.Qualification = Convert.ToString(dr[7]);
                    eml.Add(em);
                }
            }
            con.Close();
            return eml;
        }
    }
}