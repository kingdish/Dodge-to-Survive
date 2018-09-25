using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    void Update() {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("hit");
        if (collision.gameObject.tag == "enemy") {
            Debug.Log("hit");
            die();
        }
    }

    private void die() {
        Destroy(gameObject);
    }
}