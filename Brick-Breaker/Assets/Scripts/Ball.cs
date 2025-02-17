using UnityEngine;

public class Ball : MonoBehaviour
{
  public float speed = 5f;
    private Vector2 direction = new Vector2(1, 1); 
    private float screenLeft = -7f;  
    private float screenRight = 7f;  
    private float screenTop = 4.0f;
   
    private float screenBottom = -4.0f;
   
    void Start()
    {  
        direction = new Vector2(1,1).normalized;
        ResetBall();
    }

   
    void Update()
    {
     
      
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

      
        if (transform.position.x <= screenLeft || transform.position.x >= screenRight)
        {
            direction.x *= -1; 
        }

        if (transform.position.y >= screenTop)
        {
            direction.y *= -1; 
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
}
