using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class LuminarisStarship : Aircraft
    {
        private GameObject _main;
        Engine _left;
        Engine _right;
        float _speedBody = 0.5f;
        public LuminarisStarship(GameObject gameObject)
        {
            _main = gameObject;
            _left = new Engine(_main.transform.Find("Engine L").gameObject);
            _right = new Engine(_main.transform.Find("Engine R").gameObject);
        }
        public override void PitchDown()
        {
            //throw new NotImplementedException();
        }

        public override void PitchUp()
        {
            //throw new NotImplementedException();
        }

        public override void RollLeft()
        {
            //throw new NotImplementedException();
        }

        public override void RollRight()
        {
            //throw new NotImplementedException();
        }

        public override void SlowDown()
        {
            //throw new NotImplementedException();
        }

        public override void SpeedUp()
        {
            //throw new NotImplementedException();
        }

        public override void YawLeft()
        {
            _right.Fire(true);
            Rotator.Rotate(_main, new Vector3(0, 0, -_speedBody));
        }

        public override void YawRight()
        {
            _left.Fire(true);
            Rotator.Rotate(_main, new Vector3(0, 0, _speedBody));
        }

        public override void Normalize()
        {
            _left.Fire(false);
            _right.Fire(false);
        }
    }
}
