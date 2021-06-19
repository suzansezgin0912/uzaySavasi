using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject oyunAdiText = default;

    [SerializeField]
    GameObject oyunBittiText = default;

    [SerializeField]
    Text puanText = default;

    [SerializeField]
    GameObject oynaButton = default;

    int puan;

    // Start is called before the first frame update
    void Start()
    {
        oyunBittiText.gameObject.SetActive(false);
        puanText.gameObject.SetActive(false);        
    }

    public void oyunuBasladi()
    {
        puan = 0;
        oyunAdiText.gameObject.SetActive(false);
        oynaButton.gameObject.SetActive(false);
        puanText.gameObject.SetActive(true);
        oyunBittiText.gameObject.SetActive(false);
        puanGuncelle();
    }
    public void oyunBitti()
    {
        oyunBittiText.gameObject.SetActive(true);
        oynaButton.gameObject.SetActive(true);
    }

    void puanGuncelle()
    {
        puanText.text = "PUAN:" + puan;

    }

    // Update is called once per frame
    
    public void astroidYokOldu(GameObject astroid)
    {

        switch (astroid.gameObject.name[8])
        {
            case '1':
                puan += 5;
                puanGuncelle();
                break;
            case '2':
                puan += 10;
                puanGuncelle();
                break;
            case '3':
                puan += 15;
                puanGuncelle();
                break;
            default:
                break;
        }
    }
}
