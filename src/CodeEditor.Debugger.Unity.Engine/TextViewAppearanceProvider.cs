using CodeEditor.Composition;
using CodeEditor.Text.UI.Unity.Engine;
using UnityEngine;

namespace CodeEditor.Debugger.Unity.Engine
{
	[Export(typeof(ITextViewAppearanceProvider))]
	class TextViewAppearanceProvider : ITextViewAppearanceProvider
	{
		public ITextViewAppearance AppearanceFor(ITextViewDocument document)
		{
			return new TextViewAppearance();
		}
	}

	public class TextViewAppearance : ITextViewAppearance
	{
		private readonly GUIStyle _background;
		private readonly GUIStyle _text;
		private readonly GUIStyle _lineNumber;
		private readonly Color _lineNumberColor;

		public TextViewAppearance()
		{
			_background = new GUIStyle();

			_text = new GUIStyle(_background)
			{
				fontSize = 14,
				richText = true,
				alignment = TextAnchor.UpperLeft,
				padding = { left = 0, right = 0 }
			};
			_text.normal.textColor = Color.white;

			_lineNumber = new GUIStyle(_text)
			{
				richText = false,
				alignment = TextAnchor.UpperRight
			};
			_lineNumberColor = new Color(1, 1, 1, 0.5f);
		}

		public GUIStyle Background
		{
			get { return _background; }
		}

		public GUIStyle Text
		{
			get { return _text; }
		}

		public GUIStyle LineNumber
		{
			get { return _lineNumber; }
		}

		public Color LineNumberColor
		{
			get { return _lineNumberColor; }
		}
	}
}
