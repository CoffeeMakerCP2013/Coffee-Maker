namespace EyeSoft.Net.NetworkInformation
{
	using System;
	using System.Net;
	using System.Threading;

	public static class DnsHelper
	{
		public static IPAddress[] GetHostAddresses(string hostNameOrAddress, int timeout)
		{
			IPAddress[] addresses = null;

			Func<WaitAsyncResult> createWaitAsyncResult =
				() => new WaitAsyncResult((w, r) =>
					{
						try
						{
							addresses = Dns.EndGetHostAddresses(r);
							return true;
						}
						catch
						{
							return false;
						}
					});

			using (var waitAsyncResult = createWaitAsyncResult())
			{
				Dns.BeginGetHostAddresses(hostNameOrAddress, waitAsyncResult.Callback, null);
				waitAsyncResult.Wait(timeout);
				return addresses;
			}
		}

		private class WaitAsyncResult : IDisposable
		{
			private readonly ManualResetEvent waitHandle = new ManualResetEvent(false);

			private readonly Func<WaitAsyncResult, IAsyncResult, bool> callback;

			private int status;

			public WaitAsyncResult(Func<WaitAsyncResult, IAsyncResult, bool> callback)
			{
				if (callback == null)
				{
					throw new ArgumentNullException("callback");
				}

				this.callback = callback;
			}

			~WaitAsyncResult()
			{
				Dispose();
				GC.SuppressFinalize(this);
			}

			private bool Succeed { get; set; }

			public void Dispose()
			{
				Dispose(true);
			}

			public void Callback(IAsyncResult asyncResult)
			{
				try
				{
					Succeed = callback(this, asyncResult);
				}
				finally
				{
					if (0 == Interlocked.CompareExchange(ref status, 2, 0))
					{
						waitHandle.Set();
						Interlocked.Exchange(ref status, 3);
					}
				}
			}

			public void Wait(int timeout)
			{
				if (!waitHandle.WaitOne(timeout) && 0 == Interlocked.CompareExchange(ref status, 1, 0))
				{
					return;
				}

				while (3 != Interlocked.CompareExchange(ref status, 3, 3))
				{
					Thread.SpinWait(1);
				}
			}

			private void Dispose(bool disposing)
			{
				if (disposing)
				{
					waitHandle.Dispose();
				}
			}
		}
	}
}