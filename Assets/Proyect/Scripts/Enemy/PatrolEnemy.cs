using UnityEngine;

public class PattrolEnemy : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 3f;
    public int damage = 10;

    private Transform objetivo;

    void Start()
    {
        objetivo = puntoB;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            objetivo.position,
            velocidad * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, objetivo.position) < 0.1f)
        {
            objetivo = (objetivo == puntoA) ? puntoB : puntoA;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth =
                collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}