using UnityEngine;
using UnityEngine.UI;

public class statsUIManager : MonoBehaviour {

	public GameObject panel;
	public Text totalFundsLabel;
	public Text biggestSpendLabel;
	public Text highestBuildingLabel;
	public Text amountOfBuildingsLabel;
	public Text mostMoneyInTheBankLabel;
	public Text mostBuildingWorthLabel;
	public Text playTimeLabel;
	public Text epochLabel;


	void LateUpdate(){
		totalFundsLabel.text = "TOTAL FUNDS:\n$" + stats.returnTotalFunds();
		biggestSpendLabel.text = "MOST EXPENSIVE PURCHASE:\n$" + stats.returnBiggestSpend();
		highestBuildingLabel.text = "HIGHEST BUILDING:\n" + stats.returnHighestBuilding() + " FEET";
		amountOfBuildingsLabel.text = "AMOUNT OF BUILDINGS:\n" + stats.returnAmountOfBuildings();
		mostMoneyInTheBankLabel.text = "MOST MONEY IN BANK:\n$" + stats.returnMostMoneyInTheBank();
		mostBuildingWorthLabel.text = "MOST EXPENSIVE BUILDING:\n$" + stats.returnMostBuildngWorth();
		playTimeLabel.text = "PLAY TMES:\n" + stats.returnPlayTime();
		epochLabel.text = "EPOCH:\n" + stats.returnEpoch();
	}

	public void showPanel(){
		panel.SetActive(true);
	}

	public void hidePanel(){
		panel.SetActive(false);
	}
}
