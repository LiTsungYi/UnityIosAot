using UnityEngine;

public class Main : MonoBehaviour
{
	public void Start()
	{
		// NOTE: Test generic
		var test1 = new AotTest1();

		// NOTE: Direct call Generic Method
		test1.MethodA<int>();
		
		// NOTE: Indirect call Generic Method
		test1.MethodB<int>();

		// NOTE: Call Generic Method via Reflection
		//test1.MethodC<int>();

		//ExecutionEngineException: Attempting to JIT compile method 'AotTest1:InternalC<int> ()' while running with --aot-only.
		//
		//at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in <filename unknown>:0 
		//	Rethrow as TargetInvocationException: Exception has been thrown by the target of an invocation.
		//		at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in <filename unknown>:0 
		//		at System.Reflection.MethodBase.Invoke (System.Object obj, System.Object[] parameters) [0x00000] in <filename unknown>:0 
		//		at AotTest1.MethodC[Int32] () [0x00000] in <filename unknown>:0 
		//		at Main.Start () [0x00000] in <filename unknown>:0

		// NOTE: Call Generic Method via Reflection (Direct Called before)
		test1.MethodD<int>();

		// NOTE: Call Generic Method via Reflection (Direct Called after)
		test1.MethodE<int>();

		int dummy = 42;
		// NOTE: Test concrete
		var test2 = new AotTest2();

		// NOTE: Call Generic Method from Concrete object
		test2.Method1( dummy );
		
		// NOTE: Call Generic Method from Concrete object
		test2.Method2( dummy );

		// NOTE: Test interface
		IAotTest test3 = test2;
		
		// NOTE: Call Generic Method from Interface
		//test3.Method3( dummy ); // ERROR: AOT

		//ExecutionEngineException: Attempting to JIT compile method 'AotTest2:Method3<int> (int)' while running with --aot-only.
		//
		//at Main.Start () [0x00000] in <filename unknown>:0 
		//	
		//	(Filename:  Line: -1)

		// NOTE: Call Generic Method from Interface (Direct Called before)
		test3.Method4( dummy );
	}

	private void Dummy()
	{
		int dummy = 42;
		var test = new AotTest2();
		// NOTE: Explicit call Method4
		test.Method4( dummy );
	}
}
