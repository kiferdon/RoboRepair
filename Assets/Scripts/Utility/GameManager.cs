using System;
using ScriptableObjects.Variables;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility {
    public class GameManager : Singleton<GameManager> {
        [Header("Audio")] public AudioSource music;
        public AudioSource sounds;
        public AudioClip attach;
        public AudioClip detach;
        public AudioClip wrong;
        [Header("Pause")] public GameObject pausePanel;
        public GameObject winPanel;
        public GameObject losePanel;

        private bool _isEnded;

        private void Start() {
            Time.timeScale = 0;
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

        public void Pause() {
            if (pausePanel.activeSelf) {
                pausePanel.SetActive(false);
                Time.timeScale = 1;
            }
            else {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }

        public void StartGame() {
            music.Play();
            Time.timeScale = 1;
        }

        public void SetSound(float value) {
            sounds.volume = value;
            sounds.PlayOneShot(attach);
        }

        public void SetMusic(float value) {
            music.volume = value;
        }

        public void Win() {
            _isEnded = true;
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void Lose() {
            _isEnded = true;
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void Restart() {
            if (_isEnded) {
                SceneManager.LoadScene("SampleScene");
            }
        }

        public void Exit() {
            Application.Quit();
        }
    }
}