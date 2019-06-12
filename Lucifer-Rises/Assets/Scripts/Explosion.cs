using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float deleteTime;

    private void FixedUpdate()
    {
        Destroy(gameObject, deleteTime);
    }
}
