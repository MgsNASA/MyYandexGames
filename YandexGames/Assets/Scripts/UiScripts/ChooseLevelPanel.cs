using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelPanel : MonoBehaviour
{
    public Button levelButton1;
    public Button levelButton2;
    public Button levelButton3;
    public Button levelButton4;
    public Image checkmark;
    public GameState gameState;

    // Добавим переменные для хранения обычного цвета и цвета при выборе
    private Color normalColor = Color.white;
    private Color selectedColor = Color.black;

    void Start( )
    {
        // Устанавливаем обработчики событий для каждой кнопки
        levelButton1.onClick.AddListener ( ( ) => SelectLevel ( 1 , levelButton1 ) );
        levelButton2.onClick.AddListener ( ( ) => SelectLevel ( 2 , levelButton2 ) );
        levelButton3.onClick.AddListener ( ( ) => SelectLevel ( 3 , levelButton3 ) );
        levelButton4.onClick.AddListener ( ( ) => SelectLevel ( 4 , levelButton4 ) );

        // Изначально скрываем галочку
        checkmark.gameObject.SetActive ( false );
        SelectLevel ( 3 , levelButton3 ); // Выбираем уровень 3 изначально
    }

    void SelectLevel( int levelNumber , Button selectedButton )
    {
        // Перемещаем галочку к выбранному уровню
        RectTransform selectedButtonRectTransform = selectedButton.GetComponent<RectTransform> ();

        if ( selectedButtonRectTransform != null )
        {
            // Устанавливаем позицию галочки в правый верхний угол выбранной кнопки
            checkmark.rectTransform.SetParent ( selectedButtonRectTransform , false );
            checkmark.rectTransform.anchorMin = new Vector2 ( 1f , 1f );
            checkmark.rectTransform.anchorMax = new Vector2 ( 1f , 1f );
            checkmark.rectTransform.pivot = new Vector2 ( 1f , 1f );
            checkmark.rectTransform.anchoredPosition = Vector2.zero;

            // Показываем галочку
            checkmark.gameObject.SetActive ( true );
        }

        // Ваш код для обработки выбора уровня
        Debug.Log ( "Выбран уровень: " + levelNumber );

        // Изменяем цвет кнопок в зависимости от их выбора
        levelButton1.image.color = ( levelNumber == 1 ) ? selectedColor : normalColor;
        levelButton2.image.color = ( levelNumber == 2 ) ? selectedColor : normalColor;
        levelButton3.image.color = ( levelNumber == 3 ) ? selectedColor : normalColor;
        levelButton4.image.color = ( levelNumber == 4 ) ? selectedColor : normalColor;
       
    }
}
