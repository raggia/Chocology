using UnityEngine;
namespace Rush.Chocology.Core
{
    [DefaultExecutionOrder(-32000)]
    public sealed class ChocologyFlowInstaller : MonoBehaviour
    {
        [SerializeField] private Economy.Config m_Economy;
        [SerializeField] private Notifications.GlobalVar m_Notifications;
        private void Awake()
        {
            m_Economy.ActivateRuntime();
            m_Notifications.ActivateRuntime();
        }
    }
}