using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace ThreeSounds
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource audioSource1;
        public AudioSource audioSource2;
        public AudioSource audioSource3;
        public AudioMixer audioMixer;
        public float transitionTime = 1.0f;

        void Start()
        {
            StartCoroutine(PlaySequentialSounds());
        }

        IEnumerator PlaySequentialSounds()
        {
            yield return StartCoroutine(FadeIn(audioSource1, transitionTime));
            yield return new WaitForSeconds(audioSource1.clip.length - transitionTime);
            yield return StartCoroutine(FadeOut(audioSource1, transitionTime));

            yield return StartCoroutine(FadeIn(audioSource2, transitionTime));
            yield return new WaitForSeconds(audioSource2.clip.length - transitionTime);
            yield return StartCoroutine(FadeOut(audioSource2, transitionTime));

            yield return StartCoroutine(FadeIn(audioSource3, transitionTime));
            yield return new WaitForSeconds(audioSource3.clip.length - transitionTime);
            yield return StartCoroutine(FadeOut(audioSource3, transitionTime));
        }

        IEnumerator FadeIn(AudioSource audioSource, float duration)
        {
            float currentTime = 0;
            float start = 0.0f;
            audioSource.Play();

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                float newVolume = Mathf.Lerp(start, 1.0f, currentTime / duration);
                audioMixer.SetFloat("Volume", Mathf.Log10(newVolume) * 20);
                yield return null;
            }
        }

        IEnumerator FadeOut(AudioSource audioSource, float duration)
        {
            float currentTime = 0;
            float start = 1.0f;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                float newVolume = Mathf.Lerp(start, 0.0f, currentTime / duration);
                audioMixer.SetFloat("Volume", Mathf.Log10(newVolume) * 20);
                yield return null;
            }
            audioSource.Stop();
        }
    }
}
