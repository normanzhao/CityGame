using UnityEngine;
using UnityEngine.UI;


public class upgradesUIManager : MonoBehaviour {

	public GameObject panel;

	public void showPanel(){
		panel.SetActive(true);
	}

	public void hidePanel(){
		panel.SetActive(false);
	}

}
