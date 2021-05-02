using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public List<GameObject> lasers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            foreach(GameObject laser in lasers)
            {
                laser.SetActive(!laser.activeInHierarchy);                
            }
        }
    }
}
