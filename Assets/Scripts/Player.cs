    using UnityEngine;
    using UnityEngine.Events;

    public class Player : MonoBehaviour
    { 
        [SerializeField] private float _heath;

        public event UnityAction<float> HealthEstablished;
        public event UnityAction<float> HealthIncreased;
        public event UnityAction<float> HealthDecreased;
        
        private float _maxHealth;
        
        private void Start()
        {
            _maxHealth = _heath;
            HealthEstablished?.Invoke(_maxHealth);
        }

        public void TakeDamage(float damage)
        {
            if (_heath <= 0 )
                Debug.Log("I'm died");
            
            _heath -= damage;
            HealthDecreased?.Invoke(_heath);
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
            HealthIncreased?.Invoke(_heath);
        }
    }
