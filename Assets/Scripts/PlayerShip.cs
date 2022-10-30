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

    void OnFire(InputValue value)
    {
        hasFired = true;
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

        if (hasFired) {
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bolt, gameObject.transform.position, bolt.gameObject.transform.rotation);
                hasFired = false;
            }
        }
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.3f, 3.3f), Mathf.Clamp(transform.position.y, -3.3f, 3.3f), Mathf.Clamp(transform.position.z, -3.3f, 3.3f));
    }
}
