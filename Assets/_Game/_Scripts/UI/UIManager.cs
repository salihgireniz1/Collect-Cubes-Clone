using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private GameObject failPanel;
    
    [SerializeField]
    private GameObject timerPanel;

    [SerializeField]
    private GameObject mainMenuPanel;

    [SerializeField]
    private GameObject aiGameCompletePanel;

    [SerializeField]
    private GameObject timerGameCompletePanel;

    [SerializeField]
    private GameObject normalGameCompletePanel;

    IHandlePanel panelRespond;
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        panelRespond = new PanelHandler();
    }

    private void OnEnable()
    {
        GameManager.OnGameStateChange += HandlePanels;
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChange -= HandlePanels;
    }
    #endregion

    #region Methods

    public void HandlePanels(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                panelRespond.SwitchPanel(mainMenuPanel);
                break;
            case GameState.Normal:
                panelRespond.SwitchPanel();
                break;
            case GameState.WithTimer:
                panelRespond.SwitchPanel(timerPanel);
                break;
            case GameState.AICompetative:
                panelRespond.SwitchPanel(timerPanel);
                break;
            case GameState.ImageWon:
                panelRespond.SwitchPanel(normalGameCompletePanel);
                break;
            case GameState.TimerWon:
                panelRespond.SwitchPanel(timerGameCompletePanel);
                break;
            case GameState.AIWon:
                panelRespond.SwitchPanel(aiGameCompletePanel);
                break;
            case GameState.Fail:
                panelRespond.SwitchPanel(failPanel);
                break;
            default:
                break;
        }
    }
    #endregion
}
