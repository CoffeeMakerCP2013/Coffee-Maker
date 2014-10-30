using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using M4CoffeeMaker;
using CoffeeMaker;
using System.Data.SQLite;

namespace CoffeeMaker
{
    public partial class Form1 : Form
    {
        bool coffeeMachineON = false;
        M4CoffeeMakerAPI API;
        M4UserInterface ui;
        M4HotWaterSource hws;
        M4ContainmentVessel cv;
        SQLiteConnection con;
        SQLiteCommand com;
        Form2 formTwo = new Form2();

        public Form1(M4CoffeeMakerAPI APIIN, M4UserInterface uiIN, M4HotWaterSource hwsIN, M4ContainmentVessel cvIN)
        {
            InitializeComponent();
            API = APIIN;
            ui = uiIN;
            hws = hwsIN;
            cv = cvIN;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Coffee Machine - C#";
        }

        private void pEmptyPot_Click(object sender, EventArgs e)
        {
            if (coffeeMachineON && comboBox4.SelectedItem.ToString() == "Automatic")
            {
                API.SetWarmerPlateStatus(WarmerPlateStatus.POT_EMPTY);
            }
        }

        private void pFullPot_Click(object sender, EventArgs e)
        {
            if (coffeeMachineON && comboBox4.SelectedItem.ToString() == "Automatic")
            {
                API.SetWarmerPlateStatus(WarmerPlateStatus.POT_NOT_EMPTY);
            }
        }

        private void rPot_Click(object sender, EventArgs e)
        {
            if (coffeeMachineON && comboBox4.SelectedItem.ToString() == "Automatic")
            {
                API.SetWarmerPlateStatus(WarmerPlateStatus.WARMER_EMPTY);
            }
        }

        private void emptyWaterCONT_Click(object sender, EventArgs e)
        {
            if (coffeeMachineON && comboBox1.SelectedItem.ToString() == "Automatic")
            {
                API.SetBoilerStatus(BoilerStatus.EMPTY);
            }
        }

        private void fillWaterCONT_Click(object sender, EventArgs e)
        {
            if (coffeeMachineON && comboBox1.SelectedItem.ToString() == "Automatic")
            {
                API.SetBoilerStatus(BoilerStatus.NOT_EMPTY);
            }
        }

        private void brew_Click(object sender, EventArgs e)
        {
            if (coffeeMachineON)
            {
                API.SetBrewButtonStatus(BrewButtonStatus.PUSHED);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            coffeeMachineON = true;
            statusLBL.Text = "Status : ON";
            pictureBox1.Image = CoffeeMaker.Properties.Resources.we_pm;
            statusTMR.Enabled = true;
            setupConnectionToSQLite();
            databaseTMR.Enabled = true;

        }

        private void setupConnectionToSQLite()
        {
            //String mySqlConnectionString = "Server=sql5.freemysqlhosting.net;Database=sql555821;UID=xxx_root;Password=xxx;Port=3306";
            con = new SQLiteConnection("Data Source=CoffeeMaker.sqlite;Version=3;");
            com = new SQLiteCommand(con);
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            coffeeMachineON = false;
            statusLBL.Text = "Status : OFF";
            statusTMR.Enabled = false;
            brewSTS.Text = "Brew Status ";
            indicatorState.Text = "Indicator State ";
            boilerState.Text = "Boiler State ";
            warmerState.Text = "Warmer State ";
            pictureBox1.Image = null;
            con.Close();
            


        }

        private void statusTMR_Tick(object sender, EventArgs e)
        {
            if (coffeeMachineON)
            {
                ui.Poll();
                hws.Poll();
                cv.Poll();

                checkCombobox();
                updatePictureBox();

                brewSTS.Text = "Brew Status " + API.GetBrewButtonStatus();
                indicatorState.Text = "Indicator State " + API.GetIndicatorState();
                boilerState.Text = "Boiler State " + API.GetBoilerState();
                warmerState.Text = "Warmer State " + API.GetWarmerState();

                
                //writeToDatabase();

            }
        }

        private void writeToDatabase()
        {
            string currentDate = DateTime.Now.ToString("h:mm:ss tt");
            string JustTesting = " ";
            //con.Open();

            //string sql ="INSERT INTO LogTable values('currentDate' ,'JustTesting')";

            com.CommandText = "INSERT INTO LogTable values ('" + currentDate + "','" + JustTesting + "');";
            com.ExecuteNonQuery();
                //SQLiteCommand command = new SQLiteCommand(sql, con);
            //command.ExecuteNonQuery();

            //con.Close();

        }

        private void checkCombobox()
        {
            if (comboBox4.SelectedItem.ToString() != "Automatic")
            {
                if (comboBox4.SelectedItem.ToString() == "Pot missing")
                {
                    API.SetWarmerPlateStatus(WarmerPlateStatus.WARMER_EMPTY);
                }
                else if (comboBox4.SelectedItem.ToString() == "Pot empty")
                {
                    API.SetWarmerPlateStatus(WarmerPlateStatus.POT_EMPTY);
                }
                else if (comboBox4.SelectedItem.ToString() == "Pot not empty")
                {
                    API.SetWarmerPlateStatus(WarmerPlateStatus.POT_NOT_EMPTY);
                }
            }
            if (comboBox1.SelectedItem.ToString() != "Automatic")
            {
                if (comboBox1.SelectedItem.ToString() == "Boiler empty")
                {
                    API.SetBoilerStatus(BoilerStatus.EMPTY);
                }
                else if (comboBox1.SelectedItem.ToString() == "Boiler not empty")
                {
                    API.SetBoilerStatus(BoilerStatus.NOT_EMPTY);
                }
            }
        }

        private void updatePictureBox()
        {
            if (API.GetBoilerStatus() == BoilerStatus.EMPTY && API.GetWarmerPlateStatus() == WarmerPlateStatus.WARMER_EMPTY)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = CoffeeMaker.Properties.Resources.we_pm;
            }
            else if (API.GetBoilerStatus() == BoilerStatus.EMPTY && API.GetWarmerPlateStatus() == WarmerPlateStatus.POT_NOT_EMPTY)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = CoffeeMaker.Properties.Resources.we_pf;
            }
            else if (API.GetBoilerStatus() == BoilerStatus.EMPTY && API.GetWarmerPlateStatus() == WarmerPlateStatus.POT_EMPTY)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = CoffeeMaker.Properties.Resources.we_pe;
            }
            else if (API.GetBoilerStatus() == BoilerStatus.NOT_EMPTY && API.GetWarmerPlateStatus() == WarmerPlateStatus.WARMER_EMPTY)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = CoffeeMaker.Properties.Resources.wf_pm;
            }
            else if (API.GetBoilerStatus() == BoilerStatus.NOT_EMPTY && API.GetWarmerPlateStatus() == WarmerPlateStatus.POT_EMPTY)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = CoffeeMaker.Properties.Resources.wf_pe;
            }
            else if (API.GetBoilerStatus() == BoilerStatus.NOT_EMPTY && API.GetWarmerPlateStatus() == WarmerPlateStatus.POT_NOT_EMPTY)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = CoffeeMaker.Properties.Resources.wf_pf;
            }
        }

        private void checkLOGBTN_Click(object sender, EventArgs e)
        {
            databaseTMR.Enabled = false;
            formTwo.Show();

            /*
            com.CommandText = "Select * FROM LogTable";
            SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Console.
                    Console.WriteLine(reader["Date"] + " : " + reader["Status"]);     // Display the value of the key and value column for every row
                }
             */
        }

        private void databaseTMR_Tick(object sender, EventArgs e)
        {
            writeToDatabase();
        }

    }
}
