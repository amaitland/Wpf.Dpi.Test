using PInvoke;
using System.Diagnostics;
using System;

namespace Console.Dpi.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine("Hello, World!");

            System.Console.WriteLine($"NetRuntimeVersion : {Environment.Version.ToString()}");

            var processHandle = Process.GetCurrentProcess().Handle;

            var result = SHCore.GetProcessDpiAwareness(processHandle, out var dpiAwareness);

            if (result == 0)
            {
                System.Console.WriteLine($"ProcessDpiAwareness : {dpiAwareness.ToString()}");
            }
            else
            {
                System.Console.WriteLine("ProcessDpiAwareness : Failed");
            }

            var ctx = User32.GetThreadDpiAwarenessContext();
            var dpiAwarenessCtx = string.Empty;

            if (User32.AreDpiAwarenessContextsEqual(ctx, User32.DPI_AWARENESS_CONTEXT_UNAWARE))
            {
                dpiAwarenessCtx = "DPI_AWARENESS_CONTEXT_UNAWARE";
            }
            else if (User32.AreDpiAwarenessContextsEqual(ctx, User32.DPI_AWARENESS_CONTEXT_SYSTEM_AWARE))
            {
                dpiAwarenessCtx = "DPI_AWARENESS_CONTEXT_SYSTEM_AWARE";
            }
            else if (User32.AreDpiAwarenessContextsEqual(ctx, User32.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE))
            {
                dpiAwarenessCtx = "DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE";
            }
            else if (User32.AreDpiAwarenessContextsEqual(ctx, User32.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2))
            {
                dpiAwarenessCtx = "DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2";
            }
            else if (User32.AreDpiAwarenessContextsEqual(ctx, User32.DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED))
            {
                dpiAwarenessCtx = "DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED";
            }

            System.Console.WriteLine($"ThreadDpiAwarenessContext : {dpiAwarenessCtx}");
        }
    }
}