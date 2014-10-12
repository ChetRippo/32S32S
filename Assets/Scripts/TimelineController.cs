using UnityEngine;
using System.Collections;

public class TimelineController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int camsPerRow = (int)Mathf.Ceil(Mathf.Sqrt(Camera.allCameras.Length));
		int maxRows = (int)Mathf.Ceil((float)Camera.allCameras.Length / (float)camsPerRow);
		//Debug.Log(maxRows);
		//Debug.Log(camsPerRow);
		int currentRow = 0;
		for(int i = 0; i < Camera.allCameras.Length; i++){
			if(i > 0 && i % camsPerRow == 0){
				currentRow++;
			}
			Camera.allCameras[i].rect = new Rect(1.0f / camsPerRow * (i % camsPerRow), (1.0f - 1.0f / maxRows ) - (1.0f / maxRows * currentRow), 1.0f / camsPerRow, 1.0f / maxRows);
			//Debug.Log(Camera.allCameras[i].rect.x + " " + Camera.allCameras[i].rect.y + " " + Camera.allCameras[i].rect.width + " " + Camera.allCameras[i].rect.height);
		}
		if(maxRows * camsPerRow > Camera.allCameras.Length){
			Camera.allCameras[Camera.allCameras.Length-1].rect = new Rect(1.0f / camsPerRow * ((Camera.allCameras.Length-1) % camsPerRow), (1.0f - 1.0f / maxRows ) - (1.0f / maxRows * currentRow), 1.0f / (Camera.allCameras.Length % camsPerRow), 1.0f / maxRows);
			//Debug.Log(Camera.allCameras[Camera.allCameras.Length-1].rect.x + " " + Camera.allCameras[Camera.allCameras.Length-1].rect.y + " " + Camera.allCameras[Camera.allCameras.Length-1].rect.width + " " + Camera.allCameras[Camera.allCameras.Length-1].rect.height);
		}

		GameObject.Find("Timer").GetComponent<GUIText>().pixelOffset = new Vector2(0f, -400f + 8 * (maxRows) * 10);
		GameObject.Find("Timer").GetComponent<GUIText>().fontSize = 48 - (4*maxRows);
		GameObject.Find("VictoryText").GetComponent<GUIText>().pixelOffset = new Vector2(0f, -100f - 8 * maxRows * 10);
		GameObject.Find("VictoryText").GetComponent<GUIText>().fontSize = 72 - 8*maxRows;
	}
}
