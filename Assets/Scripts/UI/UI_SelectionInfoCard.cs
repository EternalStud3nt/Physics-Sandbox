using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SelectionInfoCard : MonoBehaviour
{
    [SerializeField] private UI_PermamagnetMenu _ferromagneticMenuUI;
    [SerializeField] private UI_ParamagneticMenu _paramagneticMenuUI;
    [SerializeField] private UI_NeutralMenu _neutralMenuUI;

    [Header("UI Elements")]
    [SerializeField] private Toggle transformModeToggle;
    [SerializeField] private TMP_Text transformSwitchButtonTextField;

    private ReferenceManager referenceManager;
    private Selectable _selectedObject;

    public void ToggleRotationMode(bool toggle)
    {
        if (toggle)
        {
            ReferenceManager.Instance.TransformHandle.type = RuntimeHandle.HandleType.ROTATION;
            transformSwitchButtonTextField.text = "Move\nObject";
        }
        else
        {
            ReferenceManager.Instance.TransformHandle.type = RuntimeHandle.HandleType.POSITION;
            transformSwitchButtonTextField.text = "Rotate\nObject";
        }
    }

    public void DeleteObject()
    {
        SelectionManager.ClearSelectionForced();
        Destroy(_selectedObject.gameObject);
    }

    public void Open(Selectable selectable)
    {

        referenceManager = ReferenceManager.Instance;
        _selectedObject = selectable;
        BuildCardMenu();
        ReferenceManager.Instance.TransformHandle.type = RuntimeHandle.HandleType.POSITION;
        transformSwitchButtonTextField.text = "Rotate\nObject";
        transformModeToggle.isOn = false;
        gameObject.SetActive(true);
        Close();
        referenceManager = ReferenceManager.Instance;
        _selectedObject = selectable;
        BuildCardMenu();
        ReferenceManager.Instance.TransformHandle.type = RuntimeHandle.HandleType.POSITION;
        transformSwitchButtonTextField.text = "Rotate\nObject";
        transformModeToggle.isOn = false;
        gameObject.SetActive(true);
        StartCoroutine(DelayedRebuild());

        IEnumerator DelayedRebuild()
        {
            yield return new WaitForEndOfFrame();
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
            LayoutRebuilder.MarkLayoutForRebuild((RectTransform)transform);
        }

    }

    public void Close()
    {
        _ferromagneticMenuUI.gameObject.SetActive(false);
        _paramagneticMenuUI.gameObject.SetActive(false);
        _neutralMenuUI.gameObject.SetActive(false);
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
            case Selectable.MaterialType.Paramagnetic:
                _paramagneticMenuUI.gameObject.SetActive(true);
                _paramagneticMenuUI.Initialize(_selectedObject.gameObject.GetComponent<ParamagneticMaterial>());
                break;
            case Selectable.MaterialType.Neutral:
                _neutralMenuUI.gameObject.SetActive(true);
                _neutralMenuUI.Initialize(_selectedObject);
                break;
        }//

        // Hacky layout probles require hacky solutions
        VerticalLayoutGroup[] verticalGroups = GetComponentsInChildren<VerticalLayoutGroup>();
        HorizontalLayoutGroup[] horizontalGroups = GetComponentsInChildren<HorizontalLayoutGroup>();
        foreach (var vGroup in verticalGroups)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(vGroup.GetComponent<RectTransform>());
            vGroup.SetLayoutVertical();
        }
        foreach (var hGroup in horizontalGroups)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(hGroup.GetComponent<RectTransform>());
            hGroup.SetLayoutHorizontal();
        }
    }
}
