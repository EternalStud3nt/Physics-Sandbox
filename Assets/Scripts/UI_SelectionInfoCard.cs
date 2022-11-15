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
            //todo: Delete:     _paramagneticMenuUI.gameObject.SetActive(false);
            //todo: Delete:     _neutralMenuUI.gameObject.SetActive(false);
                break;

            //todo: Delete: case Selectable.MaterialType.Paramagnetic:
            //todo: Delete:     _paramagneticMenuUI.gameObject.SetActive(true);
            //todo: Delete:     _ferromagneticMenuUI.gameObject.SetActive(false);
            //todo: Delete:     _neutralMenuUI.gameObject.SetActive(false);
            //todo: Delete:     break;
            //todo: Delete: 
            //todo: Delete: case Selectable.MaterialType.Neutral:
            //todo: Delete:     _neutralMenuUI.gameObject.SetActive(true);
            //todo: Delete:     _paramagneticMenuUI.gameObject.SetActive(false);
            //todo: Delete:     _ferromagneticMenuUI.gameObject.SetActive(false);
            //todo: Delete:     break;
        }
    }
}
