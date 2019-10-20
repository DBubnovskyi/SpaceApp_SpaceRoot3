using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    abstract class Aircraft
    {
        public enum FlyMode
        {
            Normal,
            Vertical,
            Space
        }
        virtual public FlyMode Mode { get; set; }
        abstract public void SpeedUp();
        abstract public void SlowDown();
        abstract public void PitchDown();
        abstract public void PitchUp();
        abstract public void RollLeft();
        abstract public void RollRight();
        abstract public void YawLeft();
        abstract public void YawRight();
        abstract public void Normalize();
    }
}
