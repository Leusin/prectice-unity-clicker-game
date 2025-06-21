using UnityEngine;

public class CGClickButton : MonoBehaviour
{
    public int currentPoint = 0;
    public int currentPerClick = 1;

    public CGDataController datacontroller;

    public void OnClick()
    {
        int perClick = datacontroller.GetPerClick();
        datacontroller.AddPoint(perClick);
    }
}
