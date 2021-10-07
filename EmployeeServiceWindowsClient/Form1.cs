using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeServiceWindowsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeService.EmployeeServiceClient client = new  EmployeeService.EmployeeServiceClient();
            if (textBoxId.Text.ToString() != "")
            {
                EmployeeService.Employee employee = client.GetEmployee(Convert.ToInt32(textBoxId.Text));
             //   var typeemp = typeof(employee.);
                if(employee == null)
                {
                    lblMessage.ForeColor = Color.Red;
                    textBoxName.Text = textBoxId.Text = textBoxDOB.Text = comboBoxGender.Text = "";

                    lblMessage.Text = "Employee does not found.";
                    return;
                }
              

                textBoxName.Text = employee.Name;

                comboBoxGender.Text = employee.Gender;
                textBoxDOB.Text = employee.DateOfBirth.ToShortDateString();
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Employee retrieved";
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Invalid Id. Please enter correct id.";
            }
            
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeService.Employee employee = new EmployeeService.Employee();



            if (textBoxId.Text != "" && textBoxName.Text != "" && textBoxDOB.Text != "" && comboBoxGender.Text != "")
            {

                employee.Id = Convert.ToInt32(textBoxId.Text);
                employee.Name = textBoxName.Text;
                employee.Gender = comboBoxGender.Text;
                employee.DateOfBirth = Convert.ToDateTime(textBoxDOB.Text);
                 EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient();
                client.SaveEmployee(employee);
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Employee saved";
                
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Please check your all fields are corect.";
               
            }
           
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBoxDOB.Text = textBoxId.Text = textBoxName.Text = comboBoxGender.Text = lblMessage.Text = "";
            

        }
    }
}
