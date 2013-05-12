using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MonoLib.Async
{
	public static class Extensions
	{
		public static Task<int> ReadAsync (this Stream source, byte[] buffer, int offset, int count)
		{
			return Task<int>.Factory.FromAsync (source.BeginRead, source.EndRead,
			buffer, offset, count, null);
		}
		
		public static Task WriteAsync (this Stream destination, byte[] buffer, int offset, int count)
		{
			return Task.Factory.FromAsync (
			destination.BeginWrite, destination.EndWrite,
			buffer, offset, count, null);
		}

		public static async Task CopyToAsync (this Stream source, Stream destination, int bufferSize = 0x1000)
		{
			var buffer = new byte[bufferSize];
			int bytesRead;
			while ((bytesRead = await source.ReadAsync (buffer, 0, buffer.Length)) > 0)
			{
				await destination.WriteAsync (buffer, 0, bytesRead);
			}
		}

		static Task<T> FromAsync<T> (Func<AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, T> end)
		{
			return Task.Factory.FromAsync<T> (begin, end, null);
		}

		public static Task<Stream> GetRequestStreamAsync (this WebRequest req)
		{
			return FromAsync (req.BeginGetRequestStream, req.EndGetRequestStream);
		}

		public static Task<WebResponse> GetResponseAsync (this WebRequest req)
		{
			return FromAsync (req.BeginGetResponse, req.EndGetResponse);
		}

		public static Task<byte[]> DownloadDataAsync2 (this WebClient wc, Uri address)
		{
			var token = new object ();
			var task = new TaskCompletionSource<byte[]> ();
			DownloadDataCompletedEventHandler handler = null;
			handler = (s, e) =>
			{
				wc.DownloadDataCompleted -= handler;
				if (e.Error != null) task.TrySetException (e.Error);
				else if (e.Cancelled) task.TrySetCanceled ();
				else task.TrySetResult (e.Result);
			};
			wc.DownloadDataCompleted += handler;
			wc.DownloadDataAsync (address, token);
			return task.Task;
		}

		public static Task<string> DownloadStringAsync2 (this WebClient wc, Uri address)
		{
			var token = new object ();
			var task = new TaskCompletionSource<string> ();
			DownloadStringCompletedEventHandler handler = null;
			handler = (s, e) =>
			{
				wc.DownloadStringCompleted -= handler;
				if (e.Error != null) task.TrySetException (e.Error);
				else if (e.Cancelled) task.TrySetCanceled ();
				else task.TrySetResult (e.Result);
			};
			wc.DownloadStringCompleted += handler;
			wc.DownloadStringAsync (address, token);
			return task.Task;
		}
	}
}
