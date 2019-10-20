using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class Engine
    {
        GameObject _main;
        GameObject _fire;
        static float MAX = 20f;
        float _gimbalVerticalMax = MAX;
        float _gimbalVerticalMin = -MAX;
        float _gimbalHorisontalMax = MAX;
        float _gimbalHorisontalMin = -MAX;
        float _centerVertical = 0f;
        float _centerHorisontal = 0f;
        float _axisHorisontal = 0f;
        float _axisVertical = 0f;
        public float Speed = 2f;
        public Engine(GameObject gameObject)
        {
            _main = gameObject;
            _fire = _main.transform.Find("fire").gameObject;
        } 
        public void GimbalUp()
        {
            if (_axisVertical < _gimbalVerticalMax)
            {
                _axisVertical += Speed;
                Rotator.Rotate(_main, new Vector3(Speed, 0, 0));
            }
        }
        public void GimbalDown()
        {
            if (_axisVertical > _gimbalVerticalMin)
            {
                _axisVertical -= Speed;
                Rotator.Rotate(_main, new Vector3(-Speed, 0, 0));
            }
        }
        public void GimbalLeft()
        {
            if (_axisHorisontal < _gimbalHorisontalMax)
            {
                _axisHorisontal += Speed;
                Rotator.Rotate(_main, new Vector3(0, 0, Speed));
            }
        }
        public void GimbalRight()
        {
            if (_axisHorisontal > _gimbalHorisontalMin)
            {
                _axisHorisontal -= Speed;
                Rotator.Rotate(_main, new Vector3(0, 0, -Speed));
            }
        }
        public void Fire(bool state)
        {
            _fire.SetActive(state);
        }

        public void Center()
        {
            if (_axisVertical < _centerVertical)
            {
                _axisVertical += Speed;
                Rotator.Rotate(_main, new Vector3(Speed, 0, 0));
            }
            else if (_axisVertical > _centerVertical)
            {
                _axisVertical -= Speed;
                Rotator.Rotate(_main, new Vector3(-Speed, 0, 0));
            }

            if (_axisHorisontal < _centerHorisontal)
            {
                _axisHorisontal += Speed;
                Rotator.Rotate(_main, new Vector3(0, 0, Speed));
            }
            else if (_axisHorisontal > _centerHorisontal)
            {
                _axisHorisontal -= Speed;
                Rotator.Rotate(_main, new Vector3(0, 0, -Speed));
            }
        }
    }
}
