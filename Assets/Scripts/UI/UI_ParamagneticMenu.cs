using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ParamagneticMenu : UI_SelectableMenu
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text massTextField;


    private ParamagneticMaterial paramagneticMaterial;


    public void Initialize(ParamagneticMaterial paramagneticMaterial)
    {
        base.Initialize(paramagneticMaterial);
        this.paramagneticMaterial = paramagneticMaterial;

        // This is done to set the text on GUI
        float newMass = paramagneticMaterial.MultiplyMass(1f);
        massTextField.text = newMass.ToString();
    }

    public void IncreaseMass()
    {
        float newMass = paramagneticMaterial.MultiplyMass(1.5f);
        massTextField.text = newMass.ToString();
    }

    public void DecreaseMass()
    {
        float newMass = paramagneticMaterial.MultiplyMass(0.7f);
        massTextField.text = newMass.ToString();
    }

}
