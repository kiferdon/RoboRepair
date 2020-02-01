using System;
using ScriptableObjects.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    [RequireComponent(typeof(Image))]
    public class VerticalBar : MonoBehaviour {
        public IntVariable current;
        public int max;
        public Color minColor;
        public Color maxColor;
        public AnimationCurve curve;
        public float animationTime;
        public float deltaToAnimate = 0.01f;

        private Image _bar;
        private float _time;

        private void Awake() {
            _bar = GetComponent<Image>();
            _time = animationTime;
        }

        public void Update() {
            _time += Time.deltaTime;
            var newValue = (float)current.value / max;
            if (Math.Abs(_bar.fillAmount - newValue) < deltaToAnimate) {
                _time = 0;
            }

            _bar.fillAmount = Mathf.Lerp(_bar.fillAmount,
                newValue, curve.Evaluate(_time / animationTime));
            _bar.color = Color.Lerp(minColor, maxColor, _bar.fillAmount);
        }
    }
}