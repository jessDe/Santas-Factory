using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [HideInInspector] public GameObject player;

    [SerializeField] Slider staminaSlider;

    #region Mono Initialization
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        player = GameObject.FindGameObjectWithTag("Player");
    }
    #endregion

    #region Update Functions
    private void Update()
    {
        UpdatePlayerUI();
    }
    #endregion

    #region Custom Functions
    private void UpdatePlayerUI()
    {
        var playerMovement = player.GetComponent<PlayerMovement>();

        staminaSlider.value = playerMovement.SprintStamina.Map(0f, playerMovement.SprintDuration, 0f, 1f);
    }
    #endregion
}
