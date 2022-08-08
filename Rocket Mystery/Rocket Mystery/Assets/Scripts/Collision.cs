using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour

{

    
    [SerializeField] float restart = 0.5f;
    [SerializeField] AudioClip wybuch;
    [SerializeField] AudioClip Meta;

    [SerializeField] ParticleSystem zderzenie;
    [SerializeField] ParticleSystem sukces;


    AudioSource audioSource;

    bool isTransitioning = false;
    bool kolizja = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        KlawiszeNaprawy();
    }

    void KlawiszeNaprawy()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            kolizja = !kolizja;
        }

    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if(isTransitioning || kolizja)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                
                break;
            case "Finish":
                meta();
                break;
            default:
                Crash();
                break;
        }
 

    }
    void meta()
    {
        sukces.Play();
        GetComponent<Movement>().enabled = false;
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(Meta);
        Invoke("LoadNextLevel", restart);
        GetComponent<Movement>().enabled = false;
    }

    void Crash()
    {
        zderzenie.Play();
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(wybuch);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", restart);
        
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
       
}
