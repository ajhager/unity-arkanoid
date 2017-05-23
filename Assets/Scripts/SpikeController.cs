using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("Ball").GetComponent<BallController>().Reset();
    }
}
