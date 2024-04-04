using UnityEngine;

public class OutScreenPositionService 
{
    private readonly float _borderSize;
    private readonly float _downBorder;

    public OutScreenPositionService()
    {
        float orthographicSize = Camera.main.orthographicSize;
        _borderSize = orthographicSize * Screen.width / Screen.height;
        _downBorder = -orthographicSize;
    }

    public void SetPosition(FlyingSphereDataHolder dataHolder)
    {
        float xPosition = Mathf.Lerp(-_borderSize + dataHolder.Radius, _borderSize - dataHolder.Radius, Random.value);
        float yPosition = _downBorder - dataHolder.Radius;
        dataHolder.Transform.position = new Vector3(xPosition, yPosition);
    }
}
