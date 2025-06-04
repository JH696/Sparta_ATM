using UnityEngine;

public class BackButton : MonoBehaviour
{ 
    public void OnBackButton()
    {
        GameManager.instance.LoadLoginScene();
    }
}
