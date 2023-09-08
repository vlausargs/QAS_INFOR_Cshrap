using CSI.Interfaces.Data;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public interface ISQLDependencies
    {
        ISQLBunchingContext SQLBunchingContext { get; }
        IMessageProvider SQLMessageProvider { get; }
        ICommandProvider SQLCommandProvider { get; }
        ISetSite SetSite { get; }

        IUserPrincipal UserPrincipal { get; }

        IFileServer FileServer { get; }
        IApplicationEvent ApplicationEvent { get; }
        IEmail Email { get; }

    }
}