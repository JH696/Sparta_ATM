using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UserData userData;
    public TextManager textManager;

    public string userID;
    [SerializeField] private string userName;
    [SerializeField] private int balance;
    [SerializeField] private int cash;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        textManager = GetComponent<TextManager>();  
    }

    public void Refresh()
    {
        if (textManager == null) return;

        textManager.UpdateText();
    }

    public void SaveUserData()
    {
        PlayerPrefs.SetInt($"{userData.userID}/Balance", userData.balance);
        PlayerPrefs.SetInt($"{userData.userID}/Cash", userData.cash);
        PlayerPrefs.Save();

        Debug.Log("유저명: " +userData.userName + ", 잔액: " + userData.balance + ", 현금: " + userData.cash);
    }

    public void LoadUserData()
    {
        userName = PlayerPrefs.GetString($"{userData.userID}/UserName");
        balance = PlayerPrefs.GetInt($"{userData.userID}/Balance");
        cash = PlayerPrefs.GetInt($"{userData.userID}/Cash");

        Debug.Log("유저명: " + userData.userName + ", 잔액: " + userData.balance + ", 현금: " + userData.cash);
        Refresh();
    }

    public void LoadLoginScene()
    {
        SaveUserData();
        SceneManager.LoadScene("LoginScene");
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
