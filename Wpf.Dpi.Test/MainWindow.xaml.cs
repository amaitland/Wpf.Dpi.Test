using PInvoke;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;

namespace Wpf.Dpi.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += OnWindowLoaded;

            NetRuntimeVersion.Text = Environment.Version.ToString();

            var processHandle = Process.GetCurrentProcess().Handle;

            var result = SHCore.GetProcessDpiAwareness(processHandle, out var dpiAwareness);

            ProcessDpiAwareness.Text = result == 0 ? dpiAwareness.ToString() : "Failed";
        }

        //#define DPI_AWARENESS_CONTEXT_UNAWARE              ((DPI_AWARENESS_CONTEXT)-1)
        //#define DPI_AWARENESS_CONTEXT_SYSTEM_AWARE         ((DPI_AWARENESS_CONTEXT)-2)
        //#define DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE    ((DPI_AWARENESS_CONTEXT)-3)
        //#define DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 ((DPI_AWARENESS_CONTEXT)-4)
        //#define DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED    ((DPI_AWARENESS_CONTEXT)-5)

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            var windowHandle = new WindowInteropHelper(this).Handle;

            var ctx = User32.GetWindowDpiAwarenessContext(windowHandle);

            if (User32.AreDpiAwarenessContextsEqual(ctx, new IntPtr(-1)))
            {
                DpiAwarenessContext.Text = "DPI_AWARENESS_CONTEXT_UNAWARE";
            }
            else if (User32.AreDpiAwarenessContextsEqual(ctx, new IntPtr(-2)))
            {
                DpiAwarenessContext.Text = "DPI_AWARENESS_CONTEXT_SYSTEM_AWARE";
            }
            else if (User32.AreDpiAwarenessContextsEqual(ctx, new IntPtr(-3)))
            {
                DpiAwarenessContext.Text = "DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE";
            }
            else if (User32.AreDpiAwarenessContextsEqual(ctx, new IntPtr(-4)))
            {
                DpiAwarenessContext.Text = "DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2";
            }
            else if (User32.AreDpiAwarenessContextsEqual(ctx, new IntPtr(-5)))
            {
                DpiAwarenessContext.Text = "DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED";
            }
        }
    }
}
