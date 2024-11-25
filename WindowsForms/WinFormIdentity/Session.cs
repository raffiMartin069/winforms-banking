using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormIdentity.Sessionizer
{
	public static class Session
	{
        private static Dictionary<string, string> Claims = new Dictionary<string, string>();

		public static void SetClaim(string key, string value)
		{
			Claims.Add(key, value);
		}

		public static string GetClaim(string key)
		{
			return Claims[key];
		}

		public static void Clear()
		{
			Claims.Clear();
		}
	}
}
