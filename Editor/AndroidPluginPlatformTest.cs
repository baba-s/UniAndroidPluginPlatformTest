using NUnit.Framework;
using System.Linq;
using System.Text;
using UnityEditor;

namespace Kogane.Internal
{
	internal sealed class AndroidPluginPlatformTest
	{
		[Category( nameof( Kogane ) )]
		[Test]
		public void Android_プラグインのプラットフォームが適切か()
		{
			var list = AssetDatabase
					.GetAllAssetPaths()
					.Where( c => c.Contains( "/Plugins/" ) )
					.Where( c => c.Contains( "/Android/" ) )
					.Select( c => AssetImporter.GetAtPath( c ) )
					.OfType<PluginImporter>()
					.Where( c => c != null )
					.Where( c => c.GetCompatibleWithPlatform( BuildTarget.iOS ) )
					.Select( c => AssetDatabase.GetAssetPath( c ) )
					.ToArray()
				;

			if ( !list.Any() ) return;

			var sb = new StringBuilder();

			foreach ( var n in list )
			{
				sb.AppendLine( n );
			}

			Assert.Fail( sb.ToString() );
		}
	}
}