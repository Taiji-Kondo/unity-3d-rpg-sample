using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Player
{
    public class PlayerHpManager : MonoBehaviour
    {
        public Slider hpGage;
        public Slider staminaGage;
        
        public void Init(PlayerManager playerManager)
        {
            hpGage.maxValue = playerManager.maxHp;
            hpGage.value = playerManager.maxHp;
            staminaGage.maxValue = playerManager.maxStamina;
            staminaGage.value = playerManager.maxStamina;
        }
        
        public void UpdateHp(int hp)
        {
            hpGage.DOValue(hp, 0.3f);
        }
        
        public void UpdateStamina(int stamina)
        {
            staminaGage.DOValue(stamina, 0.3f);
        }
    }
}
