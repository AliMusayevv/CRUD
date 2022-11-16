using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace SQLConn
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(DataSource.DS);

        private void ShowData(string data)
        {
            SqlDataAdapter da = new SqlDataAdapter(data, connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdData.DataSource = ds.Tables[0];



        }


        public  void Strings()
        {
            
            string ID = textBoxID.Text;
            string Name =txtName.Text;
            string Surname =txtSurname.Text;
            string Dadname = txtDAdname.Text;
            string Birthdate=txtBirthdate.Text; 
            string Addres =txtAddres.Text;  
            string Email   =txtEmail.Text;
            string GrNumber=txtGrNumber.Text;
            string Gender =cmbBoxGender.Text;
            string Status = cmbBoxStatus.Text;
            string StsDes = cmbBoxStsDes.Text;

            CRUD.Add(ID, Name, Surname, Dadname, Birthdate, Addres, Email, GrNumber, Gender, Status, StsDes);
        }
    
        public  void ShowInTextBox()
        {

            textBoxID.Text = grdData.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = grdData.CurrentRow.Cells[1].Value.ToString();
            txtSurname.Text = grdData.CurrentRow.Cells[2].Value.ToString();
            txtDAdname.Text = grdData.CurrentRow.Cells[3].Value.ToString();
            txtBirthdate.Text = grdData.CurrentRow.Cells[4].Value.ToString();
            txtAddres.Text = grdData.CurrentRow.Cells[5].Value.ToString();
            txtEmail.Text = grdData.CurrentRow.Cells[6].Value.ToString();
            txtGrNumber.Text = grdData.CurrentRow.Cells[7].Value.ToString();
            cmbBoxGender.Text = grdData.CurrentRow.Cells[8].Value.ToString();
            cmbBoxStatus.Text = grdData.CurrentRow.Cells[9].Value.ToString();
            cmbBoxStsDes.Text = grdData.CurrentRow.Cells[10].Value.ToString();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {

            Watch();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Strings();
            textBoxClear();
            Watch();    
            
        }

        private void textBoxClear()
        {
            textBoxID.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtDAdname.Clear();
            txtBirthdate.Clear();
            txtAddres.Clear();
            txtEmail.Clear();
            txtGrNumber.Clear();
            cmbBoxGender.ResetText();
            cmbBoxStatus.ResetText();
            cmbBoxStsDes.ResetText();

        }
        private void Watch()
        {

            string dates = "SELECT * from Student";

            SqlCommand s = new SqlCommand(dates, connection);

            SqlDataAdapter da = new SqlDataAdapter(s);

            DataTable dt = new DataTable();
            da.Fill(dt);

            grdData.DataSource = dt;
            textBoxClear();


        }





        private void btnDelete_Click(object sender, EventArgs e)
        {


            string ID = textBoxID.Text;
            

            CRUD.Delete(ID);
            textBoxClear();
            Watch();    
           


        }

        private void btnShowWithID_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBoxID.Text == "")
                {
                    ShowData("Select*from Student");

                }
                else
                {
                    string X = textBoxID.Text;
                    ShowData("Select*from Student Where ID = '" + X + "'");
                }

            }
            catch
            {
                MessageBox.Show("Something is wrong", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ShowInTextBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string ID = textBoxID.Text;
            string Name = txtName.Text;
            string Surname = txtSurname.Text;
            string Dadname = txtDAdname.Text;
            string Birthdate = txtBirthdate.Text;
            string Addres = txtAddres.Text;
            string Email = txtEmail.Text;
            string GrNumber = txtGrNumber.Text;
            string Gender = cmbBoxGender.Text;
            string Status = cmbBoxStatus.Text;
            string StsDes = cmbBoxStsDes.Text;

            CRUD.Update(ID, Name, Surname, Dadname, Birthdate, Addres, Email, GrNumber, Gender, Status, StsDes);
            textBoxClear();
            Watch();

        }
    
       public void btnClear_Click(object sender, EventArgs e)
        {
            textBoxClear();
        }

        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }
       

       
    }
}
