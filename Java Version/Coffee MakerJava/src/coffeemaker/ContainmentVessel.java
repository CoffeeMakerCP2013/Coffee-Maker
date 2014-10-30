package coffeemaker;

public abstract class ContainmentVessel {
	private UserInterface ui;
	private HotWaterSource hws;
	protected Boolean isBrewing;
	protected Boolean isComplete;

	public ContainmentVessel() {
		isBrewing = false;
		isComplete = true;
	}

	public void init(UserInterface ui, HotWaterSource hws) {
		this.ui = ui;
		this.hws = hws;
	}

	public void start() {
		isBrewing = true;
		isComplete = false;
	}

	public void done() {
		isBrewing = false;
	}

	protected void declareComplete() {
		isComplete = true;
		ui.complete();
	}

	protected void containerAvailable() {
		hws.resume();
	}

	protected void containerUnavailable() {
		hws.pause();
	}

	public abstract Boolean isReady();
}