//PROJECT NAME: Logistics
//CLASS NAME: SSSFSDefineVariablesFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSDefineVariablesFactory
	{
		public ISSSFSDefineVariables Create(IApplicationDB appDB)
		{
			var _SSSFSDefineVariables = new Logistics.FieldService.SSSFSDefineVariables(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSDefineVariablesExt = timerfactory.Create<Logistics.FieldService.ISSSFSDefineVariables>(_SSSFSDefineVariables);
			
			return iSSSFSDefineVariablesExt;
		}
	}
}
