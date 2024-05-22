using UnityEngine;

[System.Diagnostics.DebuggerDisplay("{" + nameof(DebuggerDisplay) + "(),nq}")]
public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private Transform radio1, radio2;

    [SerializeField]
    private AudioSource audioSource;

    private Transform player;

    public void OnSliderChanged(float val)
    {
        Debug.Log(val);
        PlayerPrefs.SetFloat("audioSource", val);
        {
            if (audioSource != null) { }
        }
    }

    private string DebuggerDisplay => ToString();
}