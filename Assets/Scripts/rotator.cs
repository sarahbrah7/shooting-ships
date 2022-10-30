using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public float speed;
    private Vector3 direction;
    public Transform player;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        direction = transform.position - player.position;
        direction.y = 0;
        transform.Translate(-direction * speed * Time.deltaTime);

        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

}
