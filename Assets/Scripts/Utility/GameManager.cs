using System;
using UnityEngine;

namespace Utility {
    public class GameManager : Singleton<GameManager> {
        public AudioSource music;
        public AudioSource sounds;
        public AudioClip attach;
        public AudioClip detach;
        public AudioClip wrong;

        private void Start() {
            music.Play();
        }

        public void PlayAttach() {
            sounds.PlayOneShot(attach);
        }

        public void PlayDetach() {
            sounds.PlayOneShot(detach);
        }

        public void PlayWrong() {
            sounds.PlayOneShot(wrong);
        }
    }
}