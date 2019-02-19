using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace WristBandWebApp
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			ServicePointManager.ServerCertificateValidationCallback =
			delegate (
				object s,
				X509Certificate certificate,
				X509Chain chain,
				SslPolicyErrors sslPolicyErrors
			) {
				return true;
			};

			filters.Add(new HandleErrorAttribute());
		}
	}
}
