//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBCopyCOAtoMultiCOAFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBCopyCOAtoMultiCOAFactory
	{
		public IMultiFSBCopyCOAtoMultiCOA Create(IApplicationDB appDB)
		{
			var _MultiFSBCopyCOAtoMultiCOA = new Finance.MultiFSBCopyCOAtoMultiCOA(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBCopyCOAtoMultiCOAExt = timerfactory.Create<Finance.IMultiFSBCopyCOAtoMultiCOA>(_MultiFSBCopyCOAtoMultiCOA);
			
			return iMultiFSBCopyCOAtoMultiCOAExt;
		}
	}
}
