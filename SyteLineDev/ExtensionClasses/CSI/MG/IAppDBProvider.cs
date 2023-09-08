using Mongoose.IDO.DataAccess;

namespace CSI.MG
{
    public interface IAppDBProvider
    {
        AppDB AppDB { get; }
    }
}
