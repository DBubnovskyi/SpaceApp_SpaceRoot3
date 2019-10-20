using UnityEngine;

namespace Assets.Scripts
{
    class Fin
    {
        public Fin(float speed, float max, float center, float min,  GameObject gameObject, Rotator.Axis axis = Rotator.Axis.z)
        {
            Obj = gameObject;
            MaxAngle = max;
            MinAngle = min;
            CentrAngle = center;
            Speed = speed;
            _angle = center;
            _axis = axis;
        }
        public GameObject Obj;
        public float MaxAngle;
        public float MinAngle;
        public float CentrAngle;
        public float Speed;
        float _angle;
        readonly Rotator.Axis _axis;

        public void Down()
        {
            if (_angle > MinAngle)
            {
                _angle -= Speed;
                Rotator.Rotate(Obj,-Speed, _axis);
            }
        }
        public void Up()
        {
            if (_angle < MaxAngle)
            {
                _angle += Speed;
                Rotator.Rotate(Obj, Speed, _axis);
            }
        }
        public void Center()
        {
            if (_angle < CentrAngle)
            {
                _angle += Speed;
                Rotator.Rotate(Obj, Speed, _axis);
            }
            else if (_angle > CentrAngle)
            {
                _angle -= Speed;
                Rotator.Rotate(Obj, -Speed, _axis);
            }
        }
    }
}
