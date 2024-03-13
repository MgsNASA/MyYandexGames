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

    // ������� ���������� ��� �������� �������� ����� � ����� ��� ������
    private Color normalColor = Color.white;
    private Color selectedColor = Color.black;

    void Start( )
    {
        // ������������� ����������� ������� ��� ������ ������
        levelButton1.onClick.AddListener ( ( ) => SelectLevel ( 1 , levelButton1 ) );
        levelButton2.onClick.AddListener ( ( ) => SelectLevel ( 2 , levelButton2 ) );
        levelButton3.onClick.AddListener ( ( ) => SelectLevel ( 3 , levelButton3 ) );
        levelButton4.onClick.AddListener ( ( ) => SelectLevel ( 4 , levelButton4 ) );

        // ���������� �������� �������
        checkmark.gameObject.SetActive ( false );
        SelectLevel ( 3 , levelButton3 ); // �������� ������� 3 ����������
    }

    void SelectLevel( int levelNumber , Button selectedButton )
    {
        // ���������� ������� � ���������� ������
        RectTransform selectedButtonRectTransform = selectedButton.GetComponent<RectTransform> ();

        if ( selectedButtonRectTransform != null )
        {
            // ������������� ������� ������� � ������ ������� ���� ��������� ������
            checkmark.rectTransform.SetParent ( selectedButtonRectTransform , false );
            checkmark.rectTransform.anchorMin = new Vector2 ( 1f , 1f );
            checkmark.rectTransform.anchorMax = new Vector2 ( 1f , 1f );
            checkmark.rectTransform.pivot = new Vector2 ( 1f , 1f );
            checkmark.rectTransform.anchoredPosition = Vector2.zero;

            // ���������� �������
            checkmark.gameObject.SetActive ( true );
        }

        // ��� ��� ��� ��������� ������ ������
        Debug.Log ( "������ �������: " + levelNumber );

        // �������� ���� ������ � ����������� �� �� ������
        levelButton1.image.color = ( levelNumber == 1 ) ? selectedColor : normalColor;
        levelButton2.image.color = ( levelNumber == 2 ) ? selectedColor : normalColor;
        levelButton3.image.color = ( levelNumber == 3 ) ? selectedColor : normalColor;
        levelButton4.image.color = ( levelNumber == 4 ) ? selectedColor : normalColor;
       
    }
}
