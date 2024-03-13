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
        // ��� ��� ��� �����������
    }

    public void StartGame( )
    {
        // ��� ��� ��� ������ ����
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
            // ������ ��������� ����� �� 0 �� 1
            _audioSource.volume = ( _audioSource.volume == 0 ) ? 1 : 0;

            // ���� �� ������ �������� ���������� ������������� ����� (��������, ���������� ������ � UI), �� ������ �������� ��������������� ��� �����.
        }
    }


}
