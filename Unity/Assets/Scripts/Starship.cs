using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class Starship : Aircraft
    {
        private GameObject _main;
        private Fin _finTL;
        private Fin _finTR;
        private Fin _finBL;
        private Fin _finBR;
        private Engine _engine1;
        private Engine _engine2;
        private Engine _engine3;

        private Engine _ttt;
        private Engine _ttr;
        private Engine _ttl;
        private Engine _btt;
        private Engine _btr;
        private Engine _btl;

        private Engine _tbt;
        private Engine _tbr;
        private Engine _tbl;
        private Engine _bbt;
        private Engine _bbr;
        private Engine _bbl;

        private Engine _b1;
        private Engine _b2;

        private Engine _f1;
        private Engine _f2;

        float _speedStearing = 2f;
        float _speedBody = 0.5f;

        float _pitchMax = 30f;
        float _pitchMin = -30f;
        float _pitchAngle = 0f;
        float _pitchCenter { get => 0f; }

        float _rollMax = 30f;
        float _rollMin = -30f;
        float _rollAngle = 0f;
        float _rollCenter { get => 0f; }

        float _yawMax = 30f;
        float _yawMin = -30f;
        float _yawAngle = 0f;
        float _yawCenter { get => 0f; }

        public FlyMode _mode = FlyMode.Normal;
        override public FlyMode Mode {
            get => _mode;
            set
            {
                if (value == FlyMode.Normal)
                {
                }
                if (value == FlyMode.Vertical)
                {
                    _main.transform.localEulerAngles = new Vector3(180, 0, 0);

                    _engine1.Fire(true);
                    _engine2.Fire(true);
                    _engine3.Fire(true);
                }
                else
                {
                    _main.transform.localEulerAngles = new Vector3(270, 0, 0);
                    _engine1.Fire(false);
                    _engine2.Fire(false);
                    _engine3.Fire(false);
                }
                _mode = value;
            }
                
        }
        public Starship(GameObject ship)
        {
            _main = ship;
            _finBL = new Fin(_speedStearing, 90f, 60f, 30f, _main.transform.Find("BottomLeft").gameObject.transform.Find("fin").gameObject);
            _finBR = new Fin(_speedStearing, 150f, 120f, 90f, _main.transform.Find("BottomRight").gameObject.transform.Find("fin").gameObject);
            _finTL = new Fin(_speedStearing, 0f, -30f, -60f, _main.transform.Find("TopLeft").gameObject.transform.Find("fin").gameObject);
            _finTR = new Fin(_speedStearing, 60f, 30f, 0f, _main.transform.Find("TopRight").gameObject.transform.Find("fin").gameObject);
            _engine1 = new Engine(_main.transform.Find("Engine1").gameObject);
            _engine2 = new Engine(_main.transform.Find("Engine2").gameObject);
            _engine3 = new Engine(_main.transform.Find("Engine3").gameObject);

            _ttt = new Engine(_main.transform.Find("TT").gameObject.transform.Find("Engine Top").gameObject);
            _ttr = new Engine(_main.transform.Find("TT").gameObject.transform.Find("Engine Right").gameObject);
            _ttl = new Engine(_main.transform.Find("TT").gameObject.transform.Find("Engine Left").gameObject);
            _btt = new Engine(_main.transform.Find("BT").gameObject.transform.Find("Engine Top").gameObject);
            _btl = new Engine(_main.transform.Find("BT").gameObject.transform.Find("Engine Right").gameObject);
            _btr = new Engine(_main.transform.Find("BT").gameObject.transform.Find("Engine Left").gameObject);

            _tbt = new Engine(_main.transform.Find("TB").gameObject.transform.Find("Engine Top").gameObject);
            _tbr = new Engine(_main.transform.Find("TB").gameObject.transform.Find("Engine Right").gameObject);
            _tbl = new Engine(_main.transform.Find("TB").gameObject.transform.Find("Engine Left").gameObject);
            _bbt = new Engine(_main.transform.Find("BB").gameObject.transform.Find("Engine Top").gameObject);
            _bbl = new Engine(_main.transform.Find("BB").gameObject.transform.Find("Engine Right").gameObject);
            _bbr = new Engine(_main.transform.Find("BB").gameObject.transform.Find("Engine Left").gameObject);

            
            _b1 = new Engine(_main.transform.Find("BT").gameObject.transform.Find("Back").gameObject); ;
            _b2 = new Engine(_main.transform.Find("BB").gameObject.transform.Find("Back").gameObject); ;

            _f1 = new Engine(_main.transform.Find("TT").gameObject.transform.Find("Front").gameObject); ;
            _f2 = new Engine(_main.transform.Find("TB").gameObject.transform.Find("Front").gameObject); ;
        }

        override public void PitchDown()
        {
            if (Mode == FlyMode.Normal)
            {
                _finBL.Up();
                _finBR.Down();

                _finTL.Down();
                _finTR.Up();
                if (_pitchAngle < _pitchMax)
                {
                    _pitchAngle += _speedBody;
                    Rotator.Rotate(_main, new Vector3(_speedBody, 0, 0));
                }
            }
            else if(Mode == FlyMode.Vertical)
            {
                if (_pitchAngle < _pitchMax)
                {
                    _pitchAngle += _speedBody;
                    Rotator.Rotate(_main, new Vector3(_speedBody, 0, 0));
                }
                _engine1.GimbalDown();
                _engine2.GimbalDown();
                _engine3.GimbalDown();
            }
            else if (Mode == FlyMode.Space)
            {
                _ttt.Fire(true);
                _bbt.Fire(true);
                Rotator.Rotate(_main, new Vector3(_speedBody, 0, 0));
            }
        }

        override public void PitchUp()
        {
            if (Mode == FlyMode.Normal)
            {
                if (_pitchAngle > _pitchMin)
                {
                    _pitchAngle -= _speedBody;
                    Rotator.Rotate(_main, new Vector3(-_speedBody, 0, 0));
                }
                _finBL.Down();
                _finBR.Up();

                _finTL.Up();
                _finTR.Down();
            }
            else if (Mode == FlyMode.Vertical)
            {

                if (_pitchAngle > _pitchMin)
                {
                    _pitchAngle -= _speedBody;
                    Rotator.Rotate(_main, new Vector3(-_speedBody, 0, 0));
                }
                _engine1.GimbalUp();
                _engine2.GimbalUp();
                _engine3.GimbalUp();
            }
            else if (Mode == FlyMode.Space)
            {
                _btt.Fire(true);
                _tbt.Fire(true);
                Rotator.Rotate(_main, new Vector3(-_speedBody, 0, 0));
            }
        }

        override public void RollLeft()
        {
            if (Mode == FlyMode.Normal)
            {
                _finBL.Down();
                _finBR.Down();

                _finTL.Down();
                _finTR.Down();


                if (_rollAngle > _rollMin)
                {
                    _rollAngle -= _speedBody * 2;
                    Rotator.Rotate(_main, new Vector3(0, -_speedBody * 2, 0));
                }
            }
            else if (Mode == FlyMode.Vertical)
            {
                if (_yawAngle < _yawMax)
                {
                    _yawAngle += _speedBody * 2;
                    Rotator.Rotate(_main, new Vector3(0, 0, _speedBody * 2));
                }
                _engine1.GimbalLeft();
                _engine2.GimbalLeft();
                _engine3.GimbalLeft();
            }
            else if (Mode == FlyMode.Space)
            {
                _ttr.Fire(true);
                _tbr.Fire(true);
                _btr.Fire(true);
                _bbr.Fire(true);
                Rotator.Rotate(_main, new Vector3(0, 0, -_speedBody));
            }
        }

        override public void RollRight()
        {
            if (Mode == FlyMode.Normal)
            {
                _finBL.Up();
                _finBR.Up();

                _finTL.Up();
                _finTR.Up();

                if (_rollAngle < _rollMax)
                {
                    _rollAngle += _speedBody * 2;
                    Rotator.Rotate(_main, new Vector3(0, _speedBody * 2, 0));
                }
            }
            else if (Mode == FlyMode.Vertical)
            {
                if (_yawAngle > _yawMin)
                {
                    _yawAngle -= _speedBody * 2;
                    Rotator.Rotate(_main, new Vector3(0, 0, -_speedBody * 2));
                }
                _engine1.GimbalRight();
                _engine2.GimbalRight();
                _engine3.GimbalRight();
            }
            else if (Mode == FlyMode.Space)
            {
                _ttl.Fire(true);
                _tbl.Fire(true);
                _btl.Fire(true);
                _bbl.Fire(true);
                Rotator.Rotate(_main, new Vector3(0, 0, _speedBody));
            }
        }

        override public void YawLeft()
        {
            if (Mode == FlyMode.Normal)
            {
                _finBL.Down();
                _finBR.Down();

                _finTL.Up();
                _finTR.Up();
                Rotator.Rotate(_main, new Vector3(0, 0, _speedBody));
            }
            else if (Mode == FlyMode.Vertical)
            {
            }
        }

        override public void YawRight()
        {
            if (Mode == FlyMode.Normal)
            {
                _finBL.Up();
                _finBR.Up();

                _finTL.Down();
                _finTR.Down();
                Rotator.Rotate(_main, new Vector3(0, 0, -_speedBody));
            }
            else if (Mode == FlyMode.Vertical)
            {
            }
        }

        override public void SlowDown()
        {
            if (Mode == FlyMode.Normal)
            {
                _finTL.Up();
                _finTR.Down();
                _finBL.Up();
                _finBR.Down();
            }
            else if (Mode == FlyMode.Vertical)
            {
            }
            else if (Mode == FlyMode.Space)
            {
                _f1.Fire(true);
                _f2.Fire(true);
            }
        }

        override public void SpeedUp()
        {
            if (Mode == FlyMode.Normal)
            {
                _finTL.Down();
                _finTR.Up();
                _finBL.Down();
                _finBR.Up();
            }
            else if (Mode == FlyMode.Vertical)
            {
            }
            else if (Mode == FlyMode.Space)
            {
                _b1.Fire(true);
                _b2.Fire(true);
            }
        }

        override public void Normalize()
        {

            if (Mode == FlyMode.Normal)
            {
                _engine1.Center();
                _engine2.Center();
                _engine3.Center();
                _finBL.Center();
                _finBR.Center();
                _finTL.Center();
                _finTR.Center();

                if (_pitchAngle < _pitchCenter)
                {
                    _pitchAngle += _speedBody;
                    Rotator.Rotate(_main, new Vector3(_speedBody, 0, 0));
                }
                else if (_pitchAngle > _pitchCenter)
                {
                    _pitchAngle -= _speedBody;
                    Rotator.Rotate(_main, new Vector3(-_speedBody, 0, 0));
                }

                if (_rollAngle < _rollCenter)
                {
                    _rollAngle += _speedBody;
                    Rotator.Rotate(_main, new Vector3(0, _speedBody, 0));
                }
                else if (_rollAngle > _rollCenter)
                {
                    _rollAngle -= _speedBody;
                    Rotator.Rotate(_main, new Vector3(0, -_speedBody, 0));
                }
            }
            else if (Mode == FlyMode.Vertical)
            {
                _engine1.Center();
                _engine2.Center();
                _engine3.Center();
                _finTL.Down();
                _finTR.Up();
                _finBL.Down();
                _finBR.Up();
                if (_pitchAngle < _pitchCenter)
                {
                    _pitchAngle += _speedBody;
                    Rotator.Rotate(_main, new Vector3(_speedBody, 0, 0));
                }
                else if (_pitchAngle > _pitchCenter)
                {
                    _pitchAngle -= _speedBody;
                    Rotator.Rotate(_main, new Vector3(-_speedBody, 0, 0));
                }

                if (_yawAngle < _yawCenter)
                {
                    _yawAngle += _speedBody;
                    Rotator.Rotate(_main, new Vector3(0, 0, _speedBody));
                }
                else if (_yawAngle > _rollCenter)
                {
                    _yawAngle -= _speedBody;
                    Rotator.Rotate(_main, new Vector3(0, 0, -_speedBody));
                }
            }
            else if (Mode == FlyMode.Space)
            {
                _ttt.Fire(false);
                _ttr.Fire(false);
                _ttl.Fire(false);
                _btt.Fire(false);
                _btr.Fire(false);
                _btl.Fire(false);

                _tbt.Fire(false);
                _tbr.Fire(false);
                _tbl.Fire(false);
                _bbt.Fire(false);
                _bbr.Fire(false);
                _bbl.Fire(false);

                _b1.Fire(false);
                _b2.Fire(false);

                _f1.Fire(false);
                _f2.Fire(false);
            }
        }
    }
}
