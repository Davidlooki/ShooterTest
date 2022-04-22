using System;
using System.Collections.Generic;

using UnityEngine;

using Managers.controllers;
using Entities.controllers;
using Entities.enums;
using Entities.impl;

using Weapons;

namespace Entities.views.player
{
    public class Player : Entity
    {
        [SerializeField]
        private List<ParticleSystem> propulsionsParticles;

        private Weapon currentWeapon;

        protected InputReaderManager readerInput;

        public static event Action OnNotifyPlayerDie;

        private void Start()
        {
            Init();
        }
        public void Init()
        {
            if(StateType != EntityStateType.DIED)
            {
                EnablePropulstion();
                readerInput = new InputReaderManager();
                currentWeapon = this.GetComponent<Weapon>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (StateType == EntityStateType.LIVE)
            {
                Vector3? _receivedDirection = readerInput.GetInputFromKeyboard();
                if (_receivedDirection != null)
                {
                    MoveCommand _moveCommand = new MoveCommand(this, (Vector3)_receivedDirection);
                    _moveCommand.Execute();
                }

                if (currentWeapon != null)
                {
                    currentWeapon.Action();
                }
            }
        }

        protected void EnablePropulstion()
        {
            if (propulsionsParticles != null)
            {
                foreach (ParticleSystem _propulsion in propulsionsParticles)
                {
                    _propulsion.Play();
                }
            }
        }

        protected void DisablePropulsion()
        {
            if (propulsionsParticles != null)
            {
                foreach (ParticleSystem _propulsion in propulsionsParticles)
                {
                    _propulsion.Stop();
                }
            }
        }

        public override void ApplyDamage(int _damage)
        {
            base.ApplyDamage(_damage);
            
            if(UIManager.Instance)
                UIManager.Instance.InGame.SetPlayerLifeBar(Life);
            
            if(Life <= 0)
            {
                Die();
            }
            else
            {
                StateType = EntityStateType.LIVE;
            }
        }

        public override void Die()
        {
            base.Die();
            
            if(OnNotifyPlayerDie != null)
                OnNotifyPlayerDie();

            DisablePropulsion();
            Destroy(this.gameObject);
        }
    }
}
