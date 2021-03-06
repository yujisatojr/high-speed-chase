using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private GameManager gameManager;

    public int playerNum;
    public GameObject resultPane_1;
    public GameObject resultPane_2;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Player 1 collision
        if (playerNum == 1)
        {
            if (other.gameObject.CompareTag("Cone"))
            {
                EnvManager.Instance.health_1 -= 30;
                EnvManager.Instance.score_2 += 30;
            }
            if (other.gameObject.CompareTag("Goal"))
            {
                gameManager.isGameActive = false;
                resultPane_2.SetActive(true);

            }
        }
        // Player 2 collision
        else
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
                EnvManager.Instance.health_2 -= 30;
                EnvManager.Instance.score_1 += 30;
            }
            if (other.gameObject.CompareTag("Goal"))
            {
                gameManager.isGameActive = false;
                resultPane_1.SetActive(true);
            }
        }
    }
}
