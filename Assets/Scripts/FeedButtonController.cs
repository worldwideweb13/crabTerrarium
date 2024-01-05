using UnityEngine;
using UnityEngine.EventSystems;

public class FeedButtonController : MonoBehaviour
{    
    [SerializeField] private SliderController _lifeBase;

    public void OnClikFeed()
    {
        PlayerBase.GetInstance().lifePoint = 100;
        PlayerBase.GetInstance().lifePointElapsedTime = 0f;
        _lifeBase.UpdateUI(PlayerBase.GetInstance().lifePoint);
        EventSystem.current.SetSelectedGameObject(null);
    }

}
