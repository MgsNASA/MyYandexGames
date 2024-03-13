using UnityEngine;

public class ScoreManager : MonoBehaviour, IInilization
{
    private static ScoreManager instance;
    public GameHud gameHud;
    public GameManager gameManager;
    public static ScoreManager Instance
    {
        get; private set;
    }

    private void Awake( )
    {
        // Ensure only one instance of ScoreManager exists
        if ( Instance == null )
        {
            Instance = this;
        }
        else
        {
            Destroy ( gameObject );
        }



    }

    public int currentScore = 0;
    public int health = 3;
    public int maxScore;

    private void LoadMaxScore( )
    {
        // Загрузка максимального счета из сохраненных данных (например, PlayerPrefs)
        maxScore = PlayerPrefs.GetInt ( "MaxScore" , 0 );
    }

    private void SaveMaxScore( )
    {
        // Сохранение максимального счета в PlayerPrefs
        PlayerPrefs.SetInt ( "MaxScore" , maxScore );
        PlayerPrefs.Save (); // Обязательно сохраняем изменения
    }

    public void AddScore( int score )
    {
        // Добавление к текущему счету
        currentScore += score;
        gameHud.ChangeScore ( currentScore );

        // Обновляем максимальный счет, если текущий счет превышает его
        if ( currentScore > maxScore )
        {
            maxScore = currentScore;
            SaveMaxScore (); // Сохраняем максимальный счет
        }
    }


    public void TakeDamage( int damage )
    {
        health -= damage;

        if ( health <= 0 )
        {
            // Игра окончена, обработайте это по вашему усмотрению
            EndGame ();
        }
        gameHud.ChangeHealth ();
    }

    public int GetCurrentScore( )
    {
        return currentScore;
    }

    public void Inilization( )
    {
        // Убеждаемся, что у нас существует только один экземпляр ScoreManager
        if ( instance == null )
        {
            instance = this;
            DontDestroyOnLoad ( gameObject );
        }
        else
        {
            Destroy ( gameObject );
        }

        // Инициализация при старте игры
        currentScore = 0;
        health = 3;

        // Загрузка сохраненного максимального счета
        LoadMaxScore ();

        // Обновление UI
        gameHud.ChangeScore ( currentScore );
        gameHud.ResetHealth ();
    }

    public void Restart( )
    {
        currentScore = 0;
        health = 3;

        // Обновление UI после перезапуска
        gameHud.ChangeScore ( currentScore );
        gameHud.ResetHealth ();
    }

    public void StartGame( )
    {
        currentScore = 0;
        health = 3;

        // Обновление UI после перезапуска
        gameHud.ChangeScore ( currentScore );
        gameHud.ResetHealth ();
    }

    public void EndGame( )
    {
        UIManager.Instance.SetUIStateEndGamePanel ();
    }
    public bool IsNewMaxScore( int score )
    {
        return score > maxScore;
    }
    public void ResetMaxScore( )
    {
        maxScore = 0;
        ResetMaxScoreInPlayerPrefs ();
    }
    public void ResetMaxScoreInPlayerPrefs( )
    {
        PlayerPrefs.DeleteKey ( "MaxScore" );
    }

}
