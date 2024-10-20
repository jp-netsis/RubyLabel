using System;
using jp.netsis.RubyText;
using UnityEngine.UIElements;

namespace jp.netsis.RubyText.UIElements
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class RubyTextElementCallback<T> : IDisposable where T : TextElement, IRubyText
    {
        private const string CTOR_ARGS_ERROR = "The argument specified is not appropriate.";

        private IVisualElementScheduledItem changeEventScheduledItem;

        private string uneditedText;
        private long intervalMs;

        public T textElement { get; private set; }

        public RubyTextElementCallback(T rubyTextElement, long intervalMs = 5)
        {
            if (rubyTextElement == null)
            {
                throw new ArgumentException(CTOR_ARGS_ERROR);
            }
            
            this.textElement = rubyTextElement;
            this.textElement.RegisterCallback<ChangeEvent<string>>(this.OnChangeEvent);
            this.intervalMs = intervalMs;
        }

        private void OnChangeEvent(ChangeEvent<string> onChangeEvent)
        {
            this.uneditedText = onChangeEvent.newValue;

            // TODO : Searching for a better way
            this.changeEventScheduledItem = this.textElement.schedule.Execute(
                () =>
                {
                    // Uninitialized state is font size 0.
                    if (this.textElement.resolvedStyle.fontSize == 0)
                    {
                        return;
                    }
                    
                    this.OnTextChanged();
                    this.changeEventScheduledItem.Pause();
                }).Every(this.intervalMs);
        }

        public void OnTextChanged()
        {
            string replacedText = this.ReplaceRubyTags(this.uneditedText);

            if (this.textElement is INotifyValueChanged<string> notifyValueChanged)
            {
                notifyValueChanged.SetValueWithoutNotify(replacedText);
            }
        }

        /// <summary>
        /// replace ruby tags.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>replaced str</returns>
        private string ReplaceRubyTags(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            // Replace <ruby> tags text layout.
            float nonBreakSpaceW = this.textElement.GetPreferredValues("\u00A0a").x - this.textElement.GetPreferredValues("a").x;
            float hiddenSpaceW = nonBreakSpaceW * this.textElement.rubyScale;
            float fontSizeScale = 1f;

            int dir = this.textElement.isRightToLeftText ? -1 : 1;
            str = this.textElement.ReplaceRubyTags(str, dir, fontSizeScale, hiddenSpaceW);

            return str;
        }
        
        public void Dispose()
        {
            if (this.textElement != null)
            {
                this.textElement.UnregisterCallback<ChangeEvent<string>>(this.OnChangeEvent);
            }
            this.textElement = null;
        }
    }
}
