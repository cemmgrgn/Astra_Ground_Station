# Astra Ground Station

Windows desktop ground station for a rocketry telemetry system. Reads live
telemetry over three independent serial links (rocket, payload, and a
horizon-indicator unit), parses the CSV telemetry frames, and renders it as
an artificial horizon and a rocket angle indicator alongside raw readouts.

Built with C# / WinForms, .NET 8.

## What it does

- Connects to up to three serial devices at once (rocket, payload, HYI),
  each with its own configurable port/baud rate
- Parses incoming CSV telemetry lines into structured fields
- Renders an artificial horizon and a rocket angle/attitude indicator that
  update live as data arrives
- A separate test station view for bench-testing without live hardware

## Running it

Open `Astra_Ground_Station.sln` in Visual Studio (or `dotnet build`), .NET 8
SDK required. Windows only (WinForms).

## License

MIT — see [LICENSE.txt](LICENSE.txt).
