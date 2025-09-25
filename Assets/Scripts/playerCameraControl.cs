using UnityEngine;

public class playerCameraControl : MonoBehaviour
{

    public GameObject myPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3
                    (myPlayer.transform.position.x,
                    myPlayer.transform.position.y,
                    transform.position.z);
    }
}
