namespace Contracts.ResultInfo;

public abstract record DeleteResult
{
    private DeleteResult() {}

    public sealed record Success : DeleteResult;

    public sealed record Failed : DeleteResult;

}