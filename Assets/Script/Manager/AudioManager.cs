using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource dialogueSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayDialogue(AudioClip clip)
    {
        if (clip == null)
            return;

        dialogueSource.Stop();
        dialogueSource.clip = clip;
        dialogueSource.Play();
    }
}
