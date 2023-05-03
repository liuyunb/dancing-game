using System;

namespace Utilities
{
    public static class EventUtility
    {
        public static event Action<int> GetConfirmKey;

        public static void OnGetConfirmKey(int option)
        {
            GetConfirmKey?.Invoke(option);
        }

        public static event Action WaveFinish;

        public static void OnWaveFinish()
        {
            WaveFinish?.Invoke();
        }
    }
}