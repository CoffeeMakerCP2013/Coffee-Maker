package model;

public class CoffeeMachineStates {
	public enum BoilerStatus {
		EMPTY, NOT_EMPTY
	};
	
	public enum BoilerState {
		ON, OFF
	};
	
	public enum BrewButtonStatus {
		PUSHED, NOT_PUSHED
	};
	
	public enum IndicatorState {
		ON, OFF
	};
	
	public enum ReliefValveState {
		OPEN, CLOSED
	};

	public enum WarmerPlateStatus {
		WARMER_EMPTY, POT_EMPTY, POT_NOT_EMPTY
	};
	
	public enum WarmerState {
		ON, OFF
	};
	
	
	
	
}
