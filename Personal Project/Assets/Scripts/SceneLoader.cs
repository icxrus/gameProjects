using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SceneLoader : MonoBehaviour
{

    public Button menu;

    public void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        Button btn = menu.GetComponent<Button>();
        btn.onClick.AddListener(ToMenu);

        // if button is pressed return to menu
        void ToMenu() 
        {
            SceneManager.LoadScene("Menu");
        }
        
    }


}
