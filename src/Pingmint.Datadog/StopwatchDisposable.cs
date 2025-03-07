using System.Diagnostics;

namespace Pingmint.Datadog;

internal class StopwatchDisposable : IDisposable
{
    private readonly Action<StopwatchDisposable> action;
    private readonly long startTime;
    private bool isDisposed = false;
    private TimeSpan elapsed;

    public StopwatchDisposable(Action<StopwatchDisposable> action)
    {
        this.action = action;
        this.startTime = Stopwatch.GetTimestamp();
    }

    public void Dispose()
    {
        if (isDisposed) { return; }
        isDisposed = true;
        this.elapsed = Stopwatch.GetElapsedTime(this.startTime);
        this.action(this);
    }

    public TimeSpan Elapsed => this.elapsed;

    public Decimal TotalSeconds => (Decimal)this.elapsed.TotalSeconds;
}
