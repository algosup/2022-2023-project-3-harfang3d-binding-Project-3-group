
open System.Runtime.InteropServices
open System

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

module dll =
    [<DllImport("vector.dll")>]
    extern double distanceTo(Vector2 pos)

    [<DllImport("vector.dll")>]
    extern double percentDistance(Vector2 pos, double percentOfDistance)
    
    [<DllImport("vector.dll")>]
    extern double v3distanceTo(Vector3 pos)

    [<DllImport("vector.dll")>]
    extern double v3percentDistance(Vector3 pos, double percentOfDistance)

module dylib =
    [<DllImport("TestLyb/lib/libvector.dylib")>]
    extern double distanceTo(Vector2 pos)

    [<DllImport("TestLyb/lib/libvector.dylib")>]
    extern double percentDistance(Vector2 pos, double percentOfDistance)
    
    [<DllImport("TestLyb/lib/libvector.dylib")>]
    extern double v3distanceTo(Vector3 pos)

    [<DllImport("TestLyb/lib/libvector.dylib")>]
    extern double v3percentDistance(Vector3 pos, double percentOfDistance)



// ! Vector 2 
let v2 = Vector2(2.0, 2.0)
if Environment.OSVersion.Platform = PlatformID.Win32NT then
    let v2DistanceTo = dll.distanceTo(v2)
    let v2PercentDistance = dll.percentDistance(v2, 0.5)
    v2DistanceTo |> printfn "Distance to origin in Vector 2: %f"
    v2PercentDistance |> printfn "Percent distance to origin in Vector 2: %f"

else
    let v2DistanceTo = dylib.distanceTo(v2)
    let v2PercentDistance = dylib.percentDistance(v2, 0.5)
    v2DistanceTo |> printfn "Distance to origin in Vector 2: %f"
    v2PercentDistance |> printfn "Percent distance to origin in Vector 2: %f"

let v3 = Vector3(1.0, 2.0, 3.0)
if Environment.OSVersion.Platform = PlatformID.Win32NT then
    let v3DistanceTo = dll.v3distanceTo(v3)
    let v3PercentDistance = dll.v3percentDistance(v3, 0.5)
    v3DistanceTo |> printfn "Distance to origin in Vector 3: %f"
    v3PercentDistance |> printfn "Percent distance to origin in Vector 3: %f"
else
    let v3DistanceTo = dylib.v3distanceTo(v3)
    let v3PercentDistance = dylib.v3percentDistance(v3, 0.5)
    v3DistanceTo |> printfn "Distance to origin in Vector 3: %f"
    v3PercentDistance |> printfn "Percent distance to origin in Vector 3: %f"
// ! Vector 3
