using UnityEngine;
using UnityEngine.UI;
public class UltimateBar : MonoBehaviour
{
    public Image ultimateBarImage;
    public PlayerCombat player;
    public void UpdateUltimateBar()
    {
        ultimateBarImage.fillAmount = Mathf.Clamp(player.ultimateTime / player.next_ultimateTime, 0, 1f);
    }
}