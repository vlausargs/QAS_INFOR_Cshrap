//PROJECT NAME: Production
//CLASS NAME: SeqProjBolValFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class SeqProjBolValFactory
	{
		public ISeqProjBolVal Create(IApplicationDB appDB)
		{
			var _SeqProjBolVal = new Production.Projects.SeqProjBolVal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSeqProjBolValExt = timerfactory.Create<Production.Projects.ISeqProjBolVal>(_SeqProjBolVal);
			
			return iSeqProjBolValExt;
		}
	}
}
