using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace UnitTests
{
	public class ExceptionTests
	{
		[Fact]
		public void StackTraceIsFullyPreserved ()
		{
			string trace;
			Exception tex = null;
			try
			{
				Thrower.Throw ();
			}
			catch (MyException ex)
			{
				tex = ex;
			}

			trace = tex.StackTrace;

			try
			{
				Thrower.Rethrow (ExceptionDispatchInfo.Capture (tex));
			}
			catch (MyException ex)
			{
				var newTrace = ex.StackTrace;
				bool cond = newTrace.Contains (trace);
				Assert.True (cond);
			}

		}




	}

	class MyException : Exception
	{
		 
	}

	static class Thrower
	{
		public static void Throw ()
		{
			throw new MyException ();
		}

		public static void Rethrow (ExceptionDispatchInfo nfo)
		{
			nfo.Throw ();
		}

	}
}
