using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UiMessenger : MonoBehaviour
{
    public float MessageExibitionTemp;
    [SerializeField]
    Text _messageTxt;
    [SerializeField]
    GameObject _messageUi;
    private void Start()
    {
        _messageUi.SetActive(false);
    }
    public void SendTxtUiMessage(string txt) 
    {
        StartCoroutine(WriteUiMessage(txt));
    }

    IEnumerator WriteUiMessage(string txt) 
    {
        _messageTxt.text = txt;
        _messageUi.SetActive(true);
        yield return new WaitForSeconds(MessageExibitionTemp);
        _messageUi.SetActive(false);
    }
}
