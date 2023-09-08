//PROJECT NAME: Codes
//CLASS NAME: GetDataTypeLengthFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class GetDataTypeLengthFactory
	{
		public IGetDataTypeLength Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetDataTypeLength = new Codes.GetDataTypeLength(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDataTypeLengthExt = timerfactory.Create<Codes.IGetDataTypeLength>(_GetDataTypeLength);
			
			return iGetDataTypeLengthExt;
		}
	}
}
