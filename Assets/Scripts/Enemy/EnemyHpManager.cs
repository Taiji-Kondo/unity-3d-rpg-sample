using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHpManager : MonoBehaviour
    {
        public Slider hpGage;
        
        public void Init(EnemyManager enemyManager)
        {
            hpGage.maxValue = enemyManager.maxHp;
            hpGage.value = enemyManager.maxHp;
        }
        
        public void UpdateHp(int hp)
        {
            hpGage.value = hp;
        }
    }
}
