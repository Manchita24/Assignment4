using UnityEngine;
using Utilities; 

public class Paddle : MonoBehaviour
{
    private float moveInput;

    void Update()
    {
        
        if (GameBehavior.Instance.State == GameplayState.Play)
        {
            moveInput = Input.GetAxis("Horizontal");

            Vector3 newPosition = transform.position + Vector3.right * moveInput * GameBehavior.Instance.PaddleSpeed * Time.deltaTime;

            newPosition.x = Mathf.Clamp(newPosition.x, -GameBehavior.Instance.PaddleSpeed, GameBehavior.Instance.PaddleSpeed);

            transform.position = newPosition;
        }
    }
}


