package test;

import m4coffeemaker.CoffeeMaker;
import static org.junit.Assert.*;

import org.junit.Test;

import coffeemaker.CoffeeMakerAPI;
import model.CoffeeMachineStates.*;

class CoffeeMakerStub implements CoffeeMakerAPI {
	public boolean buttonPressed;
	public boolean lightOn;
	public boolean boilerOn;
	public boolean valveClosed;
	public boolean plateOn;
	public boolean boilerEmpty;
	public boolean potPresent;
	public boolean potNotEmpty;

	public CoffeeMakerStub() {
		buttonPressed = false;
		lightOn = false;
		boilerOn = false;
		valveClosed = true;
		plateOn = false;
		boilerEmpty = true;
		potPresent = true;
		potNotEmpty = false;
	}

	public WarmerPlateStatus getWarmerPlateStatus() {
		if (!potPresent)
			return WarmerPlateStatus.WARMER_EMPTY;
		else if (potNotEmpty)
			return WarmerPlateStatus.POT_NOT_EMPTY;
		else
			return WarmerPlateStatus.POT_EMPTY;
	}

	public BoilerStatus getBoilerStatus() {
		return boilerEmpty ? BoilerStatus.EMPTY : BoilerStatus.NOT_EMPTY;
	}

	public BrewButtonStatus getBrewButtonStatus() {
		if (buttonPressed) {
			buttonPressed = false;
			return BrewButtonStatus.PUSHED;
		} else {
			return BrewButtonStatus.NOT_PUSHED;
		}
	}

	public void setBoilerState(BoilerState boilerState) {
		boilerOn = boilerState == BoilerState.ON;
	}

	public void setWarmerState(WarmerState warmerState) {
		plateOn = warmerState == WarmerState.ON;
	}

	public void setIndicatorState(IndicatorState indicatorState) {
		lightOn = indicatorState == IndicatorState.ON;
	}

	public void setReliefValveState(ReliefValveState reliefValveState) {
		valveClosed = reliefValveState == ReliefValveState.CLOSED;
	}
}
