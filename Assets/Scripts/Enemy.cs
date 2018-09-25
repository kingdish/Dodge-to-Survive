using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float maxSpeed = 10f;
    public float minSpeed = 5f;
    public int offsetRange = 5;

    private GameObject target;
    private Vector2 targetPos;
    private Vector2 dir;
    private float speed;
    private Rigidbody2D rd;

    public void Start() {
        rd = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        targetPos = target.transform.position;
        speed = Random.Range(minSpeed, maxSpeed);
        Respawn();
        Vector2 offset = new Vector2(Random.Range(-offsetRange, offsetRange),
                                     Random.Range(-offsetRange, offsetRange));
        dir = targetPos - (Vector2)transform.position + offset;
    }

    public void Respawn() {
        //https://answers.unity.com/questions/230190/how-to-get-the-width-and-height-of-a-orthographic.html
        Camera cam = Camera.main;
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;
        float halfDiagonal = Mathf.Sqrt(Mathf.Pow(halfHeight, 2) + Mathf.Pow(halfWidth, 2));
        Vector2 randDelta = Random.insideUnitCircle.normalized * 2 * halfDiagonal;
        transform.position = target.transform.position + (Vector3)randDelta;
    }

    void Update() {
        rd.velocity = speed * dir.normalized;
        Camera cam = Camera.main;
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;
        if (transform.position.x < -3 * halfWidth
            || transform.position.x > 5 * halfWidth
            || transform.position.y < - 3 * halfHeight
            || transform.position.y > 5 * halfHeight) {
            Destroy(gameObject);
        }
    }
}
