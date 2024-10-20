using System;
using jp.netsis.RubyTextCallback;
using UnityEngine;
using UnityEngine.UIElements;

namespace jp.netsis.RubyText.UIElements
{
    [UxmlElement("RubyLabel")]
    public partial class RubyLabel : Label, IRubyText, IDisposable
    {
        private RubyTextElementCallback<RubyLabel> callback;
        private string _uneditedText;

        public RubyLabel() : this(String.Empty)
        {
        }

        public RubyLabel(string labelText) : base(labelText)
        {
            this.callback = new RubyTextElementCallback<RubyLabel>(this);
        }

        [UxmlAttribute]
        public string uneditedText
        {
            get => this._uneditedText;
            set
            {
                this._uneditedText = value;
                ((INotifyValueChanged<string>)this).value = this.uneditedText;
            }
        }

        #region IRubyText Implementation

        [UxmlAttribute] public bool enableAutoSizing { get; set; } = false; // TODO : unsupported
        [UxmlAttribute] public bool isOrthographic { get; set; } = true; // TODO : unsupported

        // TODO : unsupported
        [UxmlAttribute] public bool isRightToLeftText { get; set; }

        public Vector2 GetPreferredValues(string str)
        {
            return this.MeasureTextSize(str,
                0, MeasureMode.Undefined,
                0, MeasureMode.Undefined);
        }

        [field: Tooltip("v offset ruby. (em, px, %).")]
        [UxmlAttribute]
        public string rubyVerticalOffset { get; set; } = "1em";

        [field: Tooltip("ruby scale. (1=100%)")]
        [UxmlAttribute]
        public float rubyScale { get; set; } = 0.5f;

        [field: Tooltip("The height of the ruby line can be specified. (em, px, %).")]
        [UxmlAttribute]
        public string rubyLineHeight { get; set; } = "";

        [field: Tooltip("ruby show type.")]
        [UxmlAttribute]
        public RubyTextConstants.RubyShowType rubyShowType { get; set; } = RubyTextConstants.RubyShowType.RUBY_ALIGNMENT;

        [field: Tooltip("Affects only BASE_NO_OVERRAP_RUBY_ALIGNMENT ruby margin.")]
        [UxmlAttribute]
        public float rubyMargin { get; set; } = 10;

        #endregion // IRubyText Implementation

        #region IDisposable Implementation
        
        public void Dispose()
        {
            this.callback?.Dispose();
        }

        #endregion // IDisposable Implementation
    }
}