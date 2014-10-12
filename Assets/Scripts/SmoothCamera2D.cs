    using UnityEngine;
    using System.Collections;
     
    public class SmoothCamera2D : MonoBehaviour {
     
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
     
    // Update is called once per frame
    void Update ()
    {
        if (target)
        {
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta;
            if(transform.parent.Find("Player").localScale.x < 0){
                delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.6f, 0.4f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            }else{
                delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.4f, 0.4f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            }
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
     
    }
}