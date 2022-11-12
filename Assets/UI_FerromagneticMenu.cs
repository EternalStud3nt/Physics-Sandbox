using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_FerromagneticMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _magneticFieldIndicator;

    private Selectable_Ferromagnetic _selectable;

    public void Initialize(Selectable_Ferromagnetic selectable)
    {
        _selectable = selectable;
        _magneticFieldIndicator.text = _selectable.MagneticField.ToString();
    }

    public void IncreaseField()
    {
        _selectable.MagneticField += 1;
        _magneticFieldIndicator.text = _selectable.MagneticField.ToString();
    }

    public void DecreaseField()
    {
        _selectable.MagneticField -= 1;
        _magneticFieldIndicator.text = _selectable.MagneticField.ToString();
    }
}
