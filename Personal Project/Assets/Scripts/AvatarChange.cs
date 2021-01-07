using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarChange : MonoBehaviour
{
    public GameObject[] avatars; //Drag and drop in the inspector

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
    }


    //Attach to the onClick method of the button. Drag the avatar GameObject that you want
    //the button click to activate into the blank spot for the onClick once the method is hooked in.
    public void ActivateAvatar(GameObject targetAvatar)
    {
        Scene scene = SceneManager.GetActiveScene();

        foreach (GameObject avatar in avatars)
        {
            avatar.SetActive(false);
        }


        if (scene.name == "Game")
        { 
            targetAvatar.SetActive(true); 
        }
    }

}
