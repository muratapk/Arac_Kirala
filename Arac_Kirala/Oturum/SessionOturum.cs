using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace Arac_Kirala.Oturum
{
	public static class SessionOturum
	{
		public static void SetJson<T>(this ISession session, string key, T value)
		{
			 session.SetString(key, JsonConvert.SerializeObject(value)); // Serileştirilmiş veriyi kaydeder
		}

		public static T GetJson<T>(this ISession session, string key)
		{
			var sessionData = session.GetString(key);
			return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData); // Veriyi deserileştirip döner
		}

	}
}
