using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuBtns : MonoBehaviour
{
    public void OpenMarkerless()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenMarkerBased()
    {
        SceneManager.LoadScene(0); 
    }
}
