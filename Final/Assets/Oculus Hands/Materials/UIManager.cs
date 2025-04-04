using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Tooltip("Drag the red warning panel here (the big red overlay).")]
    public GameObject warningPanel;

    private void Awake()
    {
        // Simple singleton pattern so we can call UIManager.Instance from anywhere
        if (Instance == null) 
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Show or hide the warning panel
    public void ShowWarningPanel(bool show)
    {
        if (warningPanel != null)
        {
            warningPanel.SetActive(show);
        }
    }
}
