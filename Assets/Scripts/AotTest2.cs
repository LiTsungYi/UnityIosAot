using UnityEngine;
using System.Collections;

public class AotTest2 : IAotTest
{
	public void Method1<T>( T v )
	{
		Debug.Log( "Method1" );
	}

	public void Method2<T>( T v )
	{
		Debug.Log( "Method2" );
	}

	public void Method3<T>( T v )
	{
		Debug.Log( "Method3" );
	}

	public void Method4<T>( T v )
	{
		Debug.Log( "Method4" );
	}
}
