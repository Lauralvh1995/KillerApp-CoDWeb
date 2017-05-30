using System.Data;

namespace WoDWebBuilder.DAL
{
	public static class IDbCommandExtension
	{
		public static void AddParameterWithValue(this IDbCommand command, string name, object value)
		{
			IDbDataParameter parameter = command.CreateParameter();
			parameter.ParameterName = name;
			parameter.Value = value;
			command.Parameters.Add(parameter);
		}
	}
}