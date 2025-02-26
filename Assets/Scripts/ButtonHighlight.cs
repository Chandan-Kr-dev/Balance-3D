using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHighlight : MonoBehaviour
{
    public Button button;

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
            button.image.color = Color.yellow; // Change to any color
        }
        else
        {
            button.image.color = Color.white; // Default color
        }
    }
}
