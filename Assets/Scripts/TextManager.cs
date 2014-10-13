using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {

	public int textIndex = 0;
	public string text = "";
	public int textArrayIndex = 0;
	public string[] textArray;
	public int dir = 1;

	// Use this for initialization
	void Start () {
		text = textArray[textArrayIndex];
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Manager").GetComponent<GlobalStateManager>().textDisplayed){
			transform.parent.Find("GUIGUI").rotation = new Quaternion(transform.parent.Find("GUIGUI").rotation.x, transform.parent.Find("GUIGUI").rotation.y, transform.parent.Find("GUIGUI").rotation.z + 0.8f * dir * Time.deltaTime, transform.parent.Find("GUIGUI").rotation.w);
			if(transform.parent.Find("GUIGUI").rotation.z > 0.2 && dir == 1){
				dir = -1;
			}else if(transform.parent.Find("GUIGUI").rotation.z < -0.2 && dir == -1){
				dir = 1;
			}
			if(textIndex < text.Length){
				textIndex++;
			}else if(Input.GetKeyDown("space")){
				textArrayIndex ++;
				textIndex = 0;
				if(textArrayIndex >= textArray.Length){
					GameObject.Find("Manager").GetComponent<GlobalStateManager>().textDisplayed = false;
				}else{
					text = textArray[textArrayIndex];
				}
			}
			//gui text
			GetComponent<GUIText>().text = FormatString(text.Substring(0, textIndex));	
		}
	}

	public string FormatString(string s) {
	  char[] delimitor = new char[1] {' '};
	  string[] words = s.Split(delimitor); //Split the string into seperate words
	  string result = "";
	  int runningLength = 0;
	  foreach (string word in words) {
	    if (runningLength + word.Length+1 <= 25) {
	      result += " " + word;
	      runningLength += word.Length+1;
	    }
	    else {
	      result += "\n" + word;
	      runningLength = word.Length;
	    }
	  }
	   
	  return result.Remove(0,1); //Remove the first space
	}
}
