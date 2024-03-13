using UnityEngine;

public class CreateObjects : MonoBehaviour, IInilization
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _holePrefab;
    [SerializeField] private GameObject _obstaclePrefab;

    private bool ballCreated = false;

    // Define arrays for coin, hole, and obstacle transforms
    [SerializeField] private Transform [ ] coinTransforms;
    [SerializeField] private Transform [ ] holeTransforms;
    [SerializeField] private Transform [ ] obstacleTransforms;

    // Probability of instantiating coins, holes, and obstacles (0 to 1)
    [SerializeField, Range ( 0f , 1f )] private float coinProbability = 0.5f;
    [SerializeField, Range ( 0f , 1f )] private float holeProbability = 0.3f;
    [SerializeField, Range ( 0f , 1f )] private float obstacleProbability = 0.4f;

    private int totalCoins = 0; // ���� ����� ��������� ���������� ��������� �����
    [SerializeField]private int remainingCoins = 0;
    public void Inilization( )
    {
        // ���������� ��� �������������
    }

    public void Restart( )
    {
        // ���������� ����, ����� ��� ��������� ������ StartGame ����� ������� �����
        ballCreated = false;

        // ������� ��� ���������� ���� � �������
        DestroyPreviousObjects ();

        CreateBallInCenter ();
        CreateCoinsAndHoles ();
        CreateObstacles ();
    }

    public void StartGame( )
    {
        // ���������� ��� ������ ����
        if ( !ballCreated )
        {
            ballCreated = true;

            // ����� �������� ��������� �����
            remainingCoins = 0;

            // ������� ������ � ���������� �� ����������
            remainingCoins = CreateCoinsAndHoles ();

            // ������� ��������� �������
            CreateBallInCenter ();
            CreateObstacles ();
        }
    }

    private int CreateCoinsAndHoles( )
    {
        remainingCoins = 0;

        // ������� ������ �� �������� �������� � ������������ coinProbability
        foreach ( Transform coinTransform in coinTransforms )
        {
            // Check coinProbability before instantiating a coin
            if ( Random.value < coinProbability )
            {
                GameObject coinObject = Instantiate ( _coinPrefab , coinTransform.position , coinTransform.rotation );
                Coin coin = coinObject.GetComponent<Coin> ();

                if ( coin != null )
                {
                    coin.OnCollected += OnCoinCollected;
                    remainingCoins++;
                }
            }
        }

        // ������� ���� �� �������� �������� � ������������ holeProbability
        foreach ( Transform holeTransform in holeTransforms )
        {
            if ( Random.value < holeProbability )
            {
                Instantiate ( _holePrefab , holeTransform.position , holeTransform.rotation );
            }
        }

        return remainingCoins;
    }




    void CreateObstacles( )
    {
        // ������� ����������� �� �������� �������� � ������������ obstacleProbability
        foreach ( Transform obstacleTransform in obstacleTransforms )
        {
            if ( Random.value < obstacleProbability )
            {
                Instantiate ( _obstaclePrefab , obstacleTransform.position , obstacleTransform.rotation );
            }
        }
    }

   public void CreateBallInCenter( )
    {
        // ������� ��������� ������ � ��������� ��� � ������ ��������� (0, 0, 0)
        Instantiate ( _ballPrefab , Vector3.zero , Quaternion.identity );
    }

    void DestroyPreviousObjects( )
    {
        // ������� ��� ���������� ���� � �������
        GameObject [ ] previousObjects = GameObject.FindGameObjectsWithTag ( "EditorOnly" );
        foreach ( GameObject obj in previousObjects )
        {
            Destroy ( obj );
        }
    }
    private void OnCoinCollected( )
    {
        remainingCoins--;

        if ( remainingCoins <= 0 )
        {
            // ���� ��� ������ �������, �������� ����� EndGame
            EndGame ();
        }
    }
    public void EndGame( )
    {
        ScoreManager.Instance.EndGame ();
    }
}
