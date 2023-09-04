using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Player;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TMP_Text _score;
        [SerializeField] private Player.Bird _bird;

        private void OnEnable()
        {
            _bird.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            _bird.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int score)
        {
            _score.text = score.ToString();
        }
    }
}
