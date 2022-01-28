using SDA.Architecture;
using SDA.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SettingsState : BaseState
{
    private SettingsView settingsView;
    private UnityAction transitionToMenuState;

    public SettingsState(UnityAction transitionToMenuState, SettingsView settingsView)
    {
        this.settingsView = settingsView;
        this.transitionToMenuState = transitionToMenuState;
    }

    public override void InitState()
    {
        Debug.Log("init settings");

        if (settingsView != null)
            settingsView.ShowView();

        settingsView.BackButton.onClick.AddListener(transitionToMenuState);
    }

    public override void UpdateState()
    {
    }

    public override void DestroyState()
    {
        if (settingsView != null)
            settingsView.HideView();

        settingsView.BackButton.onClick.RemoveAllListeners();
    }
}
