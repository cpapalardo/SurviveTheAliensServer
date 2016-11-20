using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SurviveTheAliensServer
{
	public class Sql
	{
		public static string ConnString = "Server = aliens.database.windows.net,1433;Database=SurviveAliens;User ID = SurviveAliens;Password=Survive@123;Encrypt=True;TrustServerCertificate=False; MultipleActiveResultSets = True; Encrypt = True";

		public static SqlConnection Open()
		{
			SqlConnection conn = new SqlConnection(ConnString);
			conn.Open();
			return conn;
		}
	}
}