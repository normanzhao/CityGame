using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour {
	//how long it takes in seconds to allow building
	public GameObject MainSphere;
	public GameObject Building;
	private float sphereRadius;

	public Text fundsText;
	public Text incomeText;

	private decimal prevFunds = attributes.funds;
	float timer = 0;


	void Start(){
		sphereRadius = MainSphere.GetComponent<RectTransform>().rect.width / 2;
		fundsText.text = "FUNDS: $" + common.formatMoney(attributes.funds);
		incomeText.text = "INCOME: $" + common.formatMoney(attributes.collectedIncome);
	}

	void FixedUpdate(){
		timer += Time.deltaTime;
		if(timer >= 1){
			fundsText.text = "FUNDS: $" + common.formatMoney(attributes.funds);
			incomeText.text = "INCOME: $" + common.formatMoney(attributes.collectedIncome);
			attributes.incomeToFunds();
			stats.changePlayTime();
			stats.changeMostMoneyInTheBank(attributes.funds);
			timer = 0;
		}
	}

	public void spawnBuilding(int multiplier){
		//spawn building
		//sizing
		float size = Random.Range(attributes.minSize, attributes.maxSize);
		float currentMinHeight = (attributes.maxHeight - size) * ((multiplier - 1) / attributes.maxMultiplier);
		float currentMaxHeight = size + ((attributes.maxHeight - size) * (multiplier / attributes.maxMultiplier));
		float height = Random.Range(currentMinHeight, currentMaxHeight);
		//positioning
		float sphereRadiusScaled = sphereRadius / 10;
		float x = 0, y = 0, z = 0;
		//keep generating positions if the z is NaN
		while(true){
			//random x and y based on coordinate plane
			//all transforms have to be scaled by a factor of 10 before being squared and calculated(reals cale vs world scale)
			x = Random.Range(-sphereRadiusScaled, sphereRadiusScaled);
			y = Random.Range(-sphereRadiusScaled, sphereRadiusScaled);
			//calculate z from x and y on he sphere, then random negative of positive
			int zSign = (Random.Range(0,2)*2-1);
			z = (zSign * Mathf.Sqrt((sphereRadiusScaled*sphereRadiusScaled)-(x*x)-(y*y))) + (zSign * (height / 2));
			if(!float.IsNaN(z)){
				break;
			}
		}
		print((x*x)+(y*y)+(z*z));
		GameObject building = Instantiate(Building) as GameObject;

		//make firs building always face the player
		if(stats.amountOfBuildings == 0){
			x = 0;
			y = 0;
			z = -sphereRadiusScaled - (height / 2);
		}

		//final position
		building.transform.position = new Vector3(x, y, z) * 10f;

		//final size
		building.transform.localScale += new Vector3(size, size, 0f);
		Vector3 currentScale = building.transform.localScale;
		building.GetComponent<building>().heightToRenderTo = height;

		//final rotation
		building.transform.LookAt(MainSphere.transform);
		//set parent
		building.transform.SetParent(MainSphere.transform);

		//stat keeping
		stats.changeAmountOfBuildings();
		stats.changeHighestBuilding(height);
		stats.changeMostBuildingWorth((decimal)height * attributes.worth);
	}

}
