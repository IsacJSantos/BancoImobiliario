using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Dice : MonoBehaviour
{
    public event EventHandler IsFinish;
    public int SortValue { get; private set; }
    [SerializeField]
    int _sides;
    [SerializeField]
    Text _diceSortTxt;

    public void RollDice() 
    {
        StartCoroutine(SortNumber());
    }

    IEnumerator SortNumber() 
    {
        int sort = 1;
        for (int i = 0; i < 7; i++)
        {
             sort = UnityEngine.Random.Range(1, 7);
            _diceSortTxt.text = sort.ToString();
            yield return new WaitForSeconds(0.2f);
        }
        SortValue = sort;
        IsFinish?.Invoke(this, EventArgs.Empty);
    }
}
