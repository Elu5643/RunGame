using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSoundManager : SingletonMonoBehaviour<GameSoundManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }

    public AudioClip[] BGMClips;
    public AudioClip[] SEClips;

    AudioSource[] BGMSources = new AudioSource[3];
    AudioSource[] SESources = new AudioSource[5];

    string sceneName;

    public enum BGMType
    {
        Title,
        StageSelect,
        Stage1
    }

    public enum SEType
    {
        Jump,
        GravitySwitch,
        Click,
        Clear,
        Death,
    }

    void Start()
    {
        for (int i = 0; i < BGMSources.Length; i++)
        {
            BGMSources[i] = gameObject.AddComponent<AudioSource>();
            BGMSources[i].clip = BGMClips[i];
        }

        for (int i = 0; i < SESources.Length; i++)
        {
            SESources[i] = gameObject.AddComponent<AudioSource>();
            SESources[i].clip = SEClips[i];
        }

    }

    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
        
        if (sceneName == "TitleScene")
        {
            BGMSources[(int)BGMType.StageSelect].Stop();
            BGMSources[(int)BGMType.Stage1].Stop();
        
        }
        else if(sceneName == "StageSelect")
        {
            BGMSources[(int)BGMType.Title].Stop();
            BGMSources[(int)BGMType.Stage1].Stop();
        }
        else if(sceneName == "Stage1")
        {
            BGMSources[(int)BGMType.Title].Stop();
            BGMSources[(int)BGMType.StageSelect].Stop();
        }
    }

    public void PlayBGM(BGMType bgmType)
    {
        if(!BGMSources[(int)bgmType].isPlaying)
        {
            BGMSources[(int)bgmType].PlayOneShot(BGMClips[(int)bgmType]);
        }
    }

    public void PlaySE(SEType seType)
    {
        SESources[(int)seType].PlayOneShot(SEClips[(int)seType]);
    }

    public void PlayBGMStop()
    {
        for (int i = 0; i < BGMSources.Length; i++)
        {
            BGMSources[i].Stop();
        }
    }
}
