using System;

namespace Prep1
{
    public struct S : IDisposable
    {
        private bool _dispose;
        public void Dispose()
        {
            _dispose = true;
        }
        public bool GetDispose()
        {
            return _dispose;
        }
    }
}
