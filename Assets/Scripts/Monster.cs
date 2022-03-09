using UnityEngine.UI;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private RessourcesManager _ressourcesManager;
    [SerializeField] private MonsterManager _monsterManager;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _lifeBar;

    [HideInInspector]
    public bool invincible; 
    private MonsterData _data;

    private int _pv = 10;
    private int _gold = 1;
    private float _diamondRate;

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
        _data = data;
        SetHealth();
    }

    public void Attacked(int power)
    {
        if(invincible)
        {
            return;
        }
        _pv -= power;
        AttackedFeedback();
        if(_pv<=0)
        {
            Die();
        }
    }
    private void Die()
    {
        ProcLoot();
        DieFeedback();
    }

    private void AttackedFeedback()
    {
        SetHealth();
        _animator.SetTrigger("Hit");
    }

    private void DieFeedback()
    {
        _animator.SetTrigger("Die");
    }

    private void SetHealth()
    {
        _lifeBar.fillAmount = ((float)_pv / _data.hp);
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
