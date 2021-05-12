using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey (KeyCode.LeftArrow) && transform.position.x >= -3.3f) {
            transform.Translate (Time.deltaTime * -10f, 0, 0);
        }
        else if(Input.GetKey (KeyCode.RightArrow)&& transform.position.x <= 3.3f){
            transform.Translate (Time.deltaTime * 10f, 0, 0);
        }
    }
}
