using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Audio Components")]
    public AudioSource audioSource; // Music player

    [Header("Songs List")]
    public AudioClip[] playlist;    // Music array

    private int currentSongIndex = 0; //Song Index

    // Play song on startup (from currentSongIndex) 
    void Start()
    {
        if (playlist.Length > 0 && audioSource != null)
        {
            PlaySong(currentSongIndex);
        }
    }

    // Next Song
    public void NextSong()
    {
        if (playlist.Length == 0) return;

        currentSongIndex = (currentSongIndex + 1) % playlist.Length;

        PlaySong(currentSongIndex);
    }

    //Stop current song - play next song
    private void PlaySong(int index)
    {
        audioSource.Stop();
        audioSource.clip = playlist[index];
        audioSource.Play();
    }
}
