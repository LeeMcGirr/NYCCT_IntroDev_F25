using TMPro;
using UnityEngine;

public class UIPlayer : MonoBehaviour
{
    public static UIPlayer _playerInstance;
    public string playerName;
    public GameObject nameField;
    public TMP_InputField inputField;

    public string[] myInventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (_playerInstance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _playerInstance = this;
        }
        
        DontDestroyOnLoad(this.gameObject);
        if(nameField != null) inputField = nameField.GetComponent<TMP_InputField>();
    }
    void Update()
    {
        
    }
    public void changeName()
    {
        playerName = inputField.text;
        Debug.Log("name Change called");
    }
}
