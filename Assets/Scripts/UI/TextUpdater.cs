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
    public string finalText;
    [HideInInspector]
    public int state = 0;

    public bool whileplaying = false;

    private float timer = 0;

    private void Start()
    {
        finalText = text.text;
        text.text = string.Empty;
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
                audioSource.Play();
                string newText = finalText.Substring(0, state);
                text.text = newText;
            }
            else
            {
                this.transform.parent.parent.gameObject.SetActive(false);
            }
        }
    }
    
}
