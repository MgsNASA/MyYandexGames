using UnityEngine;

public class LoadingScreenPanel : MonoBehaviour
{
    // Метод для отображения загрузочного экрана
    public void ShowLoadingScreen( )
    {
        gameObject.SetActive ( true );
        // Добавьте здесь код для отображения дополнительных элементов загрузочного экрана (если необходимо)
    }

    // Метод для скрытия загрузочного экрана
    public void HideLoadingScreen( )
    {
        gameObject.SetActive ( false );
        // Добавьте здесь код для скрытия дополнительных элементов загрузочного экрана (если необходимо)
    }

    // Вызывается при завершении загрузки (вы можете добавить дополнительные параметры по вашему усмотрению)
    public void LoadingComplete( )
    {
        // Вызывайте этот метод, когда загрузка завершена, чтобы скрыть загрузочный экран
        HideLoadingScreen ();
    }
}
