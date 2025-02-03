using SplashKitSDK;

public class Obstacle
{
    public Sprite Sprite
    {
        get; private set;
    }

    public Obstacle(string imagePath, int X)
    {
        Bitmap obstacleBitmap = new Bitmap(Guid.NewGuid().ToString(), imagePath);
        Sprite = SplashKit.CreateSprite(obstacleBitmap);
        SplashKit.SpriteSetX(Sprite, X);
        SplashKit.SpriteSetY(Sprite, -Sprite.Height);
    }

    public void Move()
    {
        SplashKit.SpriteSetY(Sprite, SplashKit.SpriteY(Sprite) + 5);
    }

    public bool IsOffScreen()
    {
        return SplashKit.SpriteY(Sprite) > 600;
    }

    public void Draw()
    {
        SplashKit.DrawSprite(Sprite);
    }
}