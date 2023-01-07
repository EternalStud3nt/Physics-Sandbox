using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsBar : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Image simulationTimeImage;
    [SerializeField] private Sprite playButtonSprite;
    [SerializeField] private Sprite stopSimulationSprite;
    [SerializeField] private TMP_Text simulationButtonTextField;

    private void Start()
    {
        ToggleBar(false);
        Time.timeScale = 1;
        simulationTimeImage.sprite = stopSimulationSprite;
        simulationButtonTextField.text = "Stop\nSimulation";
    }

    public void ToggleBar(bool value)
    {
        animator.SetBool("open", value);
        animator.SetTrigger("valueChanged");
        if (value)
        {

        }
        else
        {

        }
    }

    public void ToggleSimulationTime()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            simulationTimeImage.sprite = playButtonSprite;
            simulationButtonTextField.text = "Start\nSimulation";

        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            simulationTimeImage.sprite = stopSimulationSprite;
            simulationButtonTextField.text = "Stop\nSimulation";
        }
    }
}
