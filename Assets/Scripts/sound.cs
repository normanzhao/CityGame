using UnityEngine;
using UnityEngine.UI;

public class sound : MonoBehaviour {

	private bool soundEnabled = false;
	private Image buttonImage;
	public Sprite soundOn;
	public Sprite soundOff;
	public AudioSource music;


	void Start(){
		buttonImage = GetComponent<Image>();
	}

	public void toggleSound(){
		soundEnabled = !soundEnabled;
		music.enabled = soundEnabled;
		if(soundEnabled){
			buttonImage.sprite = soundOn;
		}
		else{
			buttonImage.sprite = soundOff;
		}
	}
}
