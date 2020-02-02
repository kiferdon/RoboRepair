using System;
using UnityEngine;
using UnityEngine.UI;

namespace Utility {
    [RequireComponent(typeof(Image))]
    public class ImageAlphaAnimation : MonoBehaviour {
        public float animationTime;
        private Image _image;
        private float _time;

        private void Awake() {
            _image = GetComponent<Image>();
        }

        private void Update() {
            _time += Time.unscaledDeltaTime;
            var color = _image.color;
            color.a = Mathf.Lerp(0, 1, _time / animationTime);
            _image.color = color;
        }
    }
}