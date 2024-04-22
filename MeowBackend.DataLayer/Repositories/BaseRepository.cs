namespace MeowBackend.DataLayer.Repositories;

public class BaseRepository
{
    protected readonly MeowDBContext _ctx;

    public BaseRepository(MeowDBContext connectionString)
    {
        _ctx = connectionString;
    }
}
