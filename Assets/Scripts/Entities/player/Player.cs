using System.ComponentModel;
using System.Collections.Generic;
using UnityEngine;
using Entities.controllers;
using Entities.enums;
using Entities.impl;
using Persistent;

namespace Entities.player
{
    public class Player : Entity
    {
        [DescriptionAttribute("Particle Systems to play when the spaceship is flying")]
        [SerializeField]
        private List<ParticleSystem> propulsionsParticles;

        protected InputReaderManager readerInput;

        public override void Awake() 
        {
            base.Awake();

            readerInput = new InputReaderManager();
        }

        private void Start() 
        {
            EnablePropulstion();    
        }

        // Update is called once per frame
        void Update()
        {
            Vector3? _receivedDirection = readerInput.GetInputFromKeyboard();
            if(_receivedDirection != null)
            {
                MoveCommand _moveCommand = new MoveCommand(this, (Vector3)_receivedDirection);
                _moveCommand.Execute();
            }
        }

        protected void EnablePropulstion()
        {
            if(propulsionsParticles != null)
            {
                foreach(ParticleSystem _propulsion in propulsionsParticles)
                {
                    _propulsion.Stop();
                }
            }
        }

        protected void DisablePropulsion()
        {
            if(propulsionsParticles != null)
            {
                foreach(ParticleSystem _propulsion in propulsionsParticles)
                {
                    _propulsion.Stop();
                }
            }
        }
    }
}
