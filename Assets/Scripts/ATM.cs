using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ATM : MonoBehaviour
{
    [SerializeField] private int moneyInput = 0;

    [Header("UI Elements")]
    public GameObject DepositScreenButton;
    public GameObject WithdrawScreenButton;

    public GameObject DepositMenu;
    public GameObject WithdrawMenu;

    public GameObject ErrorPanel;

    public TMP_InputField DepositInput;
    public TMP_InputField WithdrawInput;

    public void Update()
    {
        if (DepositInput.text != "" || WithdrawInput.text != "")
        {
            if (DepositMenu.activeSelf)
            {
                moneyInput = int.Parse(DepositInput.text);
            }

            if (WithdrawMenu.activeSelf)
            {
                moneyInput = int.Parse(WithdrawInput.text);
            }
        }
    } 

    public void OnSwapButton(int amout)
    {
        DepositScreenButton.SetActive(false);
        WithdrawScreenButton.SetActive(false);

        switch (amout)
        {
            case 1:
                DepositMenu.SetActive(true);
                break;
            case 2:
                WithdrawMenu.SetActive(true);
                break;
        }

        moneyInput =  0;
        UpdateInputField();
    }

    public void DepositMoney()
    {
        if (GameManager.instance.userData.cash < moneyInput)
        {
           ErrorPanel.SetActive(true);
           moneyInput = 0;
           UpdateInputField();
           return;
        }

        GameManager.instance.userData.balance += moneyInput;
        GameManager.instance.userData.cash -= moneyInput;
        GameManager.instance.Refresh();
        GameManager.instance.SaveUserData();

        moneyInput = 0;
        UpdateInputField();
    }

    public void WithdrawMoney()
    {
        if (GameManager.instance.userData.balance < moneyInput)
        {
            ErrorPanel.SetActive(true);
            moneyInput = 0;
            UpdateInputField();
            return;
        }

        GameManager.instance.userData.balance -= moneyInput;
        GameManager.instance.userData.cash += moneyInput;
        GameManager.instance.Refresh();
        GameManager.instance.SaveUserData();

        moneyInput = 0;
        UpdateInputField();
    }

    public void GetInputButton(int amount)
    {
        moneyInput += amount;
        UpdateInputField();
    }

    public void ReturnButton()
    {
        moneyInput = 0;
        UpdateInputField();

        DepositMenu.SetActive(false);
        WithdrawMenu.SetActive(false);

        DepositScreenButton.SetActive(true);
        WithdrawScreenButton.SetActive(true);  
    }

    public void UpdateInputField()
    {
        DepositInput.text = moneyInput.ToString();
        WithdrawInput.text = moneyInput.ToString();
    }
}
