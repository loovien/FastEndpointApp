using FastEndpointApp.Utils;

namespace FastEndpointApp.Endpoints.Admin;

public class UserEndpoint : EndpointWithoutRequest
{
    private readonly ILogger<UserEndpoint> _logger;

    private readonly IConfiguration _configuration;

    public UserEndpoint(ILogger<UserEndpoint> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Get("hello");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = Query<int>("id", isRequired: false);
        var logValue = _configuration.GetValue<string>("Logging:LogLevel:Default");
        _logger.LogInformation("receive a client request, {}", query);
        await SendOkAsync(Result<UserResponse>.Success(new UserResponse(logValue, query)), ct);
    }
}