package m4coffeemaker;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Calendar;
import java.util.Date;

import model.CoffeeMachineStates.*;

public class LogWriter {
	WarmerPlateStatus oldWarmerPlateStatus;
	BoilerStatus oldBoilerStatus;
	BoilerState oldBoilerState;
	IndicatorState oldIndicatorState;
	ReliefValveState oldReliefValveState;
	WarmerState oldWarmerState;
	boolean oldMachineState;
	M4CoffeeMakerAPI api;

	public LogWriter(M4CoffeeMakerAPI api) {
		this.api = api;
		setupStates();

	}

	private void setupStates() {
		oldWarmerPlateStatus = api.getWarmerPlateStatus();
		oldBoilerStatus = api.getBoilerStatus();
		oldBoilerState = api.getBoilerState();
		oldIndicatorState = api.getIndicatorState();
		oldReliefValveState = api.getReliefValveState();
		oldWarmerState = api.getWarmerState();
		oldMachineState = api.getCoffeeMachineState();
	}

	public void updateLog() throws Exception {
		// Compare old states with current state via api.getstates()

		// Get current time and date
		Calendar now = Calendar.getInstance();

		// Check if each state has changed
		if (api.getBoilerState() != oldBoilerState) {

			String str = "Boiler state changed from "
					+ oldBoilerState.toString() + " to " + api.getBoilerState();
			write(now.getTime(), str);

			// Update the state
			oldBoilerState = api.getBoilerState();

		}

		if (api.getWarmerPlateStatus() != oldWarmerPlateStatus) {

			String str = "Warmer plate status (sensor) changed from "
					+ oldWarmerPlateStatus.toString() + " to "
					+ api.getWarmerPlateStatus();
			write(now.getTime(), str);

			// Update the state
			oldWarmerPlateStatus = api.getWarmerPlateStatus();

		}

		if (api.getBoilerStatus() != oldBoilerStatus) {

			String str = "Boiler status (sensor) changed from "
					+ oldBoilerStatus.toString() + " to "
					+ api.getBoilerStatus();
			write(now.getTime(), str);

			// Update the state
			oldBoilerStatus = api.getBoilerStatus();

		}

		if (api.getBoilerState() != oldBoilerState) {

			String str = "Boiler state changed from "
					+ oldBoilerState.toString() + " to " + api.getBoilerState();
			write(now.getTime(), str);

			// Update the state
			oldBoilerState = api.getBoilerState();

		}

		if (api.getIndicatorState() != oldIndicatorState) {

			String str = "Indicator state changed from "
					+ oldIndicatorState.toString() + " to "
					+ api.getIndicatorState();
			write(now.getTime(), str);

			// Update the state
			oldIndicatorState = api.getIndicatorState();

		}

		if (api.getReliefValveState() != oldReliefValveState) {

			String str = "Relief valve state changed from "
					+ oldReliefValveState.toString() + " to "
					+ api.getReliefValveState();
			write(now.getTime(), str);

			// Update the state
			oldReliefValveState = api.getReliefValveState();

		}

		if (api.getWarmerState() != oldWarmerState) {

			String str = "Warmer state changed from "
					+ oldWarmerState.toString() + " to " + api.getWarmerState();
			write(now.getTime(), str);

			// Update the state
			oldWarmerState = api.getWarmerState();

		}

		if (api.getCoffeeMachineState() != oldMachineState) {

			String str = "Machine state state changed from " + oldMachineState
					+ " to " + api.getCoffeeMachineState();
			write(now.getTime(), str);

			// Update the state
			oldMachineState = api.getCoffeeMachineState();

		}
		// Write only changes to the log

		// Update old states with current states

	}

	public void write(Date d, String s) throws SQLException,
			ClassNotFoundException {
		// Write into the log d and s.

		Class.forName("com.mysql.jdbc.Driver");

		Connection con = null;

		con = DriverManager.getConnection("jdbc:mysql://sql5.freemysqlhosting.net/sql555821",
				"sql555821", "nD8!cN9*");//CONNECTION

		java.sql.Statement st = null;

		st = con.createStatement();

		String query = "insert into LogTable values('" + d + "','" + s + "');";

		int result = st.executeUpdate(query);

	}
}
