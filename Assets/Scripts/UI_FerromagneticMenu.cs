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
        _magneticFieldIndicator.text = _selectable.MagneticFieldAtOneMeter.ToString();
    }

    public void IncreaseField()
    {
        _selectable.MagneticFieldAtOneMeter += 0.2f;
        _magneticFieldIndicator.text = _selectable.MagneticFieldAtOneMeter.ToString();
    }

    public void DecreaseField()
    {
        float newValue = _selectable.MagneticFieldAtOneMeter - 0.1f;
        if (newValue > 0)
        {
            _selectable.MagneticFieldAtOneMeter -= 1;
            _magneticFieldIndicator.text = _selectable.MagneticFieldAtOneMeter.ToString();
        }
    }

    public void ToggleFieldVisualization()
    {
        _selectable.ToggleFieldVisualization();
    }

    public void UpdateFieldVisualization()
    {
        _selectable.UpdateFieldVisualization();
    }
}
