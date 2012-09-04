using System.Collections.Generic;
using CodeEditor.Composition;
using Mono.Debugger.Soft;
using UnityEngine;
using Event = Mono.Debugger.Soft.Event;

namespace CodeEditor.Debugger.Unity.Engine
{
	[Export(typeof(IDebuggerWindow))]
	public class ThreadsDisplay : IDebuggerWindow
	{
		private readonly IDebuggerSession _debuggerSession;
		private IThreadProvider _threadProvider;

		[ImportingConstructor]
		public ThreadsDisplay(IDebuggerSession debuggerSession, IThreadProvider threadProvider)
		{
			_debuggerSession = debuggerSession;
			_threadProvider = threadProvider;
		}

		public void OnGUI()
		{
			GUI.enabled = _debuggerSession.Suspended;
			foreach(var thread in _threadProvider.Threads)
			{
				GUILayout.Label("Thread id: "+thread.Id);
			}
		}

		public string Title
		{
			get { return "Threads"; }
		}
	}
}