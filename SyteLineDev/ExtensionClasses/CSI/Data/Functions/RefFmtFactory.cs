//PROJECT NAME: Data
//CLASS NAME: RefFmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class RefFmtFactory
    {
        public IRefFmt Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _RefFmt = new Functions.RefFmt(appDB);


            return _RefFmt;
        }

        public IRefFmt Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
      
            var _RefFmt = new Functions.RefFmt(appDB);

            return _RefFmt;
        }
    }
}
