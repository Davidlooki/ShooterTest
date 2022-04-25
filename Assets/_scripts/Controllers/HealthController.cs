using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;
using CMGA.Shooter.Managers;

namespace CMGA.Shooter.Controllers{
    public class HealthController : MonoBehaviour
    {
        public float MaxHp = 100;
        public UnityEvent OnDeath;
        public UnityEvent OnTakeDamage;
        public UnityEvent<float, float> OnHealthChange;
        public UnityEvent OnInvincibilityStart;
        public UnityEvent OnInvincibilityFinish;
        public bool enableInvincibility = false;
        public bool DestroyOnNoLife = true;
        
        private float _curHp;
        private bool _invincible;

        private void Start(){
            Init();
        }

        public void Init(){
            _curHp = MaxHp;
            HealthChanged();
        }
        public void TakeDamage(float dmg){
            if(_invincible) return;
            OnTakeDamage?.Invoke();
            _curHp -= dmg;
            if(_curHp <= 0){
                _curHp = 0;
                OnDeath?.Invoke();
                if(DestroyOnNoLife){
                    Destroy(this.gameObject);
                }
            } else {
                if(enableInvincibility){
                    SetInvincibilityON();
                }
            }
            HealthChanged();
        }

        public void Heal(float hp){
            _curHp += hp;
            if(_curHp > MaxHp) {
                _curHp = MaxHp;
            }
            HealthChanged();
        }

        private void SetInvincibilityON(){
            _invincible = true;
            OnInvincibilityStart?.Invoke();
            Invoke(nameof(SetInvincibilityOFF), GameManager.Instance.InvincibilityDuration);
        }

        private void SetInvincibilityOFF(){
            _invincible = false;
            OnInvincibilityFinish?.Invoke();

        }

        private void HealthChanged(){
            OnHealthChange?.Invoke(MaxHp, _curHp);
        }

        #region Tests
        [Button("Take10Dmg")]
        private void Take10Dmg(){
            TakeDamage(10);
        }

        [Button("Heal9Hp")]
        private void Heal9Hp(){
            Heal(9);
        }
        #endregion
    }
}

