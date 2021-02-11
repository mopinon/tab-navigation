using UnityEngine;

namespace Mopinon.TabNavigation
{
    public class NavigationInput : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab)) 
                NavigationController.Instance.NextElement();
        }
    }
}