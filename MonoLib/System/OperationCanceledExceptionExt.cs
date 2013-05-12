using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace System
{
	public class OperationCanceledExceptionExt : OperationCanceledException
	{
		public CancellationToken CancellationToken { get; set; }
		public OperationCanceledExceptionExt (CancellationToken token)
		{
			CancellationToken = token;
		}
	}
}
