using System.Collections;
using UnityEngine;
using TMPro;

public class CGItemButton : MonoBehaviour
{
    public TMP_Text itemDisplayer;

    public string itemName;
    public int level;
    [HideInInspector]
    public int currentCost = 1;
    public int startCurrentCost = 1;
    [HideInInspector]
    public int pointPerSec;
    public int startPointPerSec = 1;
    public float costPow = 3.14f;
    public float upgradePow = 1.07f;
    [HideInInspector]
    public bool isPurchased = false;

    void Start()
    {
        currentCost = startCurrentCost;
        pointPerSec = startPointPerSec;

        StartCoroutine(AddPointLoop());

        CGDataController.Instance.LoadItemButton(this);
        UpdateUI();
    }

    public void PurchaseItem()
    {
        if (CGDataController.Instance.GetPoint() >= currentCost)
        {
            isPurchased = true;
            CGDataController.Instance.SubPoint(currentCost);
            level++;

            UpdateItem();
            UpdateUI();

            CGDataController.Instance.SaveItemButton(this);
        }
    }

    IEnumerator AddPointLoop()
    {
        while (true)
        {
            if (isPurchased)
            {
                CGDataController.Instance.AddPoint(pointPerSec);
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateItem()
    {
        pointPerSec = startPointPerSec * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        itemDisplayer.text = $"[ {itemName} ]\nLevel: {level}\nCost: {currentCost}\nNext New  PointPerSec: {pointPerSec}\nIsPurchased: {isPurchased}";
    }
}
