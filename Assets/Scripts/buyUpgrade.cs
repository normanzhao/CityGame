using UnityEngine;
using UnityEngine.UI;

public class buyUpgrade : MonoBehaviour {

	public Text upgradeLevel;
	public Text upgradePrice;

	public void showInfo(){
		double adjustedLevel = System.Math.Pow(attributes.upgradeMultipliers[gameObject.name], attributes.upgradeLevels[gameObject.name]);
		decimal price =  (decimal)System.Math.Pow(attributes.upgradePrices[gameObject.name],adjustedLevel);
		decimal roundedPrice = (decimal)System.Math.Floor(price / 5.0m) * 5;
		upgradeLevel.text = "LEVEL " + attributes.upgradeLevels[gameObject.name].ToString() + ":";
		upgradePrice.text = " $" + common.formatMoneyNoDec(roundedPrice);
	}

	public void hideInfo(){
		upgradeLevel.text = "";
		upgradePrice.text = "";
	}

	public void purchaseUpgrade(){
		double adjustedLevel = System.Math.Pow(attributes.upgradeMultipliers[gameObject.name], attributes.upgradeLevels[gameObject.name]);
		decimal price =  (decimal)System.Math.Pow(attributes.upgradePrices[gameObject.name],adjustedLevel);
		decimal roundedPrice = (decimal)System.Math.Floor(price / 5.0m) * 5;
		if(attributes.funds >= roundedPrice){
			switch(gameObject.name){
				case "costMultiplier":
					if(attributes.costMultiplier >= 1.05){
						attributes.costMultiplier -= 0.0125f;
					}
					else{
						gameObject.GetComponent<Button>().enabled = false;
					}
					break;
				case "worth":
					if(attributes.worth <= 1000000){
						attributes.worth *= 1.05m;
					}
					else{
						gameObject.GetComponent<Button>().enabled = false;
					}
					break;
				case "tick":
					if(attributes.tick >= 0.5){
						attributes.tick -= 0.25f;
					}
					else{
						gameObject.GetComponent<Button>().enabled = false;
					}
					break;
				case "maxMultiplier":
					if(attributes.maxMultiplier <= 60){
						attributes.maxMultiplier += 1;
					}
					else{
						gameObject.GetComponent<Button>().enabled = false;
					}
					break;
				case "timeToBuild":
					if(attributes.timeToBuild >= 3f){
						attributes.timeToBuild -= 0.25f;
					}
					else{
						gameObject.GetComponent<Button>().enabled = false;
					}
					break;
				case "maxSize":
					if(attributes.maxSize <= 2.5){
						attributes.maxSize += 0.05f;
					}
					else{
						gameObject.GetComponent<Button>().enabled = false;
					}
					break;
				case "maxHeight":
					if(attributes.maxHeight <= 1.25){
						attributes.maxHeight += 0.0125f;
					}
					else{
						gameObject.GetComponent<Button>().enabled = false;
					}
					break;
				case "epoch":
					if(attributes.epoch <= 7){
						attributes.epoch += 3; 
						attributes.costMultiplier += 3; 
						attributes.worth += 3; 
						attributes.tick += 3; 
						attributes.maxMultiplier += 3; 
						attributes.timeToBuild += 3; 
						attributes.maxSize += 3; 
						attributes.maxHeight += 3; 
					}
					else{
						gameObject.GetComponent<Button>().enabled = false;
					}
					break;
				default:
					break;
			}
			attributes.upgradeLevels[gameObject.name] += 1;
			attributes.funds -= roundedPrice;
			showInfo();
		}
	}
}
