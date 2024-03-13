using UnityEngine;

public class GameManager : MonoBehaviour, IInilization
{
    [SerializeField]
    private GameObject [ ] _scriptsObjects;

    public void Inilization( )
    {
        // Вызываем метод Inilization для всех скриптов в _scriptsObjects
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
        // Вызываем метод Restart для всех скриптов в _scriptsObjects
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
        // Вызываем метод StartGame для всех скриптов в _scriptsObjects
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
