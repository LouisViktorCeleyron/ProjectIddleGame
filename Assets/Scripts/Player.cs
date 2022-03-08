using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    public int power = 1;
    private MonsterManager monsterManager;
    private RessourcesManager rm;
    
    private bool _isAutoClick;
    private float _timeBetClick = 1f;


    public void LaunchAutoclick()
    {
        if(_isAutoClick)
        {
            return;
        }
        StartCoroutine(AutoClick());

    }

    private IEnumerator AutoClick()
    {
        while (true)
        {
            monsterManager.currentMonster.Attacked(1);
            yield return new WaitForSeconds(_timeBetClick);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(monsterManager != null)
            {
                monsterManager.currentMonster.Attacked(power);
            }
        }
    }

    public void AddPower()
    {
        power += 1;
    }
}
