using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI userNameText;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI cashText;

    public void UpdateText()
    {
        if (userNameText == null || balanceText == null || cashText == null)
        {
            return;
        }

        userNameText.text = GameManager.instance.userData.userName;
        balanceText.text = GameManager.instance.userData.balance.ToString("N0");
        cashText.text = GameManager.instance.userData.cash.ToString("N0");
    }
}
