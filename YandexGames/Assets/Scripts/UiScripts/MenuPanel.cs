using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    public Button soundButton;
    public Button startButton;
    public GameManager gameManager;
    public AudioManager audioManager;
    public Image soundImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    void Start( )
    {
        // Пример установки обработчиков событий для кнопок
     
        startButton.onClick.AddListener ( StartGame );
        soundButton.onClick.AddListener ( ToggleSound );
  
    }



    void ToggleSound( )
    {
        // Включаем или выключаем звук
        audioManager.ToggleSound ();

        // Обновляем изображение в зависимости от громкости звука
        soundImage.sprite = audioManager.GetComponent<AudioSource> ().volume > 0 ? soundOnSprite : soundOffSprite;

        // Ваш код для обработки настроек звука
        Debug.Log ( "Настройки звука" );
    }




    void StartGame( )
    {
        gameManager.StartGame ();
        // Ваш код для начала игры
        Debug.Log ( "Начать игру" );
    }


}
