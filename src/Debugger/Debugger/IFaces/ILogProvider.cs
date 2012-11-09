namespace Debugger.Backend
{
	public class Wrapper : IWrapper
	{
		private readonly object _obj;

		public Wrapper(object obj)
		{
			_obj = obj;
		}

		public T Unwrap<T>() where T : class
		{
			return _obj as T;
		}
	}
}
