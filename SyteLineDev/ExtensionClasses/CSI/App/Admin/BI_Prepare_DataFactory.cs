//PROJECT NAME: Admin
//CLASS NAME: BI_Prepare_DataFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class BI_Prepare_DataFactory
	{
		public IBI_Prepare_Data Create(IApplicationDB appDB)
		{
			var _BI_Prepare_Data = new Admin.BI_Prepare_Data(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBI_Prepare_DataExt = timerfactory.Create<Admin.IBI_Prepare_Data>(_BI_Prepare_Data);
			
			return iBI_Prepare_DataExt;
		}
	}
}
