using UnityEngine;

public class Kaboom : MonoBehaviour
{
    protected Grabbing localGrabbing;
    public float ExplosionForce;
    public float ExplosionRadius;
    public AudioSource explosionNoise;
    public ParticleSystem explosionSystem;

    // Start is called before the first frame update
    void Start()
    {
        localGrabbing = GetComponent<Grabbing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (localGrabbing.Pressed)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Explode(ExplosionForce, ExplosionRadius);
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Explode(ExplosionForce, ExplosionRadius);
        }
    }

    public void Explode(float force, float radius)
    {
        if (GetComponent<SpriteRenderer>() != null)
        {
            explosionNoise.Play();
            explosionSystem.Play();
            Vector3 explosionPos = transform.position;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
            foreach (Collider2D hit in colliders)
            {
                Vector2 direction = hit.transform.position - transform.position;
                if (hit.GetComponent<Rigidbody2D>() != null)
                {
                    hit.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
                }
                /*
                if (hit.GetComponent<Kaboom>() != null)
                {
                    hit.GetComponent<Kaboom>().Explode(hit.GetComponent<Kaboom>().ExplosionForce, hit.GetComponent<Kaboom>().ExplosionRadius);
                }
                */
            }
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<Grabbing>());
            Destroy(transform.GetChild(0).gameObject);
            Destroy(explosionSystem.gameObject, 5.0f);
            Destroy(explosionNoise.gameObject, 16.118f);
            Destroy(transform.parent.gameObject, 16.118f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
