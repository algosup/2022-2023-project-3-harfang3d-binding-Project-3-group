
open System.Runtime.InteropServices

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

// ! DLLImport Function
[<DllImport("TestLyb/lib/libvector.dylib")>]
extern double distanceTo(Vector2 pos)

// [<DllImport("TestLyb/lib/libvector.dylib")>]
// extern double percentDistance(Vector2 pos, double percentOfDistance)

// [<DllImport("TestLyb/lib/libvector.dylib")>]
// extern double distanceTo(Vector3 pos)

// [<DllImport("TestLyb/lib/libvector.dylib")>]
// extern double percentDistance(Vector3 pos, double percentOfDistance)

// ! Vector 2 
let v2 = Vector2(1.0, 2.0)
let v2DistanceTo = Vector2_distanceTo(v2)
// let v2PercentDistance = percentDistance(v2, 0.5)

// ! Vector 3
// let v3 = Vector3(1.0, 2.0, 3.0)
// let v3DistanceTo = distanceTo(v3)
// let v3PercentDistance = percentDistance(v3, 0.5)

// ! Print 
printfn "Distance to origin in Vector 2: %f" v2DistanceTo
// printfn "Percent distance to origin in Vector 2: %f" v2PercentDistance
// printfn "Distance to origin in Vector 3: %f" v3DistanceTo
// printfn "Percent distance to origin in Vector 3: %f" v3PercentDistance