using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	private bool inAir = false;
	public Sprite idleSprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameObject.Find("Manager").GetComponent<GlobalStateManager>().textDisplayed && transform.parent.Find("Main Camera").GetComponent<Camera>().enabled){
			if(Input.GetKey("left")){
				transform.Translate(-speed * Time.deltaTime, 0, 0);
				if(transform.localScale.x >= 0){
					transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
                GetComponent<Animator>().Play("walk");
			}else if (Input.GetKey("right")){
	            transform.Translate(speed * Time.deltaTime, 0, 0);
	            if(transform.localScale.x <= 0){
					transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
                GetComponent<Animator>().Play("walk");
	        }else{
	        	GetComponent<Animator>().Play("Idle");
	        }
	        if(!inAir && Input.GetKeyDown("up")){
	        	GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
	        	inAir = true;
	        }
	    }
	}

	void OnCollisionEnter2D(Collision2D collider){
        if (collider.gameObject.name == "Floor") {
            inAir = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.name == "LINE") {
           	GameObject.Find("VictoryText").GetComponent<GUIText>().enabled = true;
           	GameObject.Find("Manager").GetComponent<GlobalStateManager>().TimeLeft = 2.0f;
           	GameObject.Find("Manager").GetComponent<GlobalStateManager>().levelEnded = true;
        }else if(collider.gameObject.name == "door"){
        	//enable connected camera
        	foreach(GameObject g in GameObject.FindGameObjectsWithTag(collider.gameObject.tag)){
        		if(g.name != "door"){
        			g.GetComponent<Camera>().enabled = true;
        		}
        	}
        }
    }
}
