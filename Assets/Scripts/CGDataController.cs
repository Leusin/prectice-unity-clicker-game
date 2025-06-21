using UnityEngine;

public class CGDataController : CGSingleton<CGDataController>
{
    private int _point = 0;
    private int _perClick = 0;

    private CGItemButton[] itemButtons;

    void Awake()
    {
        _point = PlayerPrefs.GetInt(CGPlayerPrefKeys.Point);
        _perClick = PlayerPrefs.GetInt(CGPlayerPrefKeys.PerClick, 1);

        itemButtons = Object.FindObjectsByType<CGItemButton>(FindObjectsSortMode.None);
    }

    //
    // Point Section
    //

    public int GetPoint()
    {
        return _point;
    }

    public void SetPoint(int inPint)
    {
        _point = inPint;
        PlayerPrefs.SetInt(CGPlayerPrefKeys.Point, _point);
    }

    public void AddPoint(int inPoint)
    {
        _point += inPoint;
        SetPoint(_point);
    }

    public void SubPoint(int inPoint)
    {
        _point -= inPoint;
        SetPoint(_point);
    }

    //
    // PerClick Section
    //

    public int GetPerClick()
    {
        return _perClick;
    }

    public void SetPerClick(int inPerClick)
    {
        _point = inPerClick;
        PlayerPrefs.SetInt(CGPlayerPrefKeys.PerClick, inPerClick);
    }

    public void AddPerClick(int inPerClick)
    {
        _perClick += inPerClick;
        PlayerPrefs.SetInt(CGPlayerPrefKeys.PerClick, _perClick);
    }

    public void SubPerClick(int inPerClick)
    {
        _perClick -= inPerClick;
        PlayerPrefs.SetInt(CGPlayerPrefKeys.PerClick, _perClick);
    }

    //
    // Item Buttons Section
    //

    public int GetTotalPointPerSec()
    {
        int totalPointPerSec = 0;
        for (int i = 0; i < itemButtons.Length; i++)
        {
            totalPointPerSec = itemButtons[i].pointPerSec;
        }

        return totalPointPerSec;
    }

    //
    // Upgrade Button Section
    //

    public void LoadUpgradeButton(CGUpgradeButton inUpgrade)
    {
        string keyLevel = CGPlayerPrefKeys.GetLevelKey(inUpgrade);
        string keyPointByUpgrade = CGPlayerPrefKeys.GetPointbyUpgradeKey(inUpgrade);
        string keyCurrentCost = CGPlayerPrefKeys.GetCurrentCostKey(inUpgrade);

        inUpgrade.level = PlayerPrefs.GetInt(keyLevel, 1);
        inUpgrade.pointByUpgrade = PlayerPrefs.GetInt(keyPointByUpgrade, inUpgrade.startPointByUpgrade);
        inUpgrade.currentCost = PlayerPrefs.GetInt(keyCurrentCost, inUpgrade.startCurrentCost);
    }

    public void SaveUpgradeButton(CGUpgradeButton inUpgrade)
    {
        string keyLevel = CGPlayerPrefKeys.GetLevelKey(inUpgrade);
        string keyPointByUpgrade = CGPlayerPrefKeys.GetPointbyUpgradeKey(inUpgrade);
        string keyCurrentCost = CGPlayerPrefKeys.GetCurrentCostKey(inUpgrade);

        PlayerPrefs.SetInt(keyLevel, inUpgrade.level);
        PlayerPrefs.SetInt(keyPointByUpgrade, inUpgrade.pointByUpgrade);
        PlayerPrefs.SetInt(keyCurrentCost, inUpgrade.currentCost);
    }

    //
    // Item Button Section
    //

    public void LoadItemButton(CGItemButton inItem)
    {
        string keyLevel = CGPlayerPrefKeys.GetLevelKey(inItem);
        string keyCurrentCost = CGPlayerPrefKeys.GetCurrentCostKey(inItem);
        string keyPointPerSec = CGPlayerPrefKeys.GetPointPerSecKey(inItem);
        string keyIsPurchased = CGPlayerPrefKeys.GetCurrentCostKey(inItem);

        inItem.level = PlayerPrefs.GetInt(keyLevel);
        inItem.currentCost = PlayerPrefs.GetInt(keyCurrentCost, inItem.startCurrentCost);
        inItem.pointPerSec = PlayerPrefs.GetInt(keyPointPerSec, inItem.startPointPerSec);

        if (PlayerPrefs.GetInt(keyIsPurchased) == 1)
        {
            inItem.isPurchased = true;
        }
        else
        {
            inItem.isPurchased = false;
        }
    }

    public void SaveItemButton(CGItemButton inItem)
    {
        string keyLevel = CGPlayerPrefKeys.GetLevelKey(inItem);
        string keyCurrentCost = CGPlayerPrefKeys.GetCurrentCostKey(inItem);
        string keyPointPerSec = CGPlayerPrefKeys.GetPointPerSecKey(inItem);
        string keyIsPurchased = CGPlayerPrefKeys.GetCurrentCostKey(inItem);

        PlayerPrefs.SetInt(keyLevel, inItem.level);
        PlayerPrefs.SetInt(keyCurrentCost, inItem.currentCost);
        PlayerPrefs.SetInt(keyPointPerSec, inItem.pointPerSec);

        if (inItem.isPurchased == true)
        {
            PlayerPrefs.SetInt(keyIsPurchased, 1);
        }
        else
        {
            PlayerPrefs.SetInt(keyIsPurchased, 0);
        }
    }
}
