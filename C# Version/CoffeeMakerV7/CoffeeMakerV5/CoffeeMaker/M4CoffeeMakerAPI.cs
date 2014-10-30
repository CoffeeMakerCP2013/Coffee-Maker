using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeMaker;

namespace M4CoffeeMaker
{
    public class M4CoffeeMakerAPI : CoffeeMakerAPI
    {
        WarmerPlateStatus warmerPlateStatus;
        BoilerStatus boilerStatus;
        BrewButtonStatus brewButtonStatus;
        BoilerState boilerState;
        WarmerState warmerState;
        IndicatorState indicatorState;
        ReliefValveState reliefValveState;

        public M4CoffeeMakerAPI()
        {
            warmerPlateStatus = WarmerPlateStatus.WARMER_EMPTY;
            boilerStatus = BoilerStatus.EMPTY;
            brewButtonStatus = BrewButtonStatus.NOT_PUSHED;
            boilerState = BoilerState.OFF;
            warmerState = WarmerState.OFF;
            indicatorState = IndicatorState.OFF;
            reliefValveState = ReliefValveState.CLOSED;

        }

        public WarmerPlateStatus GetWarmerPlateStatus()
        {

            return warmerPlateStatus;
        }

        public void SetWarmerPlateStatus(WarmerPlateStatus s)
        {
            warmerPlateStatus = s;
        }

        public BoilerStatus GetBoilerStatus()
        {
            return boilerStatus;
        }

        public void SetBoilerStatus(BoilerStatus s)
        {
            boilerStatus = s;
        }

        public BrewButtonStatus GetBrewButtonStatus()
        {

            return brewButtonStatus;
        }

        public void SetBrewButtonStatus(BrewButtonStatus s)
        {
            brewButtonStatus = s;
        }

        public void SetBoilerState(BoilerState s)
        {
            boilerState = s;

        }

        public BoilerState GetBoilerState()
        {
            return boilerState;

        }
       
        public void SetWarmerState(WarmerState s)
        {
            warmerState = s;

        }
        public WarmerState GetWarmerState()
        {
            return warmerState;

        }

        public void SetIndicatorState(IndicatorState s)
        {
            indicatorState = s;

        }
        public IndicatorState GetIndicatorState()
        {
            return indicatorState;
        }

        public void SetReliefValveState(ReliefValveState s)
        {
            reliefValveState = s;

        }

        public ReliefValveState GetReliefValveState()
        {
            return reliefValveState;
        }
    }
}
