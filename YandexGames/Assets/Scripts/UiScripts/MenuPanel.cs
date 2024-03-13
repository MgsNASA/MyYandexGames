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
        // ������ ��������� ������������ ������� ��� ������
     
        startButton.onClick.AddListener ( StartGame );
        soundButton.onClick.AddListener ( ToggleSound );
  
    }



    void ToggleSound( )
    {
        // �������� ��� ��������� ����
        audioManager.ToggleSound ();

        // ��������� ����������� � ����������� �� ��������� �����
        soundImage.sprite = audioManager.GetComponent<AudioSource> ().volume > 0 ? soundOnSprite : soundOffSprite;

        // ��� ��� ��� ��������� �������� �����
        Debug.Log ( "��������� �����" );
    }




    void StartGame( )
    {
        gameManager.StartGame ();
        // ��� ��� ��� ������ ����
        Debug.Log ( "������ ����" );
    }


}
