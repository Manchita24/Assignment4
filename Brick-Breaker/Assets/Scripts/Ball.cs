using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction = new Vector2(1, 1);
    private float screenLeft = -7f;
    private float screenRight = 7f;
    private float screenTop = 4.0f;
    private float screenBottom = -4.0f;

    private Rigidbody2D _rb;
    private AudioSource _source;

    [SerializeField] private AudioClip _wallHitSound;
    [SerializeField] private AudioClip _paddleHitSound;
    [SerializeField] private AudioClip _brickHitSound;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();

        direction = new Vector2(1, 1).normalized;
        ResetBall();
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

       
        if (transform.position.x <= screenLeft || transform.position.x >= screenRight)
        {
            direction.x *= -1; 
            PlaySound(_wallHitSound);
        }

        if (transform.position.y >= screenTop)
        {
            direction.y *= -1; 
            PlaySound(_wallHitSound);
        }

        if (transform.position.y <= screenBottom)
        {
            ResetBall();
        }
    }

    void ResetBall()
    {
        transform.position = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector2 newDirection = Vector2.Reflect(direction, collision.contacts[0].normal);
            direction = newDirection.normalized;
            PlaySound(_paddleHitSound);
        }

        if (collision.gameObject.CompareTag("Brick"))
        {
            
            float xDistance = Mathf.Abs(transform.position.x - collision.transform.position.x);
            float yDistance = Mathf.Abs(transform.position.y - collision.transform.position.y);

            
            if (xDistance > yDistance)
            {
                direction.x *= -1; 
            }
            else
            {
                direction.y *= -1;
            }

            PlaySound(_brickHitSound);
            Destroy(collision.gameObject);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (_source != null && clip != null)
        {
            _source.PlayOneShot(clip);
        }
    }
}


