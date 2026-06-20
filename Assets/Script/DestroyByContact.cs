using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();

        if (gameController == null)
            Debug.Log("Cannot find GameController script");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundry") || other.CompareTag("Enemy"))
            return;

        if (explosion != null)
            Instantiate(explosion, transform.position, transform.rotation);

        if (other.CompareTag("Player"))
        {
            if (playerExplosion != null)
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

            if (gameController != null)
                gameController.GameOver();
        }
        else
        {
            if (gameController != null)
                gameController.AddScore(scoreValue);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
