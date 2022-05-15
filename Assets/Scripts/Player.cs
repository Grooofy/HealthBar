    using UnityEngine;
    
    public class Player : MonoBehaviour
    { 
        [SerializeField] private float _heath;
        [SerializeField] private HUD _hud;

        private float _maxHealth;

        private void Start()
        {
            _maxHealth = _heath;
            _hud.SetMaxHeathValue(_maxHealth);
        }

        public void TakeDamage(float damage)
        {
            if (_heath <= 0 )
                Debug.Log("I'm died");
            
            _heath -= damage;
            _hud.ReduceHeathValue(_heath);
        }

        public void Heal(float value)
        {
            if (_heath == _maxHealth)
                return;
            
            if (value + _heath > _maxHealth )
            {
                value = _maxHealth - _heath;
                _heath = _maxHealth;
            }
            _heath += value;
            _hud.AddHeathValue(_heath);
        }
    }
