using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buildButton : MonoBehaviour {

	public gameController gameController;

	public Image backgroundImage;
	public Text costText;

	public Button button;

	private float timer;
	
	private int multiplier = 1;

	void Start(){
		button.interactable = false;
	}

	void FixedUpdate(){
		//disable button if it's gone past the point of being able to buy due to cost
		if(attributes.funds < (attributes.cost * multiplier)){
			button.interactable = false;
		}
		else{
			button.interactable = true;
		}
		//print current cost on button
		costText.text = "$" + common.formatMoneyNoDec((decimal)(attributes.cost * multiplier));
		if((multiplier < attributes.maxMultiplier) && (attributes.funds > (attributes.cost * multiplier))){
			timer += Time.deltaTime;
			byte BGcolor = (byte)(195 - (55 * (multiplier - 1) / attributes.maxMultiplier));
			backgroundImage.color = new Color32(BGcolor, BGcolor, BGcolor, 255);
			backgroundImage.fillAmount = (timer / attributes.tick);
			if(timer >= attributes.tick){
				multiplier += 1;
				timer = 0;
			}
		}
	}

	public void buildButtonOnClick(){
		//subtract money from funds
		decimal multipliedCost = attributes.cost * multiplier;
		if(attributes.funds >= multipliedCost){
			//stas keeping
			stats.changeBiggestSpend(multipliedCost);
			attributes.useMoney(multipliedCost);
			//spawn building
			gameController.spawnBuilding(multiplier);
			//reset multiplier and timer
			multiplier = 1;
			timer = 0;
			//reset BG background
			byte BGcolor = (byte)(195);
			backgroundImage.color = new Color32(BGcolor, BGcolor, BGcolor, 255);
			backgroundImage.fillAmount = 0;
		}
		attributes.cost = attributes.cost * (decimal)(attributes.costMultiplier);
	}
}
