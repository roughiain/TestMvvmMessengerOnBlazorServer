using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace TestMvvmMessenger;

[ObservableObject]
public partial class TestViewModel : IRecipient<TestMessage>
{
    [ObservableProperty]
    string _message;

    public TestViewModel()
    {
        Message = "jack";
        WeakReferenceMessenger.Default.Register(this);
    }
    public async void Receive(TestMessage message)
    {
        await Task.Delay(10);
        Console.WriteLine("Received");
        Message = message.Value;
    }
}
