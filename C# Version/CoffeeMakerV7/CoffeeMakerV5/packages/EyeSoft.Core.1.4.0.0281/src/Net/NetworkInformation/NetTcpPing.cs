namespace EyeSoft.Net.NetworkInformation
{
	using System;
	using System.Linq;
	using System.Net.Sockets;

	public class NetTcpPing : INetTcpPing
	{
		public bool Send(string hostName, int port = 80, bool throwOnError = true, int timeOut = 100)
		{
			try
			{
				var ipAddress = DnsHelper.GetHostAddresses(hostName, timeOut);

				if (ipAddress == null)
				{
					new SocketException(11003).Throw();
				}

				var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				var result = socket.BeginConnect(ipAddress.Single(), port, null, null);

				var success = result.AsyncWaitHandle.WaitOne(timeOut, true);

				return success;
			}
			catch (AggregateException exception)
			{
				if (!throwOnError)
				{
					return false;
				}

				throw exception.GetBaseException();
			}
			catch
			{
				if (!throwOnError)
				{
					return false;
				}

				throw;
			}
		}
	}
}