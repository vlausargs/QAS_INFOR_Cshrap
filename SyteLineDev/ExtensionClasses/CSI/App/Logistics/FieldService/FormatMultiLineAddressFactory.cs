//PROJECT NAME: CSIFSPlus
//CLASS NAME: FormatMultiLineAddressFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class FormatMultiLineAddressFactory
	{
		public IFormatMultiLineAddress Create(IApplicationDB appDB)
		{
			var _FormatMultiLineAddress = new Logistics.FieldService.FormatMultiLineAddress(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFormatMultiLineAddressExt = timerfactory.Create<Logistics.FieldService.IFormatMultiLineAddress>(_FormatMultiLineAddress);
			
			return iFormatMultiLineAddressExt;
		}
	}
}
