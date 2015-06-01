using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Main : MonoBehaviour
{
    void Start()
    {
        var test = new AotTest();
        test.GenericA<int>();
        test.GenericB<int>();
        test.ReflectionC<int>();
        test.ReflectionD<int>();
    }

    void Update()
    {

    }
}
