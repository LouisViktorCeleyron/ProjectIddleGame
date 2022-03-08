using UnityEngine;

[CreateAssetMenu(fileName ="Nimportequoi", menuName ="Pouet/prout", order =1)]
public class MonsterData : ScriptableObject
{
    public Sprite appeareance;
    [Header("Stats")] //Affiche un petit label dans l'inspector
    [Tooltip("Number of gold dropped by the ennemy when beaten")] //Tooltip permet d'afficher une description quand on passe la souris sur l'element dans l'inspecteur
    public int gold;
    [Tooltip("Number of hp of the ennemy")]
    public int hp;

    [Range(0,100)]
    [Tooltip("Percentage of chance of a diamond dropping when the ennemy is beaten")] 
    [SerializeField]
    private int diamondRate = 30;
    public float DiamondRate => diamondRate/100f; //J'utilise le petit signe => qui est un raccourci pour faire un get. Je fais ça car la plupart des elements d'unity sont entre 0 et 1 et pas 0 et 100
}
