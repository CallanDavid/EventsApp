# EventsApp

<sub>Documentation drafted with claude.ai</sub>

A console app demonstrating C# events with multiple subscribers.

`TemperatureMonitor` exposes a `TemperatureChanged` event using the generic
`EventHandler<TEventArgs>` pattern, raised from the property setter whenever the
temperature actually changes. Two independent subscribers (`TemperatureAlert` and
`TempCoolingAlert`) attach to it and both fire on a single assignment.

Also shows the older custom-delegate approach (`TemperatureChangeHandler`) alongside
the generic one for comparison.

## Running it

    dotnet run

Enter a temperature when prompted and both subscribers report.
