using UnityEngine;
using System.Collections;

public class GlobalStateManager : MonoBehaviour {

	public int LevelNumber;
	public float TimeLeft = 2f;
	public bool levelEnded = false;
	public float countDown = 32f;
	public bool textDisplayed = true;

	// Use this for initialization
	void Start () {
		
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(!textDisplayed){
			if(levelEnded && TimeLeft > 0f){
				TimeLeft -= Time.deltaTime;
				if(TimeLeft <= 0){
					TimeLeft = 5f;
					LevelNumber++;
					countDown = 32f;
					levelEnded = false;
					textDisplayed = true;
					//load next level
					Application.LoadLevel(LevelNumber + "");
				}
			}else{
				countDown -= Time.deltaTime;
				GameObject.Find("Timer").GetComponent<GUIText>().text = countDown.ToString("F3");
			}
		}
	}
}
