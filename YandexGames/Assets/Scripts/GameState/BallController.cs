using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float shotForce = 10f;
    public float rotationForce = 100f;
    public GameObject aim;

    private bool isMousePressed = false;
    private bool hasShot = false;
    private bool isMoving = false; // Флаг, указывающий, двигается ли мяч
    private SpriteRenderer aimSpriteRenderer;
    private Rigidbody2D rb;
    private CreateObjects createObjects; // Ссылка на объект CreateObjects

    private void Start( )
    {
        aimSpriteRenderer = aim.GetComponent<SpriteRenderer> ();
        aimSpriteRenderer.color = new Color ( 1f , 1f , 1f , 0f );
        rb = GetComponent<Rigidbody2D> ();
        createObjects = FindObjectOfType<CreateObjects> (); // Находим объект CreateObjects
    }

    private void Update( )
    {
        if ( Input.GetMouseButtonDown ( 0 ) && !hasShot )
        {
            isMousePressed = true;
            aimSpriteRenderer.color = new Color ( 1f , 1f , 1f , 1f );
            hasShot = true;
        }

        if ( isMousePressed && Input.GetMouseButtonUp ( 0 ) )
        {
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint ( Input.mousePosition );
            targetPosition.z = 0f;
            Vector2 shotDirection = ( ( Vector2 ) targetPosition - ( Vector2 ) transform.position ).normalized;

            rb.AddForce ( shotDirection * shotForce , ForceMode2D.Impulse );
            rb.AddTorque ( rotationForce , ForceMode2D.Impulse );

            isMousePressed = false;
            aimSpriteRenderer.color = new Color ( 1f , 1f , 1f , 0f );
            isMoving = true; // Устанавливаем флаг, что мяч начал двигаться
            StartCoroutine ( CheckIfStopped () ); // Запускаем корутину для проверки, остановился ли мяч
        }

        if ( isMousePressed )
        {
            Vector3 lookDirection = ( Vector2 ) Camera.main.ScreenToWorldPoint ( Input.mousePosition ) - ( Vector2 ) transform.position;
            float angle = Mathf.Atan2 ( lookDirection.y , lookDirection.x ) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler ( 0f , 0f , angle );
        }
    }

    private IEnumerator CheckIfStopped( )
    {
        yield return new WaitUntil ( ( ) => rb.velocity.magnitude < 0.1f );
        StartCoroutine ( TakeDamageAfterDelay ( 0 ) );
    }

    private IEnumerator TakeDamageAfterDelay( float delay )
    {
        yield return new WaitForSeconds ( delay );
        ScoreManager.Instance.TakeDamage ( 1 );
        createObjects.CreateBallInCenter (); // Используем ссылку на createObjects для создания нового шарика
        DestroyBall ();
    }

    private void DestroyBall( )
    {
        Destroy ( gameObject );
    }
}
