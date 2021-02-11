using UnityEngine;

namespace Mopinon.TabNavigation
{
    public class NavigationController : MonoBehaviour
    {
        private static NavigationController _instance;

        private NavigationGroup _selectedNavigationGroup;

        public static NavigationController Instance
        {
            get
            {
                if (!_instance)
                    SetupInstance();

                return _instance;
            }
        }

        private static void SetupInstance()
        {
            var instances = FindObjectsOfType<NavigationController>();
            if (instances.Length == 0)
                throw new MissingComponentException(
                    $"Component with type {typeof(NavigationController)} not found in the scene");
            _instance = instances[0];
            for (var i = 1; i < instances.Length; i++)
                Destroy(instances[i]);
        }

        public void NextElement()
        {
            _selectedNavigationGroup.NextElement();
        }

        public void SetSelectedNavigationGroup(NavigationGroup navigationGroup) 
            => _selectedNavigationGroup = navigationGroup;
    }
}