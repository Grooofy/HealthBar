using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _heal;
    [SerializeField] private float _damage;

    public void HealPlayer() => _player.Heal(_heal);
    
    public void HitPlayer() => _player.TakeDamage(_damage);
}
