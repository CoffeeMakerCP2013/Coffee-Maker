namespace EyeSoft.Runtime.InteropServices
{
	using System.Runtime.InteropServices;

	public static class Network
	{
		private static INetworkChecker networkChecker = new NetworkChecker();

		public static bool IsInternetAvailable
		{
			get
			{
				return networkChecker.IsInternetAvailable;
			}
		}

		public static void SetNeworkChecker(INetworkChecker checker)
		{
			networkChecker = checker;
		}

		private class NetworkChecker : INetworkChecker
		{
			bool INetworkChecker.IsInternetAvailable
			{
				get
				{
					int description;
					return InternetGetConnectedState(out description, 0);
				}
			}

			[DllImport("wininet.dll")]
			private static extern bool InternetGetConnectedState(out int description, int reeservedValue);
		}
	}
}