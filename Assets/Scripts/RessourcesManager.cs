using UnityEngine;
using UnityEngine.UI;

public class RessourcesManager : MonoBehaviour
{
    
    [SerializeField] private Text textGold;
    [SerializeField] private Text textDiamonds;

    [SerializeField] private int goldAmount;
    [SerializeField] private int diamondsAmount;

    [SerializeField] private ActionStructure[] actions;
  

    #region RessourceManagement

    public void ChangeGoldAmount(int cailloux)
    {
        goldAmount += cailloux;
        textGold.text = goldAmount.ToString("00000000000");
    }

    public void ChangeDiamondAmount(int diamonds)
    {
        diamondsAmount+= diamonds;
        textDiamonds.text = diamondsAmount.ToString("00000000000");
    }

    private bool CanSpendGold(int amount)
    {
        return amount <= goldAmount;
    }

    private bool CanSpendDiamonds(int amount)
    {
        return amount <= diamondsAmount;
    }

    #endregion

    #region Actions related Functions

    /// <summary>
    /// Cette fonction est appelé via les bouttons d'unity 
    /// </summary>
    /// <param name="actionName">Le nom de l'action a appeller</param>
    public void CallAction(string actionName)
    {
        //Variables locales 
        ActionStructure actionToApply = new ActionStructure();
        
        //Definir quelle action de la liste lancer
        foreach (var action in actions)
        {
            if (action.actionName == actionName)
            {
                actionToApply = action;
            }
        }
        
        //Par sécuritée on arrete la fonction si l'action à un nom vide 
        if (actionToApply.actionName == string.Empty)
        {
            ActionCalledNegativeFeedback();//On appel un feedback negatif si l'achat est impossible
            return;
        }
        
        //Si le joueur a assez de ressources alors on appel la fonction et on enleve les ressources nécéssaires
        if (CanSpendGold(actionToApply.goldCost) && CanSpendDiamonds(actionToApply.diamondCost))
        {
            ChangeGoldAmount(-actionToApply.goldCost);
            ChangeDiamondAmount(-actionToApply.diamondCost);
            actionToApply.action.Invoke();
            ActionCalledPositiveFeedback(); //Et on appel un feedback positif
        }
        
        ActionCalledNegativeFeedback();//On appel un feedback negatif si l'achat est impossible
    }

    private void ActionCalledPositiveFeedback()
    {
        Debug.Log("PositiveFeedback");
    }

    private void ActionCalledNegativeFeedback()
    {
        Debug.Log("NegativeFeedback");
    }

    #endregion
}
