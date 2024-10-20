using System.Collections.Generic;
using jp.netsis.RubyText.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class RubyLabelDemo : MonoBehaviour
{
    void Start()
    {
        UIDocument uiDocument = this.GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        List<RubyLabel> textElements = root.Query<RubyLabel>().ToList();

        foreach (RubyLabel textElement in textElements)
        {
            textElement.uneditedText = "<ruby=おたまじゃくし>蛞</ruby><ruby=にほんご>日本語</ruby>は<ruby=むずか>難</ruby>しい<ruby=にほんご>日本語</ruby>の<ruby=にほんご>日本語</ruby>による<ruby=にほんご>日本語</ruby>のための<ruby=にほんご>日本語</ruby>ですルビテスト";
        }
    }

    // Update is called once per frame
    void OnDestroy()
    {
        UIDocument uiDocument = this.GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        List<RubyLabel> textElements = root.Query<RubyLabel>().ToList();
        foreach (RubyLabel textElement in textElements)
        {
            textElement.Dispose();
        }
    }
}
