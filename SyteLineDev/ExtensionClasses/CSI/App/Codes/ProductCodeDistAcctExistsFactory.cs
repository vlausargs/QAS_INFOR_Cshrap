//PROJECT NAME: Codes
//CLASS NAME: ProductCodeDistAcctExistsFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class ProductCodeDistAcctExistsFactory
	{
		public IProductCodeDistAcctExists Create(IApplicationDB appDB)
		{
			var _ProductCodeDistAcctExists = new Codes.ProductCodeDistAcctExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProductCodeDistAcctExistsExt = timerfactory.Create<Codes.IProductCodeDistAcctExists>(_ProductCodeDistAcctExists);
			
			return iProductCodeDistAcctExistsExt;
		}
	}
}
