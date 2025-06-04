using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignUpPage : MonoBehaviour
{
    public TMP_InputField ID;
    public TMP_InputField UserName;
    public TMP_InputField Password;
    public TMP_InputField ConfirmPassword;

    public TextMeshProUGUI NavigationText;

    public GameObject ErrorPanel;

    public void OnSignUpButton()
    {
        if (ID.text == "")
        {
            NavigationText.text = "ID를 확인해주세요.";
            return;
        }
        else if (UserName.text == "")
        {
            NavigationText.text = "이름을 확인해주세요.";
            return;
        }
        else if (Password.text == "")
        {
            NavigationText.text = "비밀번호를 확인해주세요.";
            return;
        }
        else if (ConfirmPassword.text == "")
        {
            NavigationText.text = "비밀번호 확인을 입력해주세요.";
            return;
        }

        if (Password.text != ConfirmPassword.text)
        {
            ErrorPanel.SetActive(true);
            NavigationText.text = "비밀번호가 일치하지 않습니다.";
            return;
        }

        PlayerPrefs.SetString($"{ID.text}", ID.text);
        PlayerPrefs.SetString($"{ID.text}/UserName", UserName.text);
        PlayerPrefs.SetString($"{ID.text}/Password", Password.text);

        NavigationText.text = $"회원가입을 환영합니다, {UserName.text}님";
        Debug.Log("ID: " + PlayerPrefs.GetString($"{ID.text}"));
        Debug.Log("UserName: " + PlayerPrefs.GetString($"{ID.text}/UserName"));
        Debug.Log("Password: " + PlayerPrefs.GetString($"{ID.text}/Password"));

        PlayerPrefs.Save();
    }

    public void OnCancelButton()
    {
        this.gameObject.SetActive(false);
    }

    public void PasswordBlind(int number)
    {
        switch (number)
        {
            case 1:
                // Password
                Password.contentType = TMP_InputField.ContentType.Password;
                Password.ForceLabelUpdate();
                break;
            case 2:
                // Confirm Password
                ConfirmPassword.contentType = TMP_InputField.ContentType.Password;
                ConfirmPassword.ForceLabelUpdate();
                break;
        }
    }
}
