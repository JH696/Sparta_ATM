
[System.Serializable]
public class UserData
{   
    public string userName;
    public int balance;
    public int cash;

    public UserData(string userName, int balance, int cash)
    {
        this.userName = userName;
        this.balance = balance;
        this.cash = cash;
    }
}
