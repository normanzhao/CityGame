using System.Collections;
using UnityEngine;

public class building : MonoBehaviour {

	public float heightToRenderTo;
	public decimal worth;
	private float currentHeight;
	private float scale;
	private float timer = 0f;

	public Material regular;



	// Use this for initialization
	void Start () {
		//the local scale is equal since the base of all the buildings are squares
		scale = gameObject.transform.localScale.x;
		//worth is the current multiplier
		worth = attributes.worth;
		StartCoroutine(expandBulding());
		StartCoroutine(generateMoney());
	}	

	IEnumerator expandBulding(){
		while(timer <= attributes.timeToBuild) 
		{
			timer += Time.deltaTime;
			gameObject.transform.localScale = new Vector3(scale, scale, ((heightToRenderTo - currentHeight) * (timer / attributes.timeToBuild)));
			if(gameObject.transform.localScale.z == heightToRenderTo){
				break;
			}
			yield return null;
		}
		GetComponent<MeshRenderer>().material = regular;
		GetComponent<MeshRenderer>().material.color = chooseColor();
		StopCoroutine(expandBulding());
	}

	//add money to funds at every tick
	IEnumerator generateMoney(){
		float timer = 0;
		while(true) 
		{
			timer += Time.deltaTime;
			if(timer >= 1){
				attributes.collectMoney((worth * (decimal)gameObject.transform.localScale.z));
				timer = 0;
			}
			yield return null;
		}
	}

	Color chooseColor(){
		int color = 0;
		switch(attributes.epoch){
			case 0 :
			default:
				color = randomInt(50,150);
				return new Color(color, color, color,255);
			case 1:
				color = randomInt(0,120);
				return new Color(175, 175, color,255);
			case 2:
				color = randomInt(150,200);
				return new Color(color, color, color,255);
			case 3:
				color = randomInt(0,50);
				return new Color(color, color, color,255);
			case 4:
				color = randomInt(0,125);
				return new Color(150, color, 255, 255);
			case 5:
				color = randomInt(0,255);
				return new Color(0, color, 255, 255);
			case 6:
				color = randomInt(200,255);
				return new Color(color, color, color, 255);
		}
	}

	int randomInt(int min, int max){
		return (int)Mathf.Floor(Random.Range(0,150));
	}
}
