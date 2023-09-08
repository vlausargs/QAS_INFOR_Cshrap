//PROJECT NAME: App.Reporting
//CLASS NAME: EXTSSSFSRpt_JobHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Reporting
{
	public class EXTSSSFSRpt_JobHeaderFactory
	{
		public IEXTSSSFSRpt_JobHeader Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _EXTSSSFSRpt_JobHeader = new Reporting.EXTSSSFSRpt_JobHeader(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEXTSSSFSRpt_JobHeaderExt = timerfactory.Create<Reporting.IEXTSSSFSRpt_JobHeader>(_EXTSSSFSRpt_JobHeader);

			return iEXTSSSFSRpt_JobHeaderExt;
		}
	}
}
