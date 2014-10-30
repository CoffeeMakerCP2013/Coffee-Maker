package m4coffeemaker;

import model.CoffeeMachineStates.*;

import coffeemaker.CoffeeMakerAPI;

public class M4CoffeeMakerAPI implements CoffeeMakerAPI {
	WarmerPlateStatus warmerPlateStatus;
	BoilerStatus boilerStatus;
	BrewButtonStatus brewButtonStatus;
	BoilerState boilerState;
	IndicatorState indicatorState;
	ReliefValveState reliefValveState;
	WarmerState warmerState;
	Boolean coffeeMachineOn;

	M4CoffeeMakerAPI() {
		warmerPlateStatus = WarmerPlateStatus.POT_EMPTY;
		boilerStatus = BoilerStatus.EMPTY;
		brewButtonStatus = BrewButtonStatus.NOT_PUSHED;
		boilerState = BoilerState.OFF;
		indicatorState = IndicatorState.OFF;
		reliefValveState = ReliefValveState.CLOSED;
		warmerState = WarmerState.OFF;
		coffeeMachineOn = false;
	}

	public Boolean getCoffeeMachineState() {
		return coffeeMachineOn;
	}

	public void setCoffeeMachineState(Boolean s) {
		coffeeMachineOn = s;
	}
	
	public void turnOn(){
		//Turns the machine on, and resets everything
		coffeeMachineOn = true;
		warmerState = WarmerState.OFF;
		boilerState = BoilerState.OFF;
		indicatorState = IndicatorState.OFF;
		reliefValveState = ReliefValveState.CLOSED;
		
	}
	
	public void turnOff(){
		//Turns the machine off, and disables everything
		coffeeMachineOn = false;
		warmerState = WarmerState.OFF;
		boilerState = BoilerState.OFF;
		indicatorState = IndicatorState.OFF;
		reliefValveState = ReliefValveState.CLOSED;
	}

	@Override
	public WarmerPlateStatus getWarmerPlateStatus() {
		// TODO Auto-generated method stub
		return warmerPlateStatus;

	}

	public void setWarmerPlateStatus(WarmerPlateStatus s) {
		warmerPlateStatus = s;
	}

	@Override
	public BoilerStatus getBoilerStatus() {
		// TODO Auto-generated method stub
		return boilerStatus;
	}

	public void setBoilerStatus(BoilerStatus s) {
		boilerStatus = s;
	}

	@Override
	public BrewButtonStatus getBrewButtonStatus() {
		// TODO Auto-generated method stub

		if (coffeeMachineOn) {

			if (brewButtonStatus == BrewButtonStatus.PUSHED) {
				brewButtonStatus = BrewButtonStatus.NOT_PUSHED;
				return BrewButtonStatus.PUSHED;
			} else {
				return BrewButtonStatus.NOT_PUSHED;
			}
		} else {
			brewButtonStatus = BrewButtonStatus.NOT_PUSHED;
			return brewButtonStatus;
		}
	}

	public void SetBrewButtonStatus(BrewButtonStatus s) {
		brewButtonStatus = s;
	}

	@Override
	public void setBoilerState(BoilerState s) {
		boilerState = s;

	}

	public BoilerState getBoilerState() {
		return boilerState;

	}

	@Override
	public void setWarmerState(WarmerState s) {
		warmerState = s;

	}

	public WarmerState getWarmerState() {
		return warmerState;

	}

	@Override
	public void setIndicatorState(IndicatorState s) {
		indicatorState = s;

	}

	public IndicatorState getIndicatorState() {
		return indicatorState;

	}

	@Override
	public void setReliefValveState(ReliefValveState s) {
		reliefValveState = s;

	}

	public ReliefValveState getReliefValveState() {
		return reliefValveState;
	}

}
