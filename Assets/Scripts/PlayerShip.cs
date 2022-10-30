using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    public bool hasFired;
    public float nextFire;
    public float fireRate;
    public GameObject bolt;

    private void Start()
    {
        hasFired = false;
        fireRate = 1.0f;
    }


    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        transform.rotation = Quaternion.Euler(0, 0, 45 * moveValue.x);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);

        if (hasFired && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bolt, transform.Find("head").gameObject.transform.position, bolt.gameObject.transform.rotation);
            hasFired = false;
        }
    }

    void OnFire(InputValue fireValue)
    {
        hasFired = true;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -1f, 5f));
    }
}
