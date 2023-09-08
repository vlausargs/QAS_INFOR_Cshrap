//PROJECT NAME: CSIProjects
//CLASS NAME: GetECVatValuesFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetECVatValuesFactory
	{
		public IGetECVatValues Create(IApplicationDB appDB)
		{
			var _GetECVatValues = new Production.Projects.GetECVatValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetECVatValuesExt = timerfactory.Create<Production.Projects.IGetECVatValues>(_GetECVatValues);
			
			return iGetECVatValuesExt;
		}
	}
}
