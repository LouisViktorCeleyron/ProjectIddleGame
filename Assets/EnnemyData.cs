using UnityEngine;

[CreateAssetMenu(fileName ="Nimportequoi", menuName ="Pouet/prout", order =1)]
public class EnnemyData : ScriptableObject
{
    public int gold;
    public int hp;
    [Range(0,1)]
    public float diamondRate = 0.3f;
    public Color couleur;
}
