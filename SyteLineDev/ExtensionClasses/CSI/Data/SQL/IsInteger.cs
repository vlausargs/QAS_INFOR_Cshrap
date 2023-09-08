using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
	public class IsInteger : IIsInteger
	{
		public int? IsIntegerFn(string Value)
		{
            bool isInt = int.TryParse(Value, out _);
            return isInt ? 1 : 0;
		}
	}
}
