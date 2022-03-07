using UnityEngine;

public class EnnemyManager : MonoBehaviour
{
    public RessourcesManager ressourcesManager;
    public Player player;
    public EnnemyData[] datas;
    private EnnemyData _currentData;
    public Ennemy currentEnnemy;

    private void Start()
    {
        CreateEnnemy();
    }

    public void PickEnnemy()
    {
        _currentData = datas[0];
    }

    public void CreateEnnemy()
    {
        PickEnnemy();
        currentEnnemy.CreateEnnemy(this, ressourcesManager, _currentData);
    }
}
