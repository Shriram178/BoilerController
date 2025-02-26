namespace BoilerHandler.Tests;

public class BoilerManagerTests : IDisposable
{
    private BoilerManager _boilerManager;

    StringWriter StringWriter;

    public BoilerManagerTests()
    {
        _boilerManager = new BoilerManager();
        StringWriter = new StringWriter();
        Console.SetOut(StringWriter);
    }

    public void Dispose()
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput())
        { AutoFlush = true });

        StringWriter.Dispose();
    }

    [Fact]
    public void ClosedSwitch_StartSequence_ShouldTransitionToOperational()
    {
        string input = "\n\n";
        StringReader inputReader = new StringReader(input);
        Console.SetIn(inputReader);
        _boilerManager.ToggleRunInteractorSwitch("Closed");

        _boilerManager.StartSequence();

        Assert.Equal("Operational", _boilerManager.GetBoilerStatus());
    }

    [Fact]
    public void OpenSwitch_StartSequence_ShouldNotStart()
    {
        _boilerManager.ToggleRunInteractorSwitch("Open");

        _boilerManager.StartSequence();

        Assert.NotEqual("Operational", _boilerManager.GetBoilerStatus());
    }

    [Fact]
    public void TestStopSequence_ResetBoiler()
    {
        _boilerManager.StopSequence();

        Assert.Equal("Ready", _boilerManager.GetBoilerStatus());
    }

    [Fact]
    public void ClosedSwitch_ResetLock_ShouldResetBoiler()
    {
        _boilerManager.ToggleRunInteractorSwitch("Closed");

        _boilerManager.ResetLockOut();

        Assert.Equal("Ready", _boilerManager.GetBoilerStatus());
    }

    [Fact]
    public void OpenSwitch_ResetLockOut_ShouldNotResetBoiler()
    {
        _boilerManager.ToggleRunInteractorSwitch("Open");

        _boilerManager.ResetLockOut();

        Assert.NotEqual("Ready", _boilerManager.GetBoilerStatus());
    }
}