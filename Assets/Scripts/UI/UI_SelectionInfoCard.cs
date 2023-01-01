using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SelectionInfoCard : MonoBehaviour
{
    [SerializeField] private Transform contentSlot;
    [SerializeField] private UI_PermamagnetMenu _ferromagneticMenuUI;
    [SerializeField] private UI_ParamagneticMenu _paramagneticMenuUI;
    [SerializeField] private UI_NeutralMenu _neutralMenuUI;

    private Selectable _selectedObject;

    public void Open(Selectable selectable)
    { 
        _selectedObject = selectable;
        BuildCardMenu();
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void BuildCardMenu()
    {
        switch (_selectedObject.Type)
        {
            case Selectable.MaterialType.Ferromagnetic:
                _ferromagneticMenuUI.gameObject.SetActive(true);
                _ferromagneticMenuUI.Initialize(_selectedObject.gameObject.GetComponent<PermaMagnet>());
                break;
        }
    }
}
