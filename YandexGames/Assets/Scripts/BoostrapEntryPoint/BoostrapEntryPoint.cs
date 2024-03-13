using System.Collections;
using UnityEngine;
public class BoostrapEntryPoint : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private LoadingScreenPanel _loadingScreenPanel;
    private IEnumerator Start( )
    {
        // ���������� ����������� �����
        yield return new WaitForSecondsRealtime ( 0);
        _loadingScreenPanel.HideLoadingScreen();
        // ��� ��� �������� ��� �������������
        Debug.Log ( "��������..." );
       // _gameManager.StartGame ();
        _gameManager.Inilization ();
        // ���������� ��������
        Debug.Log ( "������������� � �������� �������� ��������� !" );

    }
}

