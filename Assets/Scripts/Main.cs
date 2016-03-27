using UnityEngine;

public class Main : MonoBehaviour
{
    void Start()
    {
		// NOTE: Test generic
		var test1 = new AotTest1();

		// NOTE: Direct call Generic Method
		test1.MethodA<int>();
		
		// NOTE: Indirect call Generic Method
		test1.MethodB<int>();

		// NOTE: Call Generic Method via Reflection
		test1.MethodC<int>(); // ERROR: AOT

		// NOTE: Call Generic Method via Reflection (Direct Called before)
		test1.MethodD<int>();

		// NOTE: Call Generic Method via Reflection (Direct Called after)
		test1.MethodE<int>();

		int dummy = 42;
		// NOTE: Test concrete
		var test2 = new AotTest2<int>();

		// NOTE: Call Generic Method from Concrete object
		test2.Method1( dummy );
		
		// NOTE: Call Generic Method from Concrete object
		test2.Method2( dummy );

		// NOTE: Test interface
		IAotTest<int> test = test2;
		
		// NOTE: Call Generic Method from Interface
		test.Method3( dummy ); // ERROR: AOT

		if ( false )
		{
			// NOTE: Explicit call Method
			test2.Method4( dummy );
		}

		// NOTE: Call Generic Method from Interface (Direct Called before)
		test.Method4 (dummy);
    }
}
