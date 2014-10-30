package m4coffeemaker;

import model.CoffeeMachineStates.*;

import coffeemaker.CoffeeMakerAPI;
import coffeemaker.HotWaterSource;

public class M4HotWaterSource extends HotWaterSource implements Pollable {
	private CoffeeMakerAPI api;

	public M4HotWaterSource(CoffeeMakerAPI api) {
		this.api = api;
	}

	@Override
	public Boolean isReady() {
		BoilerStatus boilerStatus = api.getBoilerStatus();
		return boilerStatus == BoilerStatus.NOT_EMPTY;
	}

	@Override
	public void startBrewing() {
		api.setReliefValveState(ReliefValveState.CLOSED);
		api.setBoilerState(BoilerState.ON);
	}

	public void poll() {
		BoilerStatus boilerStatus = api.getBoilerStatus();
		if (isBrewing) {
			if (boilerStatus == BoilerStatus.EMPTY) {
				api.setBoilerState(BoilerState.OFF);
				api.setReliefValveState(ReliefValveState.CLOSED);
				declareDone();
			}
		}
	}

	@Override
	public void pause() {
		api.setBoilerState(BoilerState.OFF);
		api.setReliefValveState(ReliefValveState.OPEN);
	}

	@Override
	public void resume() {
		api.setBoilerState(BoilerState.ON);
		api.setReliefValveState(ReliefValveState.CLOSED);
	}
}