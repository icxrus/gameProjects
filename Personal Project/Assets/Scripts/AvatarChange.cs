using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarChange : MonoBehaviour
{
    public GameObject[] avatars; //Drag and drop in the inspector


    //Attach to the onClick method of the button. Drag the avatar GameObject that you want
    //the button click to activate into the blank spot for the onClick once the method is hooked in.
    public void ActivateAvatar(GameObject targetAvatar)
    {
        foreach (GameObject avatar in avatars)
        {
            avatar.SetActive(false);
        }

        targetAvatar.SetActive(true);
    }
}
