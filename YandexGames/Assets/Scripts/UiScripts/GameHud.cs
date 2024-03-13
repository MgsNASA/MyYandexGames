using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameHud : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI _scoreText;
        [SerializeField] private Image [ ] images;
            
    public void ChangeScore( int i )
        {
        _scoreText.text = i.ToString();
        }


        
        public void ChangeHealth() 
        {
             images[ScoreManager.Instance.health].gameObject.SetActive(false);
        }

    public void ResetHealth( )
    {
        for ( int i = 0; i < images.Length; i++ )
        {
            images [ i ].gameObject.SetActive (true);
        }
    }

}
