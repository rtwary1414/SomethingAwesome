using SplashKitSDK;

public class Game
{
    private Window _GameWindow;
    private Player _Player;
    private List<Obstacle> obstacles;
    private int score;
    private int lives;
    private Random _random;
    private SplashKitSDK.Timer _timer;
    private List<Explosion> explosions;
    private Sound soundEffect;
    private Background background;

    public Game()
    {
        _GameWindow = new Window("Sky Dodger", 800, 600);
        _Player = new Player("Plane.png", 400, 500);
        obstacles = new List<Obstacle>();
        score = 0;
        lives = 3;
        _random = new Random();
        _timer = new SplashKitSDK.Timer("myTimer");
        _timer.Start();
        explosions = new List<Explosion>();
        soundEffect = new Sound();
        background = new Background("background.jpg");
    }

    public void Run()
    {
        while(!_GameWindow.CloseRequested)
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen(Color.Navy);

            soundEffect.PlayBackgroundMusic();

            background.Update();
            background.Draw();

            if(SplashKit.Rnd() < 0.02)
            {
                obstacles.Add(new Obstacle("Rock.png", _random.Next(0, _GameWindow.Width - 50)));
            }

            _Player.Move();
            _Player.Draw();

            obstacles.RemoveAll(obstacle => {
                if(SplashKit.SpriteCollision(_Player.Sprite, obstacle.Sprite) && _timer.Ticks > 1000)
                {
                    explosions.Add(new Explosion("Explosion.png", SplashKit.SpriteX(_Player.Sprite), SplashKit.SpriteY(_Player.Sprite)));
                    soundEffect.ExplosionNoise();
                    lives--;
                    _timer.Reset();
                    return true;
                }
                return obstacle.IsOffScreen();
            });

            explosions.RemoveAll(explosion => !explosion.isActive());
            foreach(var explosion in explosions)
            {
                explosion.Update();
                explosion.Draw();
            }

            foreach(var obstacle in obstacles)
            {
                obstacle.Move();
                obstacle.Draw();
            }

            if(lives <= 0)
            {
                GameOver();
                return;
            }

            score++;

            SplashKit.DrawText($"Score: {score}", Color.Orange, "Arial", 20, 10, 10);
            SplashKit.DrawText($"Lives: {lives}", Color.Orange, "Arial", 20, 10, 40);

            _GameWindow.Refresh(60);
        }

        soundEffect.StopBackgroundMusic();
    }

    private void GameOver()
    {
        _GameWindow.Clear(Color.BlueViolet);
        SplashKit.DrawText($"GAME OVER! FINAL SCORE: {score}", Color.White, "Arial", 60, 275, 275);
        _GameWindow.Refresh();
        SplashKit.Delay(9000);
        _GameWindow.Close();
    }
}