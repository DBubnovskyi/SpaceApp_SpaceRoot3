using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    static class Rotator
    {
        public enum Axis
        {
            x, y, z
        }
        public static void Rotate(GameObject gameObject, float speed, Axis axis)
        {
            gameObject.transform.Rotate(SetVector(axis, speed));
        }
        public static void Rotate(GameObject gameObject, Vector3 vector)
        {
            gameObject.transform.Rotate(vector);
        }
        static Vector3 SetVector(Axis v, float speed)
        {
            if (v == Axis.x)
                return new Vector3(speed, 0, 0);
            else if (v == Axis.y)
                return new Vector3(0, speed, 0);
            else if (v == Axis.z)
                return new Vector3(0, 0, speed);
            else
                return new Vector3(0, 0, speed);
        }
    }
}
