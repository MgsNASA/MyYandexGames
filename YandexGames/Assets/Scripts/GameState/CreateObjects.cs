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

    private int totalCoins = 0; // Сюда будем сохранять количество созданных монет
    [SerializeField]private int remainingCoins = 0;
    public void Inilization( )
    {
        // Вызывается при инициализации
    }

    public void Restart( )
    {
        // Сбрасываем флаг, чтобы при следующем вызове StartGame снова создать шарик
        ballCreated = false;

        // Удаляем все предыдущие мячи и объекты
        DestroyPreviousObjects ();

        CreateBallInCenter ();
        CreateCoinsAndHoles ();
        CreateObstacles ();
    }

    public void StartGame( )
    {
        // Вызывается при начале игры
        if ( !ballCreated )
        {
            ballCreated = true;

            // Сброс счетчика собранных монет
            remainingCoins = 0;

            // Создаем монеты и запоминаем их количество
            remainingCoins = CreateCoinsAndHoles ();

            // Создаем остальные объекты
            CreateBallInCenter ();
            CreateObstacles ();
        }
    }

    private int CreateCoinsAndHoles( )
    {
        remainingCoins = 0;

        // Создаем монеты на заданных позициях с вероятностью coinProbability
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

        // Создаем дыры на заданных позициях с вероятностью holeProbability
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
        // Создаем препятствия на заданных позициях с вероятностью obstacleProbability
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
        // Создаем экземпляр шарика и размещаем его в центре координат (0, 0, 0)
        Instantiate ( _ballPrefab , Vector3.zero , Quaternion.identity );
    }

    void DestroyPreviousObjects( )
    {
        // Удаляем все предыдущие мячи и объекты
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
            // Если все монеты собраны, вызываем метод EndGame
            EndGame ();
        }
    }
    public void EndGame( )
    {
        ScoreManager.Instance.EndGame ();
    }
}
