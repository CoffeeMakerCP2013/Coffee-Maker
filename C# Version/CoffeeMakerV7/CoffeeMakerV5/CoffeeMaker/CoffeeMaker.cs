using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeMaker;

namespace M4CoffeeMaker
{
    public class M4CoffeeMaker
    {
        public static void Main(string[] args)
        {
            M4CoffeeMakerAPI api = new M4CoffeeMakerAPI();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            M4UserInterface ui = new M4UserInterface(api);
            M4HotWaterSource hws = new M4HotWaterSource(api);
            M4ContainmentVessel cv = new M4ContainmentVessel(api);
            ui.Init(hws, cv);
            hws.Init(ui, cv);
            cv.Init(ui, hws);
            Application.Run(new Form1(api, ui, hws, cv));

       }
    }
}
