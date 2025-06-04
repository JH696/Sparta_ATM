using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void OnResetButton()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("모든 PlayerPrefs가 초기화되었습니다."); 
    }
}
