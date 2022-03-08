using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public RessourcesManager ressourcesManager;
    public Player player;
    public MonsterData[] datas;
    private MonsterData _currentData;
    public Monster currentMonster;

    private void Start()
    {
        CreateMonster();
    }

    public void PickMonster()
    {
        _currentData = datas[0];
    }

    public void CreateMonster()
    {
        PickMonster();
        currentMonster.InitializeMonster(_currentData);
    }
}
