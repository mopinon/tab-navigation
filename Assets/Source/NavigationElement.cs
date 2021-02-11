using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Mopinon.TabNavigation
{
    public class NavigationElement : MonoBehaviour, ISelectHandler
    {
        public void Select()
        {
            var selectable = GetComponent<Selectable>();
            selectable.Select();
        }

        public void OnSelect(BaseEventData eventData)
        {
            var navigationGroup = transform.parent.GetComponent<NavigationGroup>();
            navigationGroup.Select();
        }
    }
}