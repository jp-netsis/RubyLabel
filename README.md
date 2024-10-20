# Ruby(Furigana) Text Callback

[![日本語はこちら](https://img.shields.io/badge/lang-日本語-red.svg)](README.ja.md)

Depends : https://github.com/jp-netsis/RubyTextAbstractions

Add furigana (ruby) tags to the TextElement inherited object in Unity's UIElement.

The Unity version checked is as follows

```
UnityVer:6000.0.23f1 
```

# Changes

## ver 0.2

Destructive change : new dependency on `jp.netsis.rubytext.abstractions`.
destructive change : change RubyTextElementCallback to a generic class
Add : Added RubyLabel

## ver 0.1

Added : `RubyTextElementCallback`

# Features

## Ruby Label

You can use `<ruby=ice>fire</ruby>` tag or `<r=ice>fire</r>` tag.  Both are the same.
It can also work with double quotes.
`<ruby="ice">fire</ruby>` tag or `<r="ice">fire</r>` tag.

# How To Use

There is a way to install from GitHub.

[Install]

Unity > Window > PackageManager > + > Add package from git url... > Add the followings

+ `https://github.com/jp-netsis/RubyTextAbstractions.git?path=/RubyTextAbstractions/PackageData#v0.1.0`

+ `https://github.com/jp-netsis/RubyLabel.git?path=/Assets/RubyLabel/PackageData#v0.2.0`

[Demo]

The demo project is in the package manager.

## Usage Description

`<ruby=かんじ>漢字</ruby>`

### RubyShowType

RUBY_ALIGNMENT : display characters according to ruby

BASE_ALIGNMENT : display characters according to the original

BASE_NO_OVERRAP_RUBY_ALIGNMENT : Basically, the text is aligned with the original text, but when ruby characters overlap, they are shifted. If the ruby characters exceed the frame, it will be corrected.

### rubyLineHeight

This function allows you to have the same gap even if you don't use ruby.
Empty this string to skip this feature.

# Known Issues

TextMeshPro features that cannot be handled by Label are undeveloped.

# Other

Once TextElement supports ruby tags, this project will be deleted.

# Contribution

All contributions are welcomed. Just make sure you follow the project's code style.  

Contact: netsis.jenomoto@gmail.com

