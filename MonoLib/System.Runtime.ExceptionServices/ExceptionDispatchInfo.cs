using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System.Runtime.ExceptionServices
{
	public sealed class ExceptionDispatchInfo
	{
		readonly Exception _exception;
		readonly object _source;
		readonly string _stackTrace;
		
		const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;
		static readonly FieldInfo RemoteStackTrace = typeof (Exception).GetField ("_remoteStackTraceString", PrivateInstance);
		static readonly FieldInfo Source = typeof (Exception).GetField ("_source", PrivateInstance);
		static readonly MethodInfo InternalPreserveStackTrace = typeof (Exception).GetMethod ("InternalPreserveStackTrace", PrivateInstance);
		
		private ExceptionDispatchInfo (Exception source)
		{
			_exception = source;
			_stackTrace = _exception.StackTrace + Environment.NewLine;
			_source = Source.GetValue (_exception);
		}

		public Exception SourceException { get { return _exception; } }

		public static ExceptionDispatchInfo Capture (Exception source)
		{
			if (source == null)
				throw new ArgumentNullException ("source");

			return new ExceptionDispatchInfo (source);
		}

		public void Throw ()
		{
			try
			{
				throw _exception;
			}
			catch
			{
				InternalPreserveStackTrace.Invoke (_exception, new object[0]);
				RemoteStackTrace.SetValue (_exception, _stackTrace);
				Source.SetValue (_exception, _source);
				throw;
			}
		}
	}
}