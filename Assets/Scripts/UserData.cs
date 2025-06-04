
[System.Serializable]
public class UserData
{   
    public string userID;
    public string userName;
    public int balance;
    public int cash;

    public UserData(string userID, string userName, int balance, int cash)
    {
        this.userID = userID;
        this.userName = userName;
        this.balance = balance;
        this.cash = cash;
    }
}
