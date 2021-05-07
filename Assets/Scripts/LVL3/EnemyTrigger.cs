using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.gameObject.GetComponent<PlayerController>() != null || collision.gameObject.GetComponent<PlayerController>() != null)
        {
            SceneManager.LoadScene(2);
        }
    }
}
