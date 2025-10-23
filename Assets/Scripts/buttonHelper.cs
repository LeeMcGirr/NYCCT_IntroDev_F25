using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonHelper : MonoBehaviour
{

    public UIPlayer myPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPlayer = UIPlayer._playerInstance;
        if(myPlayer == null)
        {
            Debug.LogError("No player instance found in scene");
        }
    }

    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    public void AddToInventory(string itemName)
    {
        //starting at index 0 and going to the end of the array, check each item in the array
        for (int i = 0; i < myPlayer.myInventory.Length; i++)
        {
            Debug.Log("Checking inventory slot " + i + " contains: " + myPlayer.myInventory[i]);
            if (myPlayer.myInventory[i] == "") //if we find a null (no value) spot, fill it
            {
                myPlayer.myInventory[i] = itemName;
                return;
            }
        }
    }
    
    public void UnlockButton(string myKey)
    {
        for (int i = 0; i < myPlayer.myInventory.Length; i++)
        {
            if (myPlayer.myInventory[i] == myKey)
            {
                this.gameObject.SetActive(false);
                return;
            }
        }
    }
}
