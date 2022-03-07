using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    public int power = 1;
    public EnnemyManager _ennemyManager;
    public RessourcesManager rm;
    private bool isAutoclick;
    public float timeBetClick = 1f;


    public void LaunchAutoclick()
    {
        if(isAutoclick)
        {
            return;
        }
        StartCoroutine(AutoClick());

    }

    private IEnumerator AutoClick()
    {
        while (true)
        {
            _ennemyManager.currentEnnemy.Attack(1);
            yield return new WaitForSeconds(timeBetClick);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(_ennemyManager != null)
            {
                _ennemyManager.currentEnnemy.Attack(power);
            }
        }
    }

    public void AddPower()
    {
        if(rm.CanSpendCaillou(5))
        {
            rm.ChangeCaillouAmount(-5);
            power += 1;
        }
    }
}
