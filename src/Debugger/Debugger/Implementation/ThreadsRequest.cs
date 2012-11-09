using System;
using System.Collections.Generic;
using System.Threading;
using Mono.Debugger.Soft;

namespace CodeEditor.Debugger.Implementation
{
	public class ThreadsRequest
	{
		private IDebuggerSession _session;
		private IList<ThreadMirror> _returnValue = null;
		private bool _ready;

		public ThreadsRequest()
		{
			ThreadPool.QueueUserWorkItem(_ =>
							{
								_returnValue = _session.VM.GetThreads ();
								_ready = true;
							});
		}

		public void Cancel()
		{
			throw new System.NotImplementedException();
		}

		public bool Ready
		{
			get { return _ready; }
		}

		public IList<ThreadMirror> Threads
		{
			get {
				if (!Ready)
					throw new InvalidOperationException();
				return _returnValue;
			}
		}
	}
}
