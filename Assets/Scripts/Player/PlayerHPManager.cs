using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHpManager : MonoBehaviour
    {
        public Slider hpGage;
        
        public void UpdateHp(int hp)
        {
            hpGage.value = hp;
        }
    }
}
