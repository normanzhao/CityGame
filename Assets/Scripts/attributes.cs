using System.Collections.Generic;
[System.Serializable]
public class attributes {

	public static decimal funds = 500;
	public static decimal collectedIncome = 0;
	public static decimal cost = 10;
	public static float costMultiplier = 1.75f;
	public static decimal worth = 2.5m;
    public static float tick = 7.5f;
	//maximum amount of counts for buildings
	public static float maxMultiplier = 6;
	public static float timeToBuild = 15f;
	//absolute max is 2.5f
	public static float maxSize = 0.10f;
	public static float minSize = maxSize - (maxSize / 5);

	//absolute max is 1.25
	//min height is the current max size
	public static float maxHeight = 0.15f;
	public static int epoch = 0;

	public static Dictionary<string, int> upgradeLevels = new Dictionary<string, int>() {
		{"costMultiplier", 1},
		{"worth", 1},
		{"tick", 1},
		{"maxMultiplier", 1},
		{"timeToBuild", 1},
		{"maxSize", 1},
		{"maxHeight", 1},
		{"epoch", 1},
	};

	public static Dictionary<string, double> upgradeMultipliers = new Dictionary<string, double>() {
		{"costMultiplier", 1.15},
		{"worth", 1.075},
		{"tick", 1.05},
		{"maxMultiplier", 1.15},
		{"timeToBuild", 1.05},
		{"maxSize", 1.15},
		{"maxHeight", 1.25},
		{"epoch", 1.35},
	};

	public static Dictionary<string, int> upgradePrices = new Dictionary<string, int>() {
		{"costMultiplier", 35},
		{"worth", 25},
		{"tick", 20},
		{"maxMultiplier", 30},
		{"timeToBuild", 15},
		{"maxSize", 50},
		{"maxHeight", 50},
		{"epoch", 1000},
	};

	public static void useMoney(decimal amount){
		funds -= amount;
	}

	public static void collectMoney(decimal amount){
		collectedIncome += amount;
	}

	public static void incomeToFunds(){
		//stats keeping
		stats.changeTotalFunds(collectedIncome);

		funds += collectedIncome;
		collectedIncome = 0;
	}

}
