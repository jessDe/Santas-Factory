using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class TextUpdater : MonoBehaviour
{
    [Range(0.01f, 1f)]
    [SerializeField] float delayTime;

    public TextMeshProUGUI text;
    public AudioSource audioSource;
    private string finalText;
    private int state = 0;

    public bool whileplaying = false;

    private float timer = 0;
    
    private void Start()
    {
        finalText = text.text;
        text.text = string.Empty;

        Debug.Log(finalText);
    }

    void Update()
    {
        if (!whileplaying) return;
     
        timer += Time.deltaTime;
        if (timer >= delayTime)
        {
            timer = 0;
            if (state < finalText.Length)
            {
                state++;
                audioSource.pitch = Random.Range(0.3f, 1f);
                audioSource.volume = Random.Range(0.7f, 1f);
                
                
                string newText = finalText.Substring(0, state);
                //Check if the last character is a anphabetical character or a comma or space
                if (newText[newText.Length - 1] != '\n')
                {
                    audioSource.PlayOneShot(audioSource.clip);
                }
                    
                text.text = newText;
                
            }
            else
            {
                if (state < finalText.Length + 5)
                {
                    state++;
                }
                else
                {
                    this.transform.parent.parent.gameObject.SetActive(false);
                }
                GameObject.Find("Akt 1 Manager").GetComponent<Akt1Manager>().IntroDone();
                
            }
        }
    }
}
