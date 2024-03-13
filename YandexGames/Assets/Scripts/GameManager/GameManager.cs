using UnityEngine;

public class GameManager : MonoBehaviour, IInilization
{
    [SerializeField]
    private GameObject [ ] _scriptsObjects;

    public void Inilization( )
    {
        // �������� ����� Inilization ��� ���� �������� � _scriptsObjects
        foreach ( var scriptsObject in _scriptsObjects )
        {
            var scripts = scriptsObject.GetComponents<MonoBehaviour> ();
            foreach ( var script in scripts )
            {
                if ( script is IInilization )
                {
                    ( script as IInilization ).Inilization ();
                }
            }
        }
    }

    public void Restart( )
    {
        // �������� ����� Restart ��� ���� �������� � _scriptsObjects
        foreach ( var scriptsObject in _scriptsObjects )
        {
            var scripts = scriptsObject.GetComponents<MonoBehaviour> ();
            foreach ( var script in scripts )
            {
                if ( script is IInilization )
                {
                    ( script as IInilization ).Restart ();
                }
            }
        }
    }

    public void StartGame( )
    {
        // �������� ����� StartGame ��� ���� �������� � _scriptsObjects
        foreach ( var scriptsObject in _scriptsObjects )
        {
            var scripts = scriptsObject.GetComponents<MonoBehaviour> ();
            foreach ( var script in scripts )
            {
                if ( script is IInilization )
                {
                    ( script as IInilization ).StartGame ();
                }
            }
        }
    }
}
