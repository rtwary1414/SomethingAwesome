using SplashKitSDK;

public class Explosion
{
    private Sprite _sprite;
    public int _frameCount;
    public bool _active;

    public Explosion(string imagepath, float x, float y)
    {
        Bitmap explosionBitmap = new Bitmap(Guid.NewGuid().ToString(), imagepath);
        _sprite = SplashKit.CreateSprite(explosionBitmap);
        SplashKit.SpriteSetX(_sprite, x);
        SplashKit.SpriteSetY(_sprite, y);
        _frameCount = 30;
        _active = true;
    }

    public void Update()
    {
        if(_frameCount > 0)
        {
            _frameCount--;
        }
        else
        {
            _active = false;
        }
    }

    public bool isActive()
    {
        return _active;
    }

    public void Draw()
    {
        if(_active)
        {
            SplashKit.DrawSprite(_sprite);
        }
    }
}