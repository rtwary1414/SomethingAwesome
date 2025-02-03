using SplashKitSDK;

public class Background
{
    private Sprite _sprite;
    private float _yPosition;

    public Background(string imagePath)
    {
        Bitmap background = new Bitmap("Background", imagePath);
        _sprite = SplashKit.CreateSprite(background);
        _yPosition = 0;
    }

    public void Update()
    {
        _yPosition += 2;
        if(_yPosition >= 600)
        {
            _yPosition = 0;
        }
    }

    public void Draw()
    {
        SplashKit.DrawSprite(_sprite, 0, _yPosition);
        SplashKit.DrawSprite(_sprite, 0, _yPosition - 600);
    }
}