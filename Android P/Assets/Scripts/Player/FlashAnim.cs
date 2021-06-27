using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashAnim : MonoBehaviour
{
    private float timer = 0.5f;
    private float delay;

    private void Update()
    {
        delay += Time.deltaTime;
        if(delay>timer) Destroy(gameObject);
    }
}
