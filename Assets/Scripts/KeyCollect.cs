using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCollect : MonoBehaviour
{
  
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject door;
    [SerializeField] private Vector2 keypos;
    [SerializeField] private AudioClip keySound;
    

    public TextMeshProUGUI Text { get => text; set => text = value; }

    private void Awake()
    {
        transform.position = new Vector2(keypos.x, keypos.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("SoundFX").GetComponent<AudioSource>().clip = keySound;
            GameObject.Find("SoundFX").GetComponent<AudioSource>().PlayOneShot(keySound);
            GameObject.Find("GameManager").GetComponent<GameManager>().hasKey = true;
            text.text = "You've unlocked a door! You just have to find it!";
            text.enabled = true;
            door.SetActive(true);
            Invoke("deactivateText", 2);
            gameObject.SetActive(false);
        }
    }

    void deactivateText()
    {
        text.enabled = false;
    }



}
