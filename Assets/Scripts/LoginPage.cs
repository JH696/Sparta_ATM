using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class LoginPage : MonoBehaviour
{
    public TMP_InputField ID;
    public TMP_InputField Password;

    public GameObject SignUpPanel;
    public GameObject ErrorPanel;
    public TextMeshProUGUI ErrorText;

    public void OnLoginButton()
    {
        if (PlayerPrefs.HasKey(ID.text))
        {
            string savedPassword = PlayerPrefs.GetString($"{ID.text}/Password");
            if (savedPassword == Password.text)
            {
                Debug.Log("로그인 성공: " + ID.text);

                GameManager.instance.userData.userID = ID.text;
                GameManager.instance.userID = ID.text;

                GameManager.instance.userData.userName = PlayerPrefs.GetString($"{ID.text}/UserName");
                GameManager.instance.userData.balance = PlayerPrefs.GetInt($"{ID.text}/Balance", 50000);
                GameManager.instance.userData.cash = PlayerPrefs.GetInt($"{ID.text}/Cash", 100000);

                GameManager.instance.LoadUserData();

                GameManager.instance.LoadMainScene();
            }
            else
            {
                Debug.Log("비밀번호가 일치하지 않습니다.");
            }
        }
        else
        {
            ErrorPanel.SetActive(true);
            ErrorText.text = "존재하지 않는 아이디입니다.";
        }
    }


    public void OnSignUpButton()
    {
        SignUpPanel.SetActive(true);
    }

    public void PasswordBlind()
    {
        Password.contentType = TMP_InputField.ContentType.Password;
        Password.ForceLabelUpdate();
    }
}
