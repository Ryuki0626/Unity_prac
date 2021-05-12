using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {
    private Vector3 startPos;
    private bool stopGame;

    // Use this for initialization
    void Start () {
        startPos = transform.position;
        stopGame = true;
    }

    // Update is called once per frame
    void Update () {
        GameReset ();
        stratGame ();
    }

    void stratGame(){
        if (stopGame) {
            if (Input.GetKeyDown (KeyCode.Space)) {
                GetComponent<Rigidbody> ().velocity = new Vector3 (8f, 0f, 8f);
                stopGame = false;
            }

        }
    }

    void GameReset(){
        if (transform.position.z <= -3f　|| Input.GetKeyDown (KeyCode.LeftControl)) {
            stopGame = true;
            transform.position = startPos;
            GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
        }
    }

    void OnCollisionEnter(Collision other){
        if (other.collider.tag == "block") {
            Destroy (other.collider.gameObject);
        }
    }

}
