using System;
using System.Collections.Generic;

using UnityEngine.UIElements;

namespace jp.netsis.RubyText.UIElements
{
    public class RubyLabelRegistry : IDisposable
    {
        private List<RubyLabel> elements = new List<RubyLabel>();
        
        public void Regist(RubyLabel textElement)
        {
            this.elements.Add(textElement);
        }

        public bool Unregist(RubyLabel textElement)
        {
            return this.elements.Remove(textElement);
        }

        public void Dispose()
        {
            foreach (RubyLabel textElement in this.elements)
            {
                textElement.Dispose();
            }
            
            this.elements.Clear();
        }
    }
}