using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesKontrol : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    AudioClip astroidPatlama = default;

    [SerializeField]
    AudioClip gemiPatlama = default;

    [SerializeField]
    AudioClip ates = default;

    AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void AstroidPAtlama()
    {
        audiosource.PlayOneShot(astroidPatlama);
    }

    public void GemiPatlama()
    {
        audiosource.PlayOneShot(gemiPatlama);
    }

    public void Ates()
    {
        audiosource.PlayOneShot(ates,0.4f);
    }
}
