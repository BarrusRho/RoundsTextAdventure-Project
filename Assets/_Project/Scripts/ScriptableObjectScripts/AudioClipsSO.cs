using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoundsTextAdventure
{
    [CreateAssetMenu(fileName = "AudioClips", menuName = "RoundsTextAdventure/AudioClips")]
    public class AudioClipsSO : ScriptableObject
    {
        [SerializeField]
        private SoundEffectClip[] soundEffectClips;
        
        private Dictionary<AudioTag, AudioClip> audioClips;

        private void OnEnable()
        {
            audioClips = soundEffectClips.ToDictionary(soundEffectClip => soundEffectClip.audioTag, soundEffectClip => soundEffectClip.audioClip);
        }

        public bool HasAudioClip(AudioTag audioTag)
        {
            return audioClips.ContainsKey(audioTag);
        }

        public AudioClip GetAudioClip(AudioTag audioTag)
        {
            if (!audioClips.TryGetValue(audioTag, out var audioClip) || audioClip == null)
            {
                Debug.Log($"$Missing or null AudioClip for AudioTag {audioTag}");
            }

            return audioClip;
        }
    }
}
