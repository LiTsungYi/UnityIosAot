using UnityEngine;
using System.Collections;

public class AotTest2<T> : IAotTest<T>
{
	public void Method1( T v )
	{
		Debug.Log( "Method1" );
	}

	public void Method2( T v )
	{
		Debug.Log( "Method2" );
	}

	public void Method3( T v )
	{
		Debug.Log( "Method3" );
	}

	public void Method4( T v )
	{
		Debug.Log( "Method4" );
	}
}
