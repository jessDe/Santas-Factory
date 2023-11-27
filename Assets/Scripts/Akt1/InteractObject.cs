using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InteractObject : MonoBehaviour
{
    public enum InteractMode
    {
        Teleport,
        Trigger,
        Toggle
    }
    public InteractMode mode;
    public GameObject target;
    
    public Image fadeImage;
    public float fadeSpeed = 1.0f;

    public void Interact()
    {
        Debug.Log("Interact");
        switch (mode)
        {
            case InteractMode.Teleport:
                GameObject Player = GameObject.FindWithTag("Player");
                Player.GetComponent<PlayerMovement>().enabled = false;
                
                StartCoroutine(FadeOut());
                break;
            case InteractMode.Trigger:
                //TODO: Trigger on target
                break;
            case InteractMode.Toggle:
                target.SetActive(!target.activeSelf);
                break;
        }
    }
    
    IEnumerator FadeOut()
    {
        while (fadeImage.color.a < 1)
        {
            Color newColor = fadeImage.color;
            newColor.a += Time.deltaTime * fadeSpeed;
            fadeImage.color = newColor;
            yield return null;
        }
        GameObject Player = GameObject.FindWithTag("Player");
        
        Player.transform.position = target.transform.position;
        while (fadeImage.color.a > 0)
        {
            Color newColor = fadeImage.color;
            newColor.a -= Time.deltaTime * fadeSpeed;
            fadeImage.color = newColor;
            yield return null;
        }
        
        Player.GetComponent<PlayerMovement>().enabled = true;
    }
    
}
