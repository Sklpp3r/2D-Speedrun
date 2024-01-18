using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{

    private Rigidbody2D myRB;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            SceneManager.LoadScene(0);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
