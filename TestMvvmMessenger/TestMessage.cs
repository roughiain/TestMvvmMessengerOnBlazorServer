using CommunityToolkit.Mvvm.Messaging.Messages;

namespace TestMvvmMessenger;

public class TestMessage: ValueChangedMessage<string>
{
    public TestMessage(string value) : base(value)
    {
    }
}
