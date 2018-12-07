using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorXML
{
    public partial class EditorXML : Form
    {
        public EditorXML()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        DataSet ds = new DataSet();
        string FName = "";

        private void button2_Click(object sender, EventArgs e)
        {         
           
            try
            {
                ds.Tables.Clear();
                comboBox1.Items.Clear();
            }
            catch
            {

            }


            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                try
                {                    
                    ds.ReadXml(OPF.FileName);
                    FName = OPF.FileName;
                    this.Text = FName;
                    for (int c = 0; c < ds.Tables.Count; c++)
                    {
                        comboBox1.Items.Add(ds.Tables[c].TableName);
                    }
                    BindingSource BS = new BindingSource();
                    BS.DataSource = ds;
                    dataGridView1.DataSource = BS;
                    comboBox1.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }                

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ds.WriteXml(FName);
            }
            catch
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {          

            try
            {
                int nr = 0;
                nr = comboBox1.SelectedIndex;
                dataGridView1.DataMember = ds.Tables[nr].TableName.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
    }
}
