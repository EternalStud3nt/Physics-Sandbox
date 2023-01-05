using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CreationBar : MonoBehaviour
{
    [SerializeField] private Sprite downArrow;
    [SerializeField] private Sprite upArrow;
    [SerializeField] private Image collapseButtonImage;
    [SerializeField] private RectTransform scrollView;

    private bool collapsed;
    private float initialViewportHeight;

    public void CreateObject(GameObject prefab)
    {
        Debug.Log("1");
        if (SelectionManager.SelectedSelectable != null)
        {
            return;
        }
        Debug.Log("2");
        GameObject newObj = Instantiate(prefab, SelectionManager.MainCamera.transform.position + SelectionManager.MainCamera.transform.forward * 2f, prefab.transform.rotation);
        Selectable newSelectable = newObj.GetComponent<Selectable>();
        newSelectable.OnClick(newSelectable);
    }

    public void ToggleCollapse()
    {
        collapsed = !collapsed;
        if (collapsed)
        {
            var rect = scrollView.rect;
            rect.height = initialViewportHeight;
            scrollView.sizeDelta = new Vector2(rect.width, 0);
            collapseButtonImage.sprite = downArrow;
            collapseButtonImage.sprite = upArrow;
        }
        else
        {
            var rect = scrollView.rect;
            rect.height = initialViewportHeight;
            scrollView.sizeDelta = new Vector2(rect.width, rect.height);
            collapseButtonImage.sprite = downArrow;
        }
    }

    private void Start()
    {
        initialViewportHeight = scrollView.rect.height;
        collapsed = false;
        collapseButtonImage.sprite = downArrow;
    }
}
