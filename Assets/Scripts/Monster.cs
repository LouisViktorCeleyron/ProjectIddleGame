using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private RessourcesManager _ressourcesManager;
    [SerializeField]
    private MonsterManager _monsterManager;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    
    private int _pv = 10;
    private int _gold = 1;
    private float _diamondRate;

    public MeshRenderer[] mr;

    /// <summary>
    /// Cette fonction s'appelle quand le monstre est crée, comme j'ai un seul monstre que j'update a la place d'en creé un nouveau
    /// </summary>
    /// <param name="data">Data du nouveau monstre</param>
    public void InitializeMonster(MonsterData data)
    {
        _pv = data.hp;
        _gold = data.gold;
        _diamondRate = data.DiamondRate;
        _spriteRenderer.sprite = data.appeareance;

    }

    public void Attacked(int power)
    {
        _pv -= power;
        if(_pv<=0)
        {
            ProcLoot();
            _monsterManager.CreateMonster();
            Destroy(gameObject);
        }
    }

    private void ProcLoot()
    {
        _ressourcesManager.ChangeGoldAmount(_gold);
        var diamondProc = Random.Range(0f, 1f);
        if(diamondProc<=_diamondRate)
        {
            _ressourcesManager.ChangeDiamondAmount(1);
        }
    }
}
