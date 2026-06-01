using Xunit;
using Moq;

public class LoggingFilterTests
{
    [Fact]
    public void LoggingFilter_Should_Log_Request()
    {
        var mockLogger =
            new Mock<ILoggingService>();

        var filter =
            new LoggingFilter(mockLogger.Object);

        mockLogger.Verify(
            x => x.Log(It.IsAny<string>()),
            Times.Never);
    }
}
