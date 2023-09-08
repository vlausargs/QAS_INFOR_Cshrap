//PROJECT NAME: Logistics
//CLASS NAME: SSSFSCreateKBaseRecordWrapperFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSCreateKBaseRecordWrapperFactory
	{
		public ISSSFSCreateKBaseRecordWrapper Create(IApplicationDB appDB)
		{
			var _SSSFSCreateKBaseRecordWrapper = new Logistics.FieldService.CallCenter.SSSFSCreateKBaseRecordWrapper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSCreateKBaseRecordWrapperExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSCreateKBaseRecordWrapper>(_SSSFSCreateKBaseRecordWrapper);
			
			return iSSSFSCreateKBaseRecordWrapperExt;
		}
	}
}
