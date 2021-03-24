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

    UIController _uIcontroller;
    private void Start()
    {
        _uIcontroller = GameObject.FindGameObjectWithTag("UiController").GetComponent<UIController>();
    }
    public void RollDice()
    {
        _uIcontroller.ShowDiceRoller(this);
    }
    public void Roll() 
    {
        StartCoroutine(SortNumberRoutine());
    }
    IEnumerator SortNumberRoutine()
    {
        int sort = 1;
        for (int i = 0; i < 7; i++)
        {
            sort = UnityEngine.Random.Range(1, 7);
            _diceSortTxt.text = sort.ToString();
            yield return new WaitForSeconds(0.2f);
        }
        SortValue = sort;
        gameObject.SendMessage("DiceRollerFinish");
        _uIcontroller.HideDiceRoller();
    }
}
