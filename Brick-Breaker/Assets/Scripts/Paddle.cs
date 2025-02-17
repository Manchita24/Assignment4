using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 4.0f;
    public float YLimit = 3.5f;
    private float moveInput;
       void Start()
    {
        
       
    }

    
    void Update()
    {
      
        moveInput = Input.GetAxis("Horizontal");

     
        Vector3 newPosition = transform.position + Vector3.right * moveInput * speed * Time.deltaTime;

      
        newPosition.x = Mathf.Clamp(newPosition.x, -YLimit, YLimit);

      
        transform.position = newPosition;
        
    }
}

