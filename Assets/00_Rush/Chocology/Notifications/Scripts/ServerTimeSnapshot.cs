using System;

namespace Rush.Chocology.Notifications
{
    public readonly struct ServerTimeSnapshot
    {
        public DateTime Value { get; }
        public bool IsReady { get; }

        public ServerTimeSnapshot(DateTime value, bool isReady)
        {
            Value = value;
            IsReady = isReady;
        }
    }
}
