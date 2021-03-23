using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{  
    public int SortValue { get; private set; }
    public bool IsFinish { get; private set; }
    [SerializeField]
    int _sides;
    [SerializeField]
    Text _diceSortTxt;

  
    public void RollDice() 
    {
        IsFinish = false;
        StartCoroutine(SortNumber());
    }

    IEnumerator SortNumber() 
    {
        int sort = 1;
        for (int i = 0; i < 7; i++)
        {
             sort = Random.Range(1, 7);
            _diceSortTxt.text = sort.ToString();
            yield return new WaitForSeconds(0.2f);
        }
        SortValue = sort;
        IsFinish = true;
    }
}
