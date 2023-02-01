namespace vector
open System.Runtime.InteropServices
open System


module VectorProgramm=
// ! Structure 
    [<Struct;StructLayout(LayoutKind.Sequential)>]
    type Vector2 =
        val mutable x: double
        val mutable y: double
        new(x: double, y: double) = {x = x; y = y}

    [<Struct;StructLayout(LayoutKind.Sequential)>]
    type Vector3 =
        val mutable x: double
        val mutable y: double
        val mutable z: double
        new(x: double, y: double, z: double) = {x = x; y = y; z = z}

    [<DllImport("TestLyb/lib/libvector.dylib")>]
    extern double distanceTo(Vector2 pos)

    [<DllImport("TestLyb/lib/libvector.dylib")>]
    extern double percentDistance(Vector2 pos, double percentOfDistance)
        
    [<DllImport("TestLyb/lib/libvector.dylib")>]
    extern double v3distanceTo(Vector3 pos)

    [<DllImport("TestLyb/lib/libvector.dylib")>]
    extern double v3percentDistance(Vector3 pos, double percentOfDistance)


    

