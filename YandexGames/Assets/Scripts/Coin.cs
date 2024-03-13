using UnityEngine;

public class Coin : MonoBehaviour
{
    // �������, ������� ����� ���������� ��� ����� ������
    public event System.Action OnCollected;

    private void OnTriggerEnter2D( Collider2D collision )
    {
        BallController ballController = collision.gameObject.GetComponent<BallController> ();

        // Check if the BallController component is not null
        if ( ballController != null )
        {
            ScoreManager.Instance.AddScore ( 50 );
            Destroy ( gameObject );

            // �������� ������� � ����� ������
            OnCollected?.Invoke ();
        }
    }
}
