using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class ATM : MonoBehaviour
{
    [SerializeField] private int moneyInput = 0;

    public GameObject DepositMenuButton;
    public GameObject WithdrawMenuButton;
    public GameObject RemitMenuButton;

    public GameObject DepositMenu;
    public GameObject WithdrawMenu;
    public GameObject RemitMenu;

    public GameObject ErrorPanel;
    public TextMeshProUGUI ErrorText;

    public TMP_InputField DepositInput;
    public TMP_InputField WithdrawInput;
    public TMP_InputField RemitTargetInput;
    public TMP_InputField RemitInput;

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

            if (RemitMenu.activeSelf)
            {
                moneyInput = int.Parse(RemitInput.text);
            }
        }
    }

    public void OnSwapButton(int amout)
    {
        DepositMenuButton.SetActive(false);
        WithdrawMenuButton.SetActive(false);
        RemitMenuButton.SetActive(false);

        switch (amout)
        {
            case 1:
                DepositMenu.SetActive(true);
                break;
            case 2:
                WithdrawMenu.SetActive(true);
                break;
            case 3:
                RemitMenu.SetActive(true);
                break;
        }

        moneyInput = 0;
        UpdateInputField();
    }

    public void DepositMoney()
    {
        if (GameManager.instance.userData.cash < moneyInput)
        {
            Error(1);
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
            Error(1);
            return;
        }

        GameManager.instance.userData.balance -= moneyInput;
        GameManager.instance.userData.cash += moneyInput;
        GameManager.instance.Refresh();
        GameManager.instance.SaveUserData();

        moneyInput = 0;
        UpdateInputField();
    }

    public void RemitMoney()
    {
        string key = $"{RemitTargetInput.text}/Balance";


        if (moneyInput > GameManager.instance.userData.balance)
        {
            Error(1);
            return;
        }
        else if (RemitTargetInput.text == "" || RemitInput.text == "")
        {
            Error(2);
            return;
        }
        else if (!PlayerPrefs.HasKey(key))
        {
            Error(3);
            return;
        }

        GameManager.instance.userData.balance -= moneyInput;
        int targetBanlance = PlayerPrefs.GetInt($"{RemitTargetInput.text}/Balance");
        PlayerPrefs.SetInt($"{RemitTargetInput.text}/Balance", targetBanlance + moneyInput);
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
        RemitMenu.SetActive(false);

        DepositMenuButton.SetActive(true);
        WithdrawMenuButton.SetActive(true);  
        RemitMenuButton.SetActive(true);
    }

    public void UpdateInputField()
    {
        DepositInput.text = moneyInput.ToString();
        WithdrawInput.text = moneyInput.ToString();
    }

    public void Error(int num)
    {
        ErrorPanel.SetActive(true);
        switch (num)
        {
            case 1:
                ErrorText.text = "잔액이 부족합니다.";
                break;
            case 2:
                ErrorText.text = "입력 정보를 확인해주세요.";
                break;
            default:
                ErrorText.text = "존재하지 않는 계좌입니다.";
                break;
        }

        moneyInput = 0;
        UpdateInputField();
    }
}
