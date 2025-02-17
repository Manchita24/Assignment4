using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 8f; // Paddle movement speed
    public float boundary = 7.5f; // Limit for movement
       void Start()
    {
        
    }

    
    void Update()
    {
       
        float moveInput = Input.GetAxis("Horizontal");
        
      
        float newX = transform.position.x + moveInput * speed * Time.deltaTime;

       
        newX = Mathf.Clamp(newX, -boundary, boundary);

      
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}

