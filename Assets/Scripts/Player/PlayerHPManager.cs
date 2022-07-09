using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
            hpGage.DOValue(hp, 0.3f);
        }
    }
}
