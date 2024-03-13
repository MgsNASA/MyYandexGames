using UnityEngine;

public class Hole : MonoBehaviour
{
    private void Awake( )
    {
        
    }
    private void OnTriggerEnter2D( Collider2D collision )
    {
        BallController ballController = collision.gameObject.GetComponent<BallController> ();

        // Check if the BallController component is not null
        if ( ballController != null )
        {
            ScoreManager.Instance.TakeDamage ( 1 );
            Destroy ( ballController.gameObject );
            CreateObjects createObjects = FindAnyObjectByType<CreateObjects>();
            createObjects.CreateBallInCenter ();
        }
    }
}
