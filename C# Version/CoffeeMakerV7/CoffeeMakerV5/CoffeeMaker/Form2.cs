using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CoffeeMaker
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            fillList();
        }

        private void fillList()
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=CoffeeMaker.sqlite;Version=3;");
            SQLiteCommand dataBase = new SQLiteCommand(" select * from CoffeeMaker.sqlite ;", con);

            try
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter();
                sda.SelectCommand = dataBase;
                DataTable dbDataSet = new DataTable();
                sda.Fill(dbDataSet);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbDataSet;
                dataGridView1.DataSource = bSource;
                sda.Update(dbDataSet);
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

      
        }
    }
}
