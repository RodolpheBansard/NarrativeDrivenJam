using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteBoum : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject tnt;

    public GameObject porteVfx;
    public GameObject tntVfx;

    public Transform porteVfxPos;

    private void Start()
    {
        sprite.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null && collision.GetComponent<PlayerController>().GetHasTnt())
        {
            sprite.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null && collision.GetComponent<PlayerController>().GetHasTnt())
        {
            sprite.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && sprite.isVisible && FindObjectOfType<PlayerController>().GetHasTnt())
        {
            
            StartCoroutine(ExplosionPorte());

            
        }
    }

    IEnumerator ExplosionPorte()
    {
        tnt.SetActive(true);

        yield return new WaitForSeconds(1);

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        sprite.enabled = false;

        Instantiate(tntVfx, tnt.transform);
        Instantiate(porteVfx, porteVfxPos);

        tnt.GetComponent<SpriteRenderer>().enabled = false;

        
    }
}
