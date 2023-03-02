using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectTreasure : MonoBehaviour
{

    [SerializeField] private AudioClip confettiSound;
    public GameObject confetti;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        confetti.GetComponent<ParticleSystem>().Play();
        GameObject.Find("SoundFX").GetComponent<AudioSource>().clip = confettiSound;
        GameObject.Find("SoundFX").GetComponent<AudioSource>().PlayOneShot(confettiSound);
        gameObject.SetActive(false);
        Invoke("loadgameover", 5f);
    }

    void loadgameover()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
