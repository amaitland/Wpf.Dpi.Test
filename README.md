# Wpf.Dpi.Test

The example targets `.Net 4.8.1`, `.Net 6.0 Windows` and `.Net 7.0 Windows`.

DPI Awareness is set via `app.manifest`

When targeting `.Net 6.0` the application remains `System Aware` rather than the expected `PerMonitorV2`.
For the other targets the manifest is set correctly.

Check `DPI Awareness` via `Task Manager`.

```
dotnet --list-sdks
7.0.201 [C:\Program Files\dotnet\sdk]
```