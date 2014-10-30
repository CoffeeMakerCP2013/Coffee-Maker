namespace EyeSoft.Runtime.InteropServices
{
	using System.Runtime.InteropServices;

	public static class NativeMethods
	{
		public static class User32
		{
			public const int Show = 5;
			public const int Restore = 9;

			[DllImport("User32.dll")]
			public static extern int GetForegroundWindow();

			[DllImport("User32.dll")]
			public static extern int SetForegroundWindow(int handle);

			[DllImport("user32.dll")]
			public static extern int GetWindowThreadProcessId(int window, int processId);

			[DllImport("User32.dll")]
			public static extern int AttachThreadInput(int idAttach, int idAttachTo, int fAttach);

			[DllImport("User32.dll")]
			public static extern int IsIconic(int handle);

			[DllImport("User32.dll")]
			public static extern int ShowWindow(int handle, int showMode);

			[DllImport("User32.dll")]
			public static extern int SetActiveWindow(int handle);

			[DllImport("User32.dll")]
			public static extern int BringWindowToTop(int handle);
		}
	}
}