using UnityEngine;

public class Coin : MonoBehaviour
{
    // Событие, которое будет вызываться при сборе монеты
    public event System.Action OnCollected;

    private void OnTriggerEnter2D( Collider2D collision )
    {
        BallController ballController = collision.gameObject.GetComponent<BallController> ();

        // Check if the BallController component is not null
        if ( ballController != null )
        {
            ScoreManager.Instance.AddScore ( 50 );
            Destroy ( gameObject );

            // Вызываем событие о сборе монеты
            OnCollected?.Invoke ();
        }
    }
}
