using UnityEngine;

public class TriangleFX : MonoBehaviour
{
    public AudioClip myClip;
    public AudioSource mySource;
    public ParticleSystem myParticles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
        mySource.clip = myClip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        mySource.Play();
        myParticles.Play();
    }
}
