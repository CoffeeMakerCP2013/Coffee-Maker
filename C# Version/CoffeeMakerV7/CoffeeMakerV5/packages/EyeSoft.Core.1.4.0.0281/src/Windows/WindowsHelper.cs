namespace EyeSoft.Windows
{
	using EyeSoft.Runtime.InteropServices;

	public static class WindowsHelper
	{
		public static bool ForceForegroundWindow(int handle)
		{
			var foregroundWnd = NativeMethods.User32.GetForegroundWindow();

			if (handle == foregroundWnd)
			{
				return true;
			}

			int ret;

			var threadId1 = NativeMethods.User32.GetWindowThreadProcessId(foregroundWnd, 0);
			var threadId2 = NativeMethods.User32.GetWindowThreadProcessId(handle, 0);

			if (threadId1 != threadId2)
			{
				NativeMethods.User32.AttachThreadInput(threadId1, threadId2, 1);
				ret = NativeMethods.User32.SetForegroundWindow(handle);
				NativeMethods.User32.AttachThreadInput(threadId1, threadId2, 0);
			}
			else
			{
				ret = NativeMethods.User32.SetForegroundWindow(handle);
			}

			var showWindowMode =
				NativeMethods.User32.IsIconic(handle) == 0 ? NativeMethods.User32.Restore : NativeMethods.User32.Show;

			NativeMethods.User32.ShowWindow(handle, showWindowMode);
			NativeMethods.User32.SetActiveWindow(handle);
			NativeMethods.User32.BringWindowToTop(handle);

			return ret != 0;
		}
	}
}