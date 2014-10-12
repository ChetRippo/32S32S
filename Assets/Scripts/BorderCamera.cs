using UnityEngine;
using System.Collections;

public class BorderCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform t = transform.parent;
		Camera c = transform.parent.camera;
		transform.position = new Vector3(t.position.x, t.position.y, t.position.z + 1.0f);
		transform.localScale = new Vector3(c.rect.width * c.orthographicSize/2f * Screen.width / 100.0f, c.rect.height * c.orthographicSize/2f * Screen.height / 100.0f, 1f);
	}
}
