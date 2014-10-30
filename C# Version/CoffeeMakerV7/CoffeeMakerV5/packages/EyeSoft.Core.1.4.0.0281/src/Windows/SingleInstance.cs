namespace EyeSoft.Windows
{
	using System;
	using System.Diagnostics;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices;
	using System.Security;
	using System.Security.Permissions;
	using System.Threading;

	public static class SingleInstance
	{
		private static Mutex mutex;

		public static bool IsAlreadyRunning(
			this Assembly assembly, Action shutdown = null, Process mainProcess = null)
		{
			var applicationInstanceId = assembly.GetApplicationInstanceId();

			mutex = new Mutex(true, applicationInstanceId);

			if (mutex.WaitOne(0, true))
			{
				return false;
			}

			var assemblyName = assembly.GetName().Name;

			if (mainProcess == null)
			{
				mainProcess = Process.GetCurrentProcess();
			}

			var singleInstanceProcess = FindSingleInstanceProcess(mainProcess, assemblyName);

			var handle = singleInstanceProcess.MainWindowHandle.ToInt32();
			WindowsHelper.ForceForegroundWindow(handle);

			if (shutdown != null)
			{
				shutdown();
			}

			return true;
		}

		private static Process FindSingleInstanceProcess(Process mainProcess, string assemblyName)
		{
			return Process
				.GetProcesses()
				.Single(process =>
					process.ProcessName.Replace(".vshost", null) == assemblyName &&
					process.MainWindowHandle != mainProcess.MainWindowHandle);
		}

		[SecurityCritical]
		private static string GetApplicationInstanceId(this Assembly entry)
		{
			var set = new PermissionSet(PermissionState.None);
			set.AddPermission(new FileIOPermission(PermissionState.Unrestricted));
			set.AddPermission(new SecurityPermission(SecurityPermissionFlag.UnmanagedCode));
			set.Assert();

			var typeLibGuidForAssembly = Marshal.GetTypeLibGuidForAssembly(entry);
			var strArray = entry.GetName().Version.ToString().Split(".".ToCharArray());
			PermissionSet.RevertAssert();

			return typeLibGuidForAssembly + strArray[0] + "." + strArray[1];
		}
	}
}