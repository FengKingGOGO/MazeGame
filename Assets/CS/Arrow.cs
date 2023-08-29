using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.SliderNum(player.hpline, -10);
        }
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<Collider>());//É¾³ý¸ÕÌå£¬Åö
        transform.parent = collision.transform;
    }
}
