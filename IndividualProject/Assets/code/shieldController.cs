using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldController : MonoBehaviour
{
    private float sHealth = 100;

    private void Update()
    {
        if (PlayerPrefs.GetInt("difficulty") > 1 && sHealth < 100)
        {
            sHealth += 5;
        }

        if (sHealth > 100)
        {
            sHealth = 100;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet" && sHealth > 0)
        {
            sHealth -= col.gameObject.GetComponent<bMove>().damage;
            Destroy(col.gameObject);
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
