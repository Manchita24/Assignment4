using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    [SerializeField] private int points = 10; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) 
        {
            GameBehavior.Instance.IncreaseScore(points); 
            Destroy(gameObject); 
        }
    }
}


    
