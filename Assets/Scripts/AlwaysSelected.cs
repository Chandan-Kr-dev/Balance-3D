using UnityEngine;
using UnityEngine.EventSystems;


public class AlwaysSelected : MonoBehaviour
{
    public GameObject defaultButton; // Assign your first button in the Inspector

    void Update()
    {
        // If no button is selected, reselect the default button
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(defaultButton);
        }
    }
}
