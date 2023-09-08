//PROJECT NAME: Production
//CLASS NAME: PSCmplTransFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PSCmplTransFactory
	{
		public IPSCmplTrans Create(IApplicationDB appDB)
		{
			var _PSCmplTrans = new Production.PSCmplTrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPSCmplTransExt = timerfactory.Create<Production.IPSCmplTrans>(_PSCmplTrans);
			
			return iPSCmplTransExt;
		}
	}
}
