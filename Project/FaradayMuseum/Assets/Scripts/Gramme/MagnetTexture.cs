using UnityEngine;

public class MagnetTexture : ScrollTexture
{
    public float scrollSpeed = 0.5f;
    private float scrollSpeedY;
    public override float ScrollSpeedX { get => -scrollSpeed; set => scrollSpeed = -value; }
    public override float ScrollSpeedY { get => 0; set => scrollSpeedY = 0; }

    public void InvertMagnetTexture(){
        transform.localRotation *= Quaternion.Euler(0, 0, 180);
    }
}
