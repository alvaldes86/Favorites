using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Favorites
{
    public partial class FilesForm : Form
    {
        public FilesForm()
        {
            InitializeComponent();
        }

        private void saveData(string fileName)
        {
            System.IO.StreamWriter myFile = new System.IO.StreamWriter(fileName);
            try
            {
                myFile.WriteLine(txtName.Text);         //write data to file
                myFile.WriteLine(txtNumber.Text);
                for(int index = 0; index < lstColor.Items.Count; index++)
                {
                    myFile.WriteLine(lstColor.Items[index]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File exception " + ex.Message, "File error (write)");
            }
            finally
            {
                myFile.Close();   //close file
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string pathFileName = Path.Combine(Application.StartupPath, "favorite.txt");
            saveData(pathFileName);
        }
        private void clearData()
        {
            txtName.Clear();
            txtNumber.Clear();
            txtColor.Clear();
            lstColor.Items.Clear();
        }
        private void openData(string fileName)
        {
            if (File.Exists(fileName))  //check that file exists
            {
                clearData();    //clear values on form
                StreamReader myFile = File.OpenText(fileName);   //open file
                try
                {
                    string input;

                    txtName.Text = myFile.ReadLine();   //read name from file
                    txtNumber.Text = myFile.ReadLine();   //read number from file
                    while (!myFile.EndOfStream)     //while end of file not reached
                    {
                        input = myFile.ReadLine();  //read next line from file
                        lstColor.Items.Add(input);  //add data to list box
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File exception " + ex.Message, "File error (write)");
                }
                finally
                {
                    myFile.Close();   //close file
                }
            }
            else
            {
                MessageBox.Show("File " + fileName + " does not exist", "Error");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //enData("favorite.txt");
            ofdOpenFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofdOpenFile.Title = "Select file to open";

            if(ofdOpenFile.ShowDialog() == DialogResult.OK)
            {
                openData(ofdOpenFile.FileName);
            }

        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            sfdSaveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            sfdSaveFile.Title = "Select file to save";

                if (sfdSaveFile.ShowDialog() == DialogResult.OK)
            {
                saveData(sfdSaveFile.FileName);
            }
        }

        private void FilesForm_Load(object sender, EventArgs e)
        {
            openData("favorite.txt");
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if(cdColor.ShowDialog() == DialogResult.OK)
            {
                lblTitle.ForeColor = cdColor.Color;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(fdFont.ShowDialog() == DialogResult.OK)
            {
                lblTitle.Font = fdFont.Font;
            }
        }
    }
}
continue 11 mnts left from the class