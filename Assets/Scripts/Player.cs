using UnityEngine;
using UnityEngine.Events;
using System.Collections;
public class Player : MonoBehaviour
{
    private int _clickPower = 1;
    private int _autoPower = 0;
    [SerializeField] private MonsterManager monsterManager;
    [SerializeField] private RessourcesManager rm;
    
    private bool _isAutoClick;
    private float _timeBetClick = 1f;

    public void Start()
    {
        StartCoroutine(AutoClick());
    }

    public void ActivateOrPowerUpAutoClick()
    {
        _isAutoClick = true;
        _autoPower++;
    }

    private IEnumerator AutoClick()
    {
        while (!_isAutoClick)
        {
            yield return new WaitForSeconds(_timeBetClick);
        }
        while (_isAutoClick)
        {
            monsterManager.currentMonster.Attacked( _autoPower);
            yield return new WaitForSeconds(_timeBetClick);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(monsterManager != null)
            {
                monsterManager.currentMonster.Attacked(_clickPower);
            }
        }
    }

    public void AddPower()
    {
        _clickPower += 1;
    }
}
