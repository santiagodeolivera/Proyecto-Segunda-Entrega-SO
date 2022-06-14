using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSO.Tests.TimedLock
{
    public class TimedLockEnumerator : IEnumerator<LockAction>
    {
        private bool locked = false;
        private ushort secs = 0;
        private readonly ushort unlockedTime;
        private readonly ushort lockedTime;
        private LockAction current = LockAction.Nothing;

        LockAction IEnumerator<LockAction>.Current => this.current;

        object IEnumerator.Current => this.current;

        public TimedLockEnumerator(ushort unlockedTime, ushort lockedTime)
        {
            this.unlockedTime = unlockedTime;
            this.lockedTime = lockedTime;
        }

        void IDisposable.Dispose()
        { }

        bool IEnumerator.MoveNext()
        {
            this.secs++;
            if (this.locked)
            {
                if (this.secs >= this.lockedTime)
                {
                    this.locked = false;
                    this.secs = 0;
                    this.current = LockAction.Unlock;
                } else
                {
                    this.current = LockAction.Nothing;
                }
            } else
            {
                if (this.secs >= this.unlockedTime)
                {
                    this.locked = true;
                    this.secs = 0;
                    this.current = LockAction.Lock;
                } else
                {
                    this.current = LockAction.Nothing;
                }
            }
            return true;
        }

        void IEnumerator.Reset()
        {
            this.locked = false;
            this.secs = 0;
            this.current = LockAction.Nothing;
        }
    }
}
