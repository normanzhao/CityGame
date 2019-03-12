[System.Serializable]
public class stats {

	public static decimal totalFunds = attributes.funds;
	public static decimal biggestSpend = 0;
	public static float highestBuilding = 0;
	public static int amountOfBuildings = 0;
	public static decimal mostMoneyInTheBank = 0;
	public static decimal mostBuildingWorth = 0;
	public static int playTime = 0;
	public static int epoch = 0;


	public static void changeTotalFunds(decimal amount){
		totalFunds += amount;
	}

	public static void changeBiggestSpend(decimal amount){
		if(amount > biggestSpend){
			biggestSpend = amount;
		}
	}

	public static void changeHighestBuilding(float height){
		if(height > highestBuilding){
			highestBuilding = height;
		}
	}

	public static void changeAmountOfBuildings(){
		amountOfBuildings += 1;
	}

	public static void changeMostMoneyInTheBank(decimal amount){
		if(amount > mostMoneyInTheBank){
			mostMoneyInTheBank = amount;
		}
	}
	public static void changeMostBuildingWorth(decimal amount){
		if(amount > mostBuildingWorth){
			mostBuildingWorth = amount;
		}
	}

	public static void changePlayTime(){
		playTime += 1;
	}

	public static void changeEpoch(){
		epoch += 1;
	}


	public static string returnTotalFunds(){
		return common.formatMoney(totalFunds);
	}

	public static string returnBiggestSpend(){
		return common.formatMoney(biggestSpend);
	}

	public static string returnHighestBuilding(){
		return System.Math.Round(highestBuilding * 100).ToString();
	}

	public static string returnAmountOfBuildings(){
		return amountOfBuildings.ToString();
	}

	public static string returnMostMoneyInTheBank(){
		return common.formatMoney(mostMoneyInTheBank);
	}

	public static string returnMostBuildngWorth(){
		return common.formatMoney(mostBuildingWorth);
	}

	public static string returnPlayTime(){
		return common.formatTime(playTime);
	}

	public static string returnEpoch(){
		string[] epochNames = new string[]{"Stone Age", "Bronze Age", "Iron Age", "Medieval", "Machine Age", "Information Age", "Future Age"};
		return epochNames[epoch];
	}

}
