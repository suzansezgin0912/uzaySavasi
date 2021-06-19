﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject uzayGemisiPrefab;

    [SerializeField]
    List<GameObject> asteroidPrefabs = new List<GameObject>();

    GameObject uzayGemisi;
    List<GameObject> asteroidList = new List<GameObject>();

    [SerializeField]
    int zorluk = 1;

    [SerializeField]
    int carpan = 5;

    UIKontrol uıkontrol;
    // Start is called before the first frame update


    void Start()
    {
        uıkontrol = GetComponent<UIKontrol>();
    }

    public  void oyunuBaslat ()
    {
        uıkontrol.oyunuBasladi();
        uzayGemisi = Instantiate(uzayGemisiPrefab);
        uzayGemisi.transform.position = new Vector3(0, EkranHesaplayicisi.Alt + 1.5f);
        AsteroidUret(5);
    }


    void AsteroidUret(int adet)
    {
        Vector3 position = new Vector3();

        for (int i = 0; i < adet; i++)
        {
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);
            position.x = Random.Range(EkranHesaplayicisi.Sol, EkranHesaplayicisi.Sag);
            position.y = EkranHesaplayicisi.Ust - 1;

            GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0, 3)], position, Quaternion.identity);
            asteroidList.Add(asteroid);
        }
    }

    public void AsteroidYokOldu(GameObject asteroid)
    {
        uıkontrol.astroidYokOldu(asteroid);
        asteroidList.Remove(asteroid);
        if(asteroidList.Count <= zorluk)
        {
            zorluk++;
            AsteroidUret(zorluk * carpan);
        }
        
    }
    public void oyunuBitir()
    {
        foreach (GameObject astroid in asteroidList)
        {
            astroid.GetComponent<Asteroid>().AstroidYokEt();
        }
        asteroidList.Clear();
        zorluk = 1;
        uıkontrol.oyunBitti();
    }
}