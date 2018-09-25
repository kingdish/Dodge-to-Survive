using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    void Update() {
        Vector3 tempPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(tempPos.x, tempPos.y, 0.0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("hit");
        if (collision.gameObject.tag == "enemy")
        {
            //Debug.Log("hit");
            Die();
        }
    }

    private void Die()
    {
        GameManager.isOver = true;
        Destroy(gameObject);
    }
}