using System;

namespace Core.Events
{
    public static class GameEvents
    {
        public static Action OnShotGrabbed;
        public static Action<bool> OnSkillbarResolved;
    }
}