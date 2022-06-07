using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
	/// <summary>
	/// Descrição resumida de WebService1
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
	// [System.Web.Script.Services.ScriptService]
	public class WebService1 : System.Web.Services.WebService
	{

		[WebMethod]
		public string HelloWorld()
		{
			return "Olá, Mundo";
		}

		[WebMethod]
		public void Adivinha(int valorA, int valorB)
		{

			valorA = Console.Read();
			valorB = Console.Read();
			try
			{

				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["verdadeiraDB"].ConnectionString);
				conn.Open();
				string insertQuery = "insert into [dbo].[verdadeiraTable](valorA,valorB) values(@valorA,@valorB)";
				SqlCommand cmd = new SqlCommand(insertQuery, conn);
				cmd.Parameters.AddWithValue("@valorA", valorA);
				cmd.Parameters.AddWithValue("@valorB", valorB);


				cmd.ExecuteNonQuery();

				Console.WriteLine("Adicionado com sucesso.");

				conn.Close();

			}
			catch (Exception ex)
			{
				Console.WriteLine("error" + ex.ToString());
			}

		}
	}

}

