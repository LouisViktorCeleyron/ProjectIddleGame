using UnityEngine;
using UnityEngine.UI;

public class RessourcesManager : MonoBehaviour
{
    public Text textCailloux;
    public Text textDiamonds;
    private int caillouxAmount;
    private int diamondsAmount;
    public void ChangeCaillouAmount(int cailloux)
    {
        caillouxAmount += cailloux;
        textCailloux.text = caillouxAmount.ToString("00000000000");
    }
    public void ChangeDiamondAmount(int diamonds)
    {
        diamondsAmount+= diamonds;
        textDiamonds.text = diamondsAmount.ToString("00000000000");
    }
    public bool CanSpendCaillou(int amount)
    {
        return amount <= caillouxAmount;
    }
    public bool CanSpendDiamonds(int amount)
    {
        return amount <= diamondsAmount;
    }
}
