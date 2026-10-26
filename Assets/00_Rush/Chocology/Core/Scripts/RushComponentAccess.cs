using UnityEngine;
namespace Rush.Chocology.Core
{
    public static class RushComponentAccess
    {
        public static T Resolve<T>(Component owner) where T : class
        {
            owner.TryGetComponent<T>(out var component);
            return component;
        }
        public static T Resolve<T>(GameObject owner) where T : class
        {
            owner.TryGetComponent<T>(out var component);
            return component;
        }
    }
}