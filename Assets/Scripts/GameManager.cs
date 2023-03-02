using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool hasKey = false;
    private int Coins;
    [SerializeField] private TextMeshProUGUI text;
    private string pretext = "Coins Left: ";
    [SerializeField] private GameObject key;
    private bool activateKey = false;
    public Vector3 playerpos;
    [SerializeField] private TextMeshProUGUI textBruh;
    public int Coins1 { get => Coins; set => Coins = value; }

    public void RefreshCoin()
    {
        text.text = pretext + Coins.ToString();
    }

    private void Awake()
    {
        text.text = pretext + Coins.ToString();
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
        }
        playerpos = GameObject.Find("Player").transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RefreshCoin();

        if (this.Coins == 0 && !activateKey)
        {
            textBruh.enabled = true;
            textBruh.text = "You've unlocked the key! Just find it.";
            Invoke("DeactivateText", 2f);
            key.SetActive(true);
            activateKey = true;
        }

    }

    void DeactivateText()
    {
        textBruh.enabled = false;
    }
}
