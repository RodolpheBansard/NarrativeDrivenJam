using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public List<Sprite> sprites;

    private void Start()
    {
        Destroy(gameObject, 5);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count - 1)];
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BossDragon>())
        {
            print("dragon touché");
            collision.gameObject.GetComponent<BossDragon>().takeHit(1);
        }
        if (collision.gameObject.GetComponent<BossRobot>())
        {
            print("robot touché");
            collision.gameObject.GetComponent<BossRobot>().takeHit(1);
        }
        if (collision.gameObject.GetComponent<Mechadragon>())
        {
            print("mechadragon touché");
            collision.gameObject.GetComponent<Mechadragon>().takeHit(1);
        }
    }
}
