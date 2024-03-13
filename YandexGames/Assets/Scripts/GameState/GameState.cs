using UnityEngine;

public class GameState : MonoBehaviour, IInilization
{
    private static GameState instance;
    [SerializeField]private CreateObjects createObjects;
    public static GameState Instance
    {
        get
        {
            if ( instance == null )
            {
                // Создаем объект GameState, если его еще нет
                GameObject gameStateObject = new GameObject ( "GameState" );
                instance = gameStateObject.AddComponent<GameState> ();
            }
            return instance;
        }
    }

    public void Inilization( )
    {
        
    }

    public void Restart( )
    {
        
    }

    public void StartGame( )
    {
        
    }
}
