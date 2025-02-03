using System;
using System.Collections.Generic;
using SplashKitSDK;

public class Player
{
    public Sprite Sprite
    {
        get; private set;
    }

    public Player(string imagePath, int startX, int startY)
    {
        Bitmap playerBitmap = new Bitmap("Player", imagePath);
        Sprite = SplashKit.CreateSprite(playerBitmap);
        SplashKit.SpriteSetX(Sprite, startX);
        SplashKit.SpriteSetY(Sprite, startY);

    }

    public void Move()
    {
        if(SplashKit.KeyDown(KeyCode.LeftKey) && SplashKit.SpriteX(Sprite) > 0)
        {
            SplashKit.SpriteSetX(Sprite, SplashKit.SpriteX(Sprite) - 5);
        }

        if(SplashKit.KeyDown(KeyCode.RightKey) && SplashKit.SpriteX(Sprite) < 800 - Sprite.Width)
        {
            SplashKit.SpriteSetX(Sprite, SplashKit.SpriteX(Sprite) + 5);
        }
    }

    public void Draw()
    {
        SplashKit.DrawSprite(Sprite);

    }
}