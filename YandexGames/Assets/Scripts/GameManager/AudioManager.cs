using UnityEngine;

public class AudioManager : MonoBehaviour, IInilization
{
    private AudioSource _audioSource;

    public void Inilization( )
    {
        Initialize ();
    }

    public void Restart( )
    {
        // Ваш код для перезапуска
    }

    public void StartGame( )
    {
        // Ваш код для начала игры
    }

    private void Initialize( )
    {
        _audioSource = GetComponent<AudioSource> ();

        if ( _audioSource == null )
        {
            Debug.LogError ( "AudioSource not found on AudioManager!" );
        }
    }

    public void ToggleSound( )
    {
        if ( _audioSource != null )
        {
            // Меняем громкость звука от 0 до 1
            _audioSource.volume = ( _audioSource.volume == 0 ) ? 1 : 0;

            // Если вы хотите изменить визуальное представление звука (например, отобразить иконку в UI), вы можете добавить соответствующий код здесь.
        }
    }


}
