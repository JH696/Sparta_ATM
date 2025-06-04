using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class LoginPage : MonoBehaviour
{
    public TMP_InputField ID;
    public TMP_InputField Password;

    public GameObject SignUpPanel;

    public void Start()
    {
        GameManager.instance.userData.userName = PlayerPrefs.GetString($"242wlsghks/UserName");
        Debug.Log("유저명: " + GameManager.instance.userData.userName);
    }

    public void OnLoginButton()
    {
        if (PlayerPrefs.HasKey(ID.text))
        {
            string savedPassword = PlayerPrefs.GetString($"242wlsghks/Password");
            if (savedPassword == Password.text)
            {
                Debug.Log("로그인 성공: " + ID.text);


                GameManager.instance.userData.userName = PlayerPrefs.GetString($"242wlsghks/UserName");
                GameManager.instance.userData.balance = PlayerPrefs.GetInt($"{ID.text}/Balance", 50000);
                GameManager.instance.userData.cash = PlayerPrefs.GetInt($"{ID.text}/Cash", 100000);

                GameManager.instance.LoadUserData();

                SceneManager.LoadScene("MainScene");
            }
            else
            {
                Debug.Log("비밀번호가 일치하지 않습니다.");
            }
        }
        else
        {
            Debug.Log("존재하지 않는 ID입니다.");
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
