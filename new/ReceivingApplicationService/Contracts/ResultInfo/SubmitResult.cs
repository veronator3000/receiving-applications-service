namespace Contracts.ResultInfo;

public abstract record SubmitResult
{
    private SubmitResult() {}

    public sealed record Success : SubmitResult;

    public sealed record Failed : SubmitResult;
}