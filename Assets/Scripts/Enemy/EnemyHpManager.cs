using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHpManager : MonoBehaviour
    {
        public Slider hpSlider;
        
        public void Init(EnemyManager enemyManager)
        {
            hpSlider.maxValue = enemyManager.maxHp;
            hpSlider.value = enemyManager.maxHp;
        }
        
        public void UpdateHp(int hp)
        {
            hpSlider.value = hp;
        }
    }
}
