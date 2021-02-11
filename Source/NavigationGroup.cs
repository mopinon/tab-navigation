using UnityEngine;
using UnityEngine.EventSystems;

namespace Mopinon.TabNavigation
{
    public class NavigationGroup : MonoBehaviour
    {
        private int SelectedElementIndex
        {
            get
            {
                var childCount = transform.childCount;
                for (var i = 0; i < childCount; i++)
                {
                    var child = transform.GetChild(i);
                    if (EventSystem.current.currentSelectedGameObject == child.gameObject)
                        return child.GetSiblingIndex();
                }

                return -1;
            }
        }

        private bool IsSelected => SelectedElementIndex > -1;

        public void NextElement()
        {
            var childCount = transform.childCount;
            for (var i = 1; i <= childCount; i++)
            {
                Debug.Log("current index " + SelectedElementIndex);
                var index = (SelectedElementIndex + i) % childCount;
                var child = transform.GetChild(index);
                if (child.TryGetComponent<NavigationElement>(out var element))
                {
                    element.Select();
                    return;
                }
            }
        }

        public void Select()
        {
            NavigationController.Instance.SetSelectedNavigationGroup(this);
        }
    }
}