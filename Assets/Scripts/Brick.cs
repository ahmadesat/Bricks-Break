using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    [SerializeField] Level level;
    [SerializeField] GameObject impactVFX;

    public void Start()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            level.incrementBricks();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            DestroyObject(gameObject);
            TriggerCollisionVFX();
            level.destroyBricks();
        }
       

    }

    private void TriggerCollisionVFX()
    {
        if (tag == "Breakable")
        {
            GameObject collide = Instantiate(impactVFX, transform.position, transform.rotation);
            Destroy(collide, 2f);
        }
    }
}
