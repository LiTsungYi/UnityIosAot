using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class AotTest
    {
        public void GenericA<T>()
        {
            Debug.Log( "GenericA" );
        }

        public void GenericB0<T>()
        {
            Debug.Log( "GenericB0" );
        }

        public void GenericB<T>()
        {
            // NOTE: AOI
            Debug.Log( "GenericB" );
            GenericB0<T>();
        }

        public void GenericC<T>()
        {
            Debug.Log( "GenericC" );
        }

        public void GenericD<T>()
        {
            Debug.Log( "GenericD" );
        }

        public void ReflectionC<T>()
        {
            // NOTE: AOI
            Debug.Log( "ReflectionC" );

            Type type = typeof( T );
            MethodInfo methodInfo = typeof( AotTest ).GetMethod( "GenericC" );
            methodInfo = methodInfo.MakeGenericMethod( new Type[] { type } );
            methodInfo.Invoke( this, null );
        }

        public void ReflectionD<T>()
        {
            Debug.Log( "ReflectionD" );
            GenericD<T>();

            Type type = typeof( T );
            MethodInfo methodInfo = typeof( AotTest ).GetMethod( "GenericD" );
            methodInfo = methodInfo.MakeGenericMethod( new Type[] { type } );
            methodInfo.Invoke( this, null );
        }
    }
}
