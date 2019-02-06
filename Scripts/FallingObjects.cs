using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour {
    public float fallDelay = 2.0f;

    void OnCollisionEnter(Collision collidedWithThis)
    {
        if (collidedWithThis.gameObject.name == "Player")
        {
            StartCoroutine(FallAfterDelay());
        }
    }

    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
