using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text seedText;
    [SerializeField] private PlayerManager playerManager;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        seedText.text = playerManager.actualSeedCount.ToString() + " / " + playerManager.maxSeedCount.ToString();
    }
}
