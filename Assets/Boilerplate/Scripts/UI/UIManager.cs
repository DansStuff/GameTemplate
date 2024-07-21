using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour {

    public UIDocument pauseMenuUIDoc;


    public void ShowPauseMenu() {

        Debug.Log("Show pause menu");
        pauseMenuUIDoc.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    public void HidePauseMenu() {
        Debug.Log("Hide pause menu");
        pauseMenuUIDoc.rootVisualElement.style.display = DisplayStyle.None;
    }

}
