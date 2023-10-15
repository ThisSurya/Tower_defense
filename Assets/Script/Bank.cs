using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 200;
    [SerializeField] int currentBalance = 0;

    public int CurrentBalance {get { return currentBalance;}}

    private void Awake() {
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void WithDraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }
}
