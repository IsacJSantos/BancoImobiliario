using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Dice : MonoBehaviour
{
    [SerializeField] int _sides;

    Text _diceSortTxt;
    UIController _uIcontroller;

    private void Awake()
    {
        Events.OnRollDice += RollDice;
    }
    private void Start()
    {
        _uIcontroller = GameObject.FindGameObjectWithTag("UiController").GetComponent<UIController>();
        _diceSortTxt = GameObject.FindGameObjectWithTag("DiceSortTxt").GetComponent<Text>();
    }

    private void OnDestroy()
    {
        Events.OnRollDice -= RollDice;
    }

    void RollDice()
    {
        _uIcontroller.ShowDiceRoller(this);
    }
    public void Roll()
    {
        StartCoroutine(SortNumberRoutine());
    }
    IEnumerator SortNumberRoutine()
    {
        _uIcontroller.HideDiceRoller();
        int sort = 1;
        for (int i = 0; i < 7; i++)
        {
            sort = UnityEngine.Random.Range(1, _sides + 1);
            _diceSortTxt.text = sort.ToString();
            yield return new WaitForSeconds(0.2f);
        }
        Events.OnDiceFinish?.Invoke(sort);
    }
}
