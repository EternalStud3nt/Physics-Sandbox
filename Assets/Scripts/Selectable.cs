using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Selectable : MonoBehaviour, IPointerDownHandler
{
    [field: SerializeField] public string ObjectName { get; private set; }
    [field: SerializeField, TextArea] public string ObjectDescrition { get; private set; }


    protected bool selected;
    protected Dictionary<MeshRenderer, Material> meshRendererToMaterial = new Dictionary<MeshRenderer, Material>();


    public bool CanBePlaced { get; private set; }

    public abstract MaterialType Type { get; }

    public enum MaterialType { Neutral, Ferromagnetic, Paramagnetic }


    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick(gameObject.GetComponent<Selectable>());
    }

    public void VisualizePlacementAvaiability()
    {
        if (CanBePlaced)
        {
            foreach (MeshRenderer meshRenderer in meshRendererToMaterial.Keys)//
            {
                meshRenderer.material = ReferenceManager.Instance.GreenHologramMaterial;
            }
        }
        else
        {
            foreach (MeshRenderer meshRenderer in meshRendererToMaterial.Keys)
            {
                meshRenderer.material = ReferenceManager.Instance.RedHologramMaterial;
            }
        }
    }

    public virtual void OnClick(Selectable gameObject)
    {
        if (SelectionManager.SelectedSelectable != this)
                SelectionManager.OnObjectClicked(gameObject);
    }

    public virtual void OnSelection()
    {
        selected = true;
        CanBePlaced = true;
        foreach (MeshRenderer meshRenderer in meshRendererToMaterial.Keys)
        {
            meshRenderer.material = ReferenceManager.Instance.GreenHologramMaterial;
        }
        ReferenceManager.Instance.UI_Overlay.OpenSelectionInfoCard();
    }

    public virtual void OnDeselection()
    {
        selected = false;
        foreach (MeshRenderer meshRenderer in meshRendererToMaterial.Keys)
        {
            meshRenderer.material = meshRendererToMaterial[meshRenderer];
        }
        ReferenceManager.Instance.UI_Overlay.CloseSelectionInfoCard();
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            SelectionManager.ClearSelection();
        }
    }

    protected virtual void Awake()
    {
        foreach (MeshRenderer meshRenderer in transform.GetComponentsInChildren<MeshRenderer>())
        {
            meshRendererToMaterial.Add(meshRenderer, meshRenderer.material);
        }
        SettingsBar.OnDeleteAllObjectsRequest += DeleteObject;
    }

    private void DeleteObject()
    {
        if (SelectionManager.SelectedSelectable == this)
        {
            SelectionManager.ClearSelectionForced();
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!selected) return;
        CanBePlaced = false;
        VisualizePlacementAvaiability();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!selected) return;
        CanBePlaced = true;
        VisualizePlacementAvaiability();
    }

    private void OnDestroy()
    {
        SettingsBar.OnDeleteAllObjectsRequest -= DeleteObject;
    }

}
