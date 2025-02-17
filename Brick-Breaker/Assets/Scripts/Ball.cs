using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;

   
    void Start()
    {  
        direction = new Vector2(1,1).normalized;
        
    }

   
    void Update()
    {
     
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

      
        if (transform.position.x >= 8f || transform.position.x <= -8f)
        {
            direction.x *= -1; 
        }

        if (transform.position.y >= 4.5f) 
        {
            direction.y *= -1;
        }

         
    }
}
