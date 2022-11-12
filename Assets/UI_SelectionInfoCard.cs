using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SelectionInfoCard : MonoBehaviour
{
    [SerializeField] private UI_FerromagneticMenu _ferromagneticMenuUI;
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
                _ferromagneticMenuUI.Initialize(_selectedObject.gameObject.GetComponent<Selectable_Ferromagnetic>());
                _paramagneticMenuUI.gameObject.SetActive(false);
                _neutralMenuUI.gameObject.SetActive(false);
                break;

            case Selectable.MaterialType.Paramagnetic:
                _paramagneticMenuUI.gameObject.SetActive(true);
                _ferromagneticMenuUI.gameObject.SetActive(false);
                _neutralMenuUI.gameObject.SetActive(false);
                break;

            case Selectable.MaterialType.Neutral:
                _neutralMenuUI.gameObject.SetActive(true);
                _paramagneticMenuUI.gameObject.SetActive(false);
                _ferromagneticMenuUI.gameObject.SetActive(false);
                break;
        }
    }
}
