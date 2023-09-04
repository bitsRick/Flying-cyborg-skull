using UnityEngine.Events;

namespace CodeBase.UI
{
    public class GameOverScreen:Screen
    {
        public event UnityAction ResetButtonClick;
  
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
            ResetButtonClick?.Invoke();
        }
    }
}