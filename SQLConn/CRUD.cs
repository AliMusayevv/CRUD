using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SQLConn
{
    internal class CRUD
    {

        private static SqlConnection connection = new SqlConnection(DataSource.DS);



        public static void Add(string ID,  string Name, string Surname, string Dadname, string Birthdate, string Addres, string Email, string GrNumber, string Gender, string Status, string StsDes)
        {
            try
            {
                

                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into Student (ID,Name,Surname,Dadname,Birthdate,Addres,Email,Group_Number,Gender,Status,StatusDescription) values('" +  ID + "','" + Name + "','" + Surname + "','" + Dadname + "','" + Birthdate + "','" + Addres + "','" + Email + "','" + GrNumber + "','" +Gender+ "','" + Status + "','" + StsDes+ "')", connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();



            }
            catch
            {
                MessageBox.Show("Something is wrong", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }


      
        public static void Delete(string ID)
        {
            try
            {


                connection.Open();
                 int ID_prm = Int32.Parse(ID);
                SqlCommand sqlCommand = new SqlCommand("delete from Student where ID=(" + ID + ")", connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();


            }
            catch
            {
                MessageBox.Show("Something is wrong", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        public static void Update(string ID, string Name, string Surname, string Dadname, string Birthdate, string Addres, string Email, string GrNumber, string Gender, string Status, string StsDes)
        {
            try
            {


                connection.Open();
                int ID_prm = Int32.Parse(ID);
                SqlCommand sqlCommand = new SqlCommand("Update Student set ID ='" + ID + "', Name = '" + Name + "',Surname='" + Surname + "',Dadname='" + Dadname + "',Birthdate='" + Birthdate + "',Addres='" + Addres + "',Email='" + Email + "',Group_Number='" + GrNumber + "',Gender='" + Gender + "',Status='" + Status + "',StatusDescription='" + StsDes + "' where ID =" + ID_prm + "", connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();


            }
            catch
            {


                MessageBox.Show("Something is wrong", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

       
        
           
            


        }

    }


