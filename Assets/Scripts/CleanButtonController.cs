using UnityEngine;
using UnityEngine.EventSystems;

public class CleanButtonController : MonoBehaviour
{    
    [SerializeField] private SliderController _cleanBase;
    
    public void OnClikClean()
    {
        PlayerBase.GetInstance().aquariumPoint = 100;
        PlayerBase.GetInstance().aquariumPointElapsedTime = 0f;
        _cleanBase.UpdateUI(PlayerBase.GetInstance().aquariumPoint);
        EventSystem.current.SetSelectedGameObject(null);
    }

}
