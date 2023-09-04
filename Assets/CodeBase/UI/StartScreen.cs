using System;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.UI
{
    public class StartScreen : Screen
    {
        public event UnityAction PlayButtonClick;

        public override void Open()
        {
            CanvasGroup.alpha = 1F;
            Button.interactable = true;
        }

        public override void Close()
        {
            CanvasGroup.alpha = 0;
            Button.interactable = false;
        }

        protected override void OnButtonClick()
        {
            PlayButtonClick?.Invoke();
        }
    }
}