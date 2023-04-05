using CommunityToolkit.Mvvm.Messaging;

namespace TestMvvmMessenger;

public class TestService : BackgroundService
{
    readonly PeriodicTimer _periodicTimer = new(TimeSpan.FromSeconds(15));

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _periodicTimer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(10, stoppingToken);
            WeakReferenceMessenger.Default.Send(new TestMessage(DateTime.Now.ToLongDateString()));
            Console.WriteLine("MessageSent");
        }
    }
}
