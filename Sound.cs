using SplashKitSDK;

public class Sound
{
    private SoundEffect sound;
    private Music backgroundMusic;

    public Sound()
    {
        sound = new SoundEffect("Explosive Sound", "explosion.wav");
        backgroundMusic = new Music("Background Music", "background_music.mp3");
        PlayBackgroundMusic();
    }

    public void ExplosionNoise()
    {
        sound.Play();
    }

    public void PlayBackgroundMusic()
    {
        if(!SplashKit.MusicPlaying())
        {
            SplashKit.PlayMusic("background_music.mp3", -1);
        }
    }

    public void StopBackgroundMusic()
    {
        SplashKit.StopMusic();
    }
}