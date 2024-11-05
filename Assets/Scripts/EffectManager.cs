using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
  private static EffectManager _instance;
  public static EffectManager Instance
  {
    get
    {
      if (_instance == null)
      {
        GameObject manager = new GameObject("EffectManager");
        _instance = manager.AddComponent<EffectManager>();
      }
      return _instance;
    }
  }

  private Dictionary<Effect, AudioClip> _effectClips;
  private AudioSource _audioSource;

  private void Awake()
  {
    if (_instance == null)
    {
      _instance = this;
      DontDestroyOnLoad(gameObject);
      _effectClips = new Dictionary<Effect, AudioClip>();
      _audioSource = gameObject.AddComponent<AudioSource>();

      // EnumとAudioClipのマッピングを初期化
      InitializeEffectClips();
    }
    else
    {
      Destroy(gameObject);
    }
  }

  private void InitializeEffectClips()
  {
    foreach (Effect effect in System.Enum.GetValues(typeof(Effect)))
    {
      string path = $"Effects/{effect}";
      AudioClip clip = Resources.Load<AudioClip>(path);
      if (clip != null)
      {
        _effectClips[effect] = clip;
      }
      else
      {
        Debug.LogWarning($"Effect '{effect}' not found at path '{path}'.");
      }
    }
  }

  public void PlayEffect(Effect effect)
  {
    if (_effectClips.TryGetValue(effect, out var clip))
    {
      _audioSource.PlayOneShot(clip);
    }
    else
    {
      Debug.LogWarning($"Effect '{effect}' has no associated AudioClip.");
    }
  }

  public void PlayEffect(Effect effect, float volume)
  {
    if (_effectClips.TryGetValue(effect, out var clip))
    {
      _audioSource.PlayOneShot(clip, volume);
    }
    else
    {
      Debug.LogWarning($"Effect '{effect}' has no associated AudioClip.");
    }
  }
}
