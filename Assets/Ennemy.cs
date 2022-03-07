using UnityEngine;

public class Ennemy : MonoBehaviour
{
    private RessourcesManager _ressourcesManager;
    private EnnemyManager _ennemyManager;
    
    public int pv = 10;
    public int gold = 1;
    private float diamondRate;

    public MeshRenderer[] mr;

    public void CreateEnnemy(EnnemyManager caillouManager, RessourcesManager ressourcesManager, EnnemyData data)
    {
        _ennemyManager = caillouManager;
        _ressourcesManager = ressourcesManager;

        pv = data.hp;
        gold = data.gold;
        diamondRate = data.diamondRate;


        foreach (var meshR in mr)
        {
            meshR.material.color = data.couleur;

        }
    }

    public void Attack(int power)
    {
        pv -= power;
        if(pv<=0)
        {
            _ressourcesManager.ChangeCaillouAmount(gold);
            var diamondProc = Random.Range(0f, 1f);
            if(diamondProc<=diamondRate)
            {
                _ressourcesManager.ChangeDiamondAmount(1);
            }

            _ennemyManager.CreateEnnemy();
            Destroy(gameObject);
        }
    }

}
