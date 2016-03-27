using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class AotTest1
{
	// NOTE: Direct call Generic Method
    public void MethodA<T>()
    {
		Debug.Log( "MethodA" );
    }

	// NOTE: Indirect call Generic Method
	public void MethodB<T>()
    {
		Debug.Log( "MethodB" );
		InternalB<T>();
    }

	// NOTE: Call Generic Method via Reflection
	public void MethodC<T>()
    {
		Debug.Log( "MethodC" );

        Type type = typeof( T );
		MethodInfo methodInfo = typeof( AotTest1 ).GetMethod( "InternalC" );
		if (null != methodInfo) {
			methodInfo = methodInfo.MakeGenericMethod (new Type[] { type });
			methodInfo.Invoke (this, null);
		}
    }
	
	// NOTE: Call Generic Method via Reflection (Direct Called before)
	public void MethodD<T>()
    {
		Debug.Log( "MethodD" );
		InternalD<T>();

        Type type = typeof( T );
		MethodInfo methodInfo = typeof( AotTest1 ).GetMethod( "InternalD" );
		if (null != methodInfo) {
			methodInfo = methodInfo.MakeGenericMethod (new Type[] { type });
			methodInfo.Invoke (this, null);
		}
	}
	
	// NOTE: Call Generic Method via Reflection (Direct Called after)
	public void MethodE<T>()
	{
		Debug.Log( "MethodE" );
		
		Type type = typeof( T );
		MethodInfo methodInfo = typeof( AotTest1 ).GetMethod( "InternalE" );
		if (null != methodInfo) {
			methodInfo = methodInfo.MakeGenericMethod (new Type[] { type });
			methodInfo.Invoke (this, null);
		}
		
		InternalE<T>();
	}
	
	
	private void InternalB<T>()
	{
		Debug.Log( "InternalB" );
	}
	
	private void InternalC<T>()
	{
		Debug.Log( "InternalC" );
	}
	
	private void InternalD<T>()
	{
		Debug.Log( "InternalD" );
	}

	private void InternalE<T>()
	{
		Debug.Log( "InternalE" );
	}
}
