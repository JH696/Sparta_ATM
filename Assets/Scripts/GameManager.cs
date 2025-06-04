using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextManager textManager;
    public UserData userData;

    [SerializeField] private int balance = 50000;
    [SerializeField] private int cash = 100000;

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
        if (textManager == null)
        {
            return;
        }

        textManager.UpdateText();
    }

    public void SaveUserData()
    {
        PlayerPrefs.SetString("유저명", userData.userName);
        PlayerPrefs.SetInt("잔액", userData.balance);
        PlayerPrefs.SetInt("현금", userData.cash);
        PlayerPrefs.Save();

        Debug.Log("유저명: " +userData.userName + ", 잔액: " + userData.balance + ", 현금: " + userData.cash);
    }

    public void LoadUserData()
    {
        Debug.Log("유저명: " + userData.userName + ", 잔액: " + userData.balance + ", 현금: " + userData.cash);
        Refresh();
    }

    public void UnSaveUserData()
    {
        PlayerPrefs.DeleteKey("유저명");
        PlayerPrefs.DeleteKey("잔액");
        PlayerPrefs.DeleteKey("현금");
        PlayerPrefs.Save();
    }   
}
