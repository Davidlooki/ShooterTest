using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;
using UnityEngine;

using Managers.controllers;
using Entities.controllers;
using Entities.enums;
using Entities.impl;

using Weapons;
using Weapons.controllers;

namespace Entities.player
{
    public class Player : Entity
    {
        [SerializeField]
        private List<ParticleSystem> propulsionsParticles;

        private Weapon currentWeapon;

        protected InputReaderManager readerInput;

        public override void Awake()
        {
            base.Awake();
            StateType = EntityStateType.LIVE;
        }
        private void Start()
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

        public void ApplyDamage(int _damage)
        {
            if(StateType == EntityStateType.LIVE)
                StateType = EntityStateType.HIT;
            
            Life -= _damage;
            
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

        private void Die()
        {
            StateType = EntityStateType.DIED;
            DisablePropulsion();
            DestroyImmediate(this.gameObject);
        }
    }
}
