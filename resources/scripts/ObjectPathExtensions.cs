using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace SLZ.Marrow.Utilities
{
	public static class ObjectPathExtensions
	{
		private static IEnumerable<string> ObjectPathComponents(this Transform tf)
		{
			return null;
		}

		[PublicAPI]
		public static string ObjectPath(this Transform tf)
		{
			return tf.gameObject.ObjectPath();
		}

		[PublicAPI]
		public static string ObjectPath(this Component c)
		{
			return c.gameObject.ObjectPath();
		}

		[PublicAPI]
		public static string ObjectPath(this GameObject go)
		{
			string path = go.name;
			while (go.transform.parent != null)
			{
				go = go.transform.parent.gameObject;
				path = $"{go.name}/{path}";
			}
			return path;
		}
	}
}
