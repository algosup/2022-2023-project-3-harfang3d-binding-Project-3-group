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

    [<DllImport("lib/libvector.dylib")>]
    extern double v2distanceTo(Vector2 pos)

    [<DllImport("lib/libvector.dylib")>]
    extern double v2percentDistance(Vector2 pos, double percentOfDistance)
        
    [<DllImport("lib/libvector.dylib")>]
    extern double v3distanceTo(Vector3 pos)

    [<DllImport("lib/libvector.dylib")>]
    extern double v3percentDistance(Vector3 pos, double percentOfDistance)



    

