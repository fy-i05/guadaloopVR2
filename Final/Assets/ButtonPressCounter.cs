using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPressCounter : MonoBehaviour
{
    //How many presses required before this station is done
    [SerializeField] private int requiredPresses = 2;

    private int currentPressCount = 0;

    public StationController stationController;

    private XRBaseInteractable interactable;

    private void Awake()
    {
        // Get or reference the XR interactable
        interactable = GetComponent<XRBaseInteractable>();
        if (interactable == null)
        {
            Debug.LogError("XRBaseInteractable component not found on this button!");
        }
    }

    private void OnEnable()
    {
        if (interactable != null)
        {
            interactable.activated.AddListener(OnButtonPressed); 

        }
    }

    private void OnDisable()
    {
        if (interactable != null)
        {
            interactable.activated.RemoveListener(OnButtonPressed);
        }
    }

    private void OnButtonPressed(ActivateEventArgs args)
    {
        currentPressCount++;
        Debug.Log($"Button pressed! Current count: {currentPressCount}");

        if (currentPressCount >= requiredPresses && stationController != null)
        {
            // Notify station we've completed the requirement
            stationController.MarkStationComplete();
        }
    }
}
