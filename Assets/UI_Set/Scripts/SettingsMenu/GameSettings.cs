using UnityEngine;

[System.Serializable]
public class GameSettings
{
    public float _masterVolume = 1f;
    public float _sfxVolume = 1f;
    public bool _subtitlesOn = false;

    private static GameSettings _instance;

    public static GameSettings Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameSettings();
            return _instance;
        }
    }


}
