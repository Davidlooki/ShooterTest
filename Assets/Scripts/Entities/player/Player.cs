using System.ComponentModel;
using System.Collections.Generic;
using UnityEngine;
using Entities.controllers;
using Entities.enums;
using Entities.impl;
using Weapons;
using Weapons.controllers;
using Persistent;

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
    }
}
