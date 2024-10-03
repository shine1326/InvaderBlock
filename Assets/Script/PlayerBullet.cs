using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField, Header("弾の速度")]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        myRigidbody.velocity = transform.up * speed;
    }
}