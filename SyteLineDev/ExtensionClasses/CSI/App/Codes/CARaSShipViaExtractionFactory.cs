//PROJECT NAME: CSICodes
//CLASS NAME: CARaSShipViaExtractionFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class CARaSShipViaExtractionFactory
	{
		public ICARaSShipViaExtraction Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CARaSShipViaExtraction = new Codes.CARaSShipViaExtraction(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCARaSShipViaExtractionExt = timerfactory.Create<Codes.ICARaSShipViaExtraction>(_CARaSShipViaExtraction);
			
			return iCARaSShipViaExtractionExt;
		}
	}
}
