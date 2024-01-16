namespace Core.Services;

public class Service
{
    public readonly AnalyzeData AnalyzeData;
    public readonly InteractData InteractData;

    public Service(Repositories.Repository repository)
    {
        AnalyzeData = new AnalyzeData(repository);
        InteractData = new InteractData(repository);
    }
}