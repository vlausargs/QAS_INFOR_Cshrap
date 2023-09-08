//PROJECT NAME: CSICodes
//CLASS NAME: EFTMapImportCreateDataViewFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class EFTMapImportCreateDataViewFactory
    {
        public IEFTMapImportCreateDataView Create(IApplicationDB appDB)
        {
            var _EFTMapImportCreateDataView = new EFTMapImportCreateDataView(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEFTMapImportCreateDataViewExt = timerfactory.Create<IEFTMapImportCreateDataView>(_EFTMapImportCreateDataView);

            return iEFTMapImportCreateDataViewExt;
        }
    }
}
