using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace vBlockFormsApp
{
    public partial class InstanceSearcherView : Form
    {
        
        string filterField = "Machine Name";
        DataTable vBlockDataTable = new DataTable();
        string cellContents = "";

        public string machineName { get; set; }
        public string vBlock { get; set; }
        public string URL { get; set; }
        public string folder { get; set; }
        public string subFolder { get; set; }
        private static string _csvLocation = @"C:\Users\achapman\Desktop\vBlock.csv";


        public static string csvLocation
        {
            get { return _csvLocation; }
            set { _csvLocation = value; }
        }


        public InstanceSearcherView()
        {
            InitializeComponent();
            

            vBlockDataTable.Columns.Add("Machine Name", typeof(string));
            vBlockDataTable.Columns.Add("vBlock", typeof(string));
            vBlockDataTable.Columns.Add("URL", typeof(string));
            vBlockDataTable.Columns.Add("Folder", typeof(string));
            vBlockDataTable.Columns.Add("Sub-Folder", typeof(string));


            #region
            try
            {
                using (StreamReader SR = new StreamReader(csvLocation))
                {
                    string[] streamValuesArray;

                    while (!SR.EndOfStream)
                    {
                        string streamInput = SR.ReadLine().Trim();

                        if (streamInput.Length > 0)
                        {
                            streamValuesArray = streamInput.Split(',');

                            vBlockDataTable.Rows.Add(new object[] {
                            streamValuesArray[0],
                            streamValuesArray[1],
                            streamValuesArray[2],
                            streamValuesArray[3],
                            streamValuesArray[4]
                        });

                        }

                    }

                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("File not found at specified location");
                throw;
            }
            
            #endregion

            vBlockDataGrid.DataSource = vBlockDataTable;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (vBlockDataTable as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, textBox1.Text);
        }

        private void vBlockDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 2)
            {
                

                cellContents = vBlockDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                
                try
                {
                    ProcessStartInfo ps = new ProcessStartInfo(cellContents);
                    Process.Start(ps);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    throw;
                }
            }
            
        }

       
    }
}
