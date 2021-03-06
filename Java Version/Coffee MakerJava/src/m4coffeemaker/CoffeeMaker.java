package m4coffeemaker;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import model.CoffeeMachineStates.*;
import view.Frame;
import view.LogFrame;

public class CoffeeMaker implements ActionListener {
	static CoffeeMaker coffeeMaker;
	static Frame frame;
	static M4CoffeeMakerAPI api;
	static M4UserInterface ui;
	static M4HotWaterSource hws;
	static M4ContainmentVessel cv;
	static LogWriter logWriter;
	static BoilerStatus physicalBoilerStatus;
	static WarmerPlateStatus phycialWarmerPlateStatus;
	static LogFrame logFrame;

	public static void main(String[] args) {
		coffeeMaker = new CoffeeMaker();

		api = new M4CoffeeMakerAPI();
		ui = new M4UserInterface(api);
		hws = new M4HotWaterSource(api);
		cv = new M4ContainmentVessel(api);

		logFrame = new LogFrame();
		
		
		physicalBoilerStatus = api.getBoilerStatus();
		phycialWarmerPlateStatus = api.getWarmerPlateStatus();

		frame = new Frame(api);
		frame.addListeners(coffeeMaker);

		ui.init(hws, cv);
		hws.init(ui, cv);
		cv.init(ui, hws);

		// Need to keep track of each machine state, and print the changes to
		// the log each iteration
		
		logWriter = new LogWriter(api);

		while (true) {
			if (api.getCoffeeMachineState()) {

				// Save current state of everything

				// Handle sensor overrides
				switch (frame.getWarmerPlateOverrideSelection()) {
				case "Pot Missing":
					api.setWarmerPlateStatus(WarmerPlateStatus.WARMER_EMPTY);
					break;

				case "Pot Empty":
					api.setWarmerPlateStatus(WarmerPlateStatus.POT_EMPTY);
					break;
				case "Pot Not Empty":
					api.setWarmerPlateStatus(WarmerPlateStatus.POT_NOT_EMPTY);
					break;
				case "Automatic":
					api.setWarmerPlateStatus(phycialWarmerPlateStatus);
					break;
				}

				switch (frame.getBoilerOverrideSelection()) {
				case "Boiler Empty":
					api.setBoilerStatus(BoilerStatus.EMPTY);
					break;

				case "Boiler Not Empty":
					api.setBoilerStatus(BoilerStatus.NOT_EMPTY);
					break;
				case "Automatic":
					api.setBoilerStatus(physicalBoilerStatus);
					break;
				}

				// Save any changes to log
				try {
					logWriter.updateLog();
				} catch (Exception e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

				ui.poll();

				// Save any changes to log
				try {
					logWriter.updateLog();
				} catch (Exception e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				
				hws.poll();

				// Save any changes to log
				try {
					logWriter.updateLog();
				} catch (Exception e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

				cv.poll();

				// Save any changes to log
				try {
					logWriter.updateLog();
				} catch (Exception e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

			}
			frame.updateDisplay(physicalBoilerStatus, phycialWarmerPlateStatus);

		}
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		switch (e.getActionCommand()) {
		case "Fill Pot":
			phycialWarmerPlateStatus = WarmerPlateStatus.POT_NOT_EMPTY;
			break;

		case "Empty Pot":
			phycialWarmerPlateStatus = WarmerPlateStatus.POT_EMPTY;
			break;

		case "Remove Pot":
			phycialWarmerPlateStatus = WarmerPlateStatus.WARMER_EMPTY;
			break;

		case "Empty Water Container":
			physicalBoilerStatus = BoilerStatus.EMPTY;
			break;

		case "Fill Water Container":
			physicalBoilerStatus = BoilerStatus.NOT_EMPTY;
			break;
		case "Brew":
			if (api.getCoffeeMachineState()) // if the machine is on
				api.SetBrewButtonStatus(BrewButtonStatus.PUSHED);
			break;
		case "On":
			api.turnOn();
			break;
		case "Off":
			api.turnOff();
			break;
		case "Check Log":
			logFrame.display();

		}
		// Save any changes to log
		try {
			logWriter.updateLog();
		} catch (Exception ex) {
			// TODO Auto-generated catch block
			ex.printStackTrace();
		}

	}
}