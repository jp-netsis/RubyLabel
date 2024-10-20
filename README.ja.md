# Ruby(Furigana) Label

[![English is here](https://img.shields.io/badge/lang-english-blue.svg)](README.md)

依存 : https://github.com/jp-netsis/RubyTextAbstractions

UnityのUIElementのLabelに振り仮名(ふりがな、フリガナ、ルビ)タグを追加します。

チェックしたUnityバージョンは以下の通りです。

```
UnityVer:6000.0.23f1 
```

# Changes

## ver 0.2

破壊的変更 : 新たに `jp.netsis.rubytext.abstractions` に依存するよう修正
破壊的変更 : RubyTextElementCallbackをGenericなクラスに変更
追加 : RubyLabelを追加

## ver 0.1

追加 : `RubyTextElementCallback`

# Features

## Ruby Label

あなたは`<ruby=にほんご>日本語</ruby>`タグもしくは省略した`<r=にほんご>日本語</r>`タグを使用できます。
また、半角ダブルクォーテーションで囲っても動作します。
`<ruby="にほんご">日本語</ruby>`タグも`<r="にほんご">日本語</r>`タグもOKです。

# How To Use

GitHubからインストールをすることが可能です。

[Install]

Unity > Window > PackageManager > + > Add package from git url... > 以下を追加

+ `https://github.com/jp-netsis/RubyTextAbstractions.git?path=/RubyTextAbstractions/PackageData#v0.1.0`

+ `https://github.com/jp-netsis/RubyLabel.git?path=/Assets/RubyLabel/PackageData#v0.2.0`

[Demo]

パッケージマネージャにデモプロジェクトが入っています。

## Usage Description

`<ruby=かんじ>漢字</ruby>`

## RubyShowType

RUBY_ALIGNMENT : ルビに合わせて文字を表示します

BASE_ALIGNMENT : 元の文字に合わせて文字を表示します

BASE_NO_OVERRAP_RUBY_ALIGNMENT : 基本は元の文字に合わせて文字を表示しますが、ルビが重なりあうときはずらします。また、枠内をルビがはみ出す場合も補正します。

## rubyLineHeight

この機能により、rubyを使用しない場合でも、同じ隙間を持つことができます。
この文字列を空にすることで、この機能はスキップされます。

# Known Issues

TextMeshProの機能でLabelで対応できない部分は未開発状態です。

# Other

TextElement がルビタグに対応したらこのプロジェクトは削除します。

# Contribution

すべての貢献を歓迎します。必ずプロジェクトのコードスタイルに従ってください。

Contact: netsis.jenomoto@gmail.com

