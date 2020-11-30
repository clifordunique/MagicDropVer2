using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Common.iOS
{
    public static class SafeArea
    {
#if UNITY_EDITOR
        private static Rect EditorRect = new Rect(0, 102, 1125, 2202);
#endif
        public static Rect Rect =>
#if UNITY_EDITOR
            Screen.width == 1125 && Screen.height == 2436 ? EditorRect : Rect.zero;
#else
            Screen.safeArea;
#endif
    }
    
    [RequireComponent(typeof(Canvas))]
    public class SafeAreaCanvas : MonoBehaviour
    {
        [SerializeField] private Color _safeAreaColor = Color.grey;
        private void Start ()
        {
            ApplySafeArea();
        }

        private void ApplySafeArea()
        {
            if (!(0 < SafeArea.Rect.size.y)) return;
            
            var areaRect = SafeArea.Rect;
            var display = UnityEngine.Display.displays[0];
            var screenSize = new Vector2Int(display.systemWidth, display.systemHeight);

            var anchorMin = areaRect.position;
            var anchorMax = areaRect.position + areaRect.size;
            anchorMin.x = 0;
            anchorMin.y /= screenSize.y;
            anchorMax.x = 1;
            anchorMax.y /= screenSize.y;
            
            var baseTransform = new GameObject("BaseTransfrom").AddComponent<RectTransform>();
            baseTransform.SetParent(transform);
            baseTransform.localScale = Vector3.one;
            baseTransform.anchorMin = Vector2.zero;
            baseTransform.anchorMax = Vector2.one;
            baseTransform.anchoredPosition = Vector3.zero;
            baseTransform.sizeDelta = Vector2.zero;

            var topSafeAreaTransform = Instantiate(baseTransform, transform).GetComponent<RectTransform>();
            var contentsTransform = Instantiate(baseTransform, transform).GetComponent<RectTransform>();
            var bottomSafeAreaTransform = Instantiate(baseTransform, transform).GetComponent<RectTransform>();
            Destroy(baseTransform.gameObject);

            topSafeAreaTransform.name = "TopSafeArea";
            contentsTransform.name = "SafeAreaInnerContents";
            bottomSafeAreaTransform.name = "BottomSafeArea";
            
            Enumerable.Range(0, transform.childCount)
                .Select(i => transform.GetChild(i))
                .Where(t => !t.Equals(topSafeAreaTransform) && !t.Equals(bottomSafeAreaTransform))
                .ToList().ForEach(t => t.SetParent(contentsTransform));
            
            contentsTransform.anchorMin = anchorMin;
            contentsTransform.anchorMax = anchorMax;

            topSafeAreaTransform.anchorMin = new Vector2(0, 0);
            topSafeAreaTransform.anchorMax = new Vector2(1, anchorMin.y);
            
            bottomSafeAreaTransform.anchorMin = new Vector2(0, anchorMax.y);
            bottomSafeAreaTransform.anchorMax = new Vector2(1, 1);

            topSafeAreaTransform.gameObject.AddComponent<RawImage>().color = _safeAreaColor;
            bottomSafeAreaTransform.gameObject.AddComponent<RawImage>().color = _safeAreaColor;
        }
    }
}
