using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHpManager : MonoBehaviour
    {
        public Slider hpGage;
        
        public void Init(PlayerManager playerManager)
        {
            hpGage.maxValue = playerManager.maxHp;
            hpGage.value = playerManager.maxHp;
        }
        
        public void UpdateHp(int hp)
        {
            hpGage.value = hp;
        }
    }
}
