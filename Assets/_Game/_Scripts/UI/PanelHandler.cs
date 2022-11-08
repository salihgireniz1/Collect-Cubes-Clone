using UnityEngine;

public class PanelHandler : IHandlePanel
{
    public GameObject CurrentPanel { get; private set; }

    public void SwitchPanel(GameObject newPanel = null)
    {
        if (CurrentPanel != null)
        {
            CurrentPanel.SetActive(false);
        }
        if (newPanel != null)
        {
            CurrentPanel = newPanel;
            CurrentPanel.SetActive(true);
        }
    }
}
