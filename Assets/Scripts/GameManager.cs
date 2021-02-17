using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int money = 0;
    [SerializeField] private Text moneyText;
    
    public void AddMoney()
    {
        money++;
        moneyText.text = money.ToString();
    }
   
}
