using UnityEngine;
using UnityEngine.UI;
public class TimerClock : MonoBehaviour
{
    public Image Clock;
    public PanelMove panel;


    public void UpdateClock(float fillAmount)
    {
        Clock.fillAmount = fillAmount;
    }

    public void EntryClock()
    {
        UpdateClock(1);
        panel.ToggleEnter();

    }
    public void ExitClock()
    {
        UpdateClock(1);
        panel.ToggleExit();
    }

}
