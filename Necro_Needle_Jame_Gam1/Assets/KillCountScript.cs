using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCountScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killCountText;
    public GameObject player;

    private void Update()
    {
        killCountText.text = "Score: " + player.GetComponent<PlayerController>().killCountTotal.ToString();
    }
}