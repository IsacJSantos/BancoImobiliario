using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject _buyPlaceUi;
    private void Start()
    {
        _buyPlaceUi.SetActive(false);
    }
    public void ShowShopMenu() 
    {
        _buyPlaceUi.SetActive(true);
    }
    public void HideShopMenu() 
    {
        _buyPlaceUi.SetActive(false);
    }
}
