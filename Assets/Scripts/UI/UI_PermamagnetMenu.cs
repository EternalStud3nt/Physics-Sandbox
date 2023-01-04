using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PermamagnetMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text massIndicator;
    [SerializeField] private TMP_Text objectName;
    [SerializeField] private TMP_Text objectDescription;
    [SerializeField] private TMP_Text _magneticFieldIndicator;

    private PermaMagnet permamagnet;

    public void Initialize(PermaMagnet permamagnet)
    {
        this.permamagnet = permamagnet;
        _magneticFieldIndicator.text = Math.Round(permamagnet.MagneticFieldAtOneMeter, 2).ToString();
        _magneticFieldIndicator.text = this.permamagnet.MagneticFieldAtOneMeter.ToString();
        SetObjectName(permamagnet.ObjectName);
        SetObjectDescription(permamagnet.ObjectDescrition);
        massIndicator.text = Math.Round(permamagnet.Mass, 2).ToString();
    }

    public void IncreaseMass()
    {
        permamagnet.ChangeMass(0.5f);
        massIndicator.text = Math.Round(permamagnet.Mass, 2).ToString();
    }

    public void DecreaseMass()
    {
        permamagnet.ChangeMass(-0.5f);
        massIndicator.text = Math.Round(permamagnet.Mass, 2).ToString();
    }

    public void IncreaseField()
    {
        permamagnet.MagneticFieldAtOneMeter += 0.2f;
        _magneticFieldIndicator.text = Math.Round(permamagnet.MagneticFieldAtOneMeter, 2).ToString();
    }

    public void DecreaseField()
    {
        float newValue = permamagnet.MagneticFieldAtOneMeter - 0.2f;
        if (newValue > 0)
        {
            permamagnet.MagneticFieldAtOneMeter -= 0.2f;
            _magneticFieldIndicator.text = Math.Round(permamagnet.MagneticFieldAtOneMeter, 2).ToString();
        }
    }

    public void ToggleFieldVisualization()
    {
        permamagnet.ToggleFieldVisualization();
    }

    public void UpdateFieldVisualization()
    {
        permamagnet.UpdateFieldVisualization();
    }

    public void SetObjectName(string name)
    {
        objectName.text = name;
    }

    public void SetObjectDescription(string desc)
    {
        objectDescription.text = desc;
    }

}
