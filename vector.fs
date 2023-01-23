// fichier F#
open System.Runtime.InteropServices

type Vector2 = {
    x : double
    y : double
}

type Vector3 = {
    x : double
    y : double
    z : double
}

[<DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)>]
extern Vector2 Vector2_new(double x, double y)

[<DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)>]
extern double Vector2_distanceTo(Vector2, Vector2)

[<DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)>]
extern void Vector2_vectorMovement(Vector2, double, double)

[<DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)>]
extern Vector2 Vector2_midpoint(Vector2, Vector2)

[<DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)>]
extern double Vector2_percentDistance(Vector2, Vector2, double)

[<DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)>]
extern Vector3 Vector3_new(double x, double y, double z)

[<DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)>]
extern double Vector3_distanceTo(Vector3, Vector3)

[<DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)>]
extern void Vector3_vectorMovement(Vector3, double, double, double)

[<DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)>]
extern Vector3 Vector3_midpoint(Vector3, Vector3)

[<DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)>]
extern double Vector3_percentDistance(Vector3, Vector3, double)

let v2 = Vector2_new(1.0, 2.0)
let v2_2 = Vector2_new(2.0, 3.0)
let dist = Vector2_distanceTo(v2, v2_2)
Vector2_vectorMovement(v2, 2.0, 3.0)
let mid = Vector2_midpoint(v2, v2_2)
let percent = Vector2_percentDistance(v2, v2_2, 50.0)

let v3 = Vector3_new(1.0, 2.0, 3.0)
let v3_2 = Vector3_new(2.0, 3.0, 4.0)
let dist3 = Vector3_distanceTo(v3, v3_2)
Vector3_vectorMovement(v3, 2.0, 3.0, 4.0)
let mid3 = Vector3_midpoint(v3, v3_2)
let percent3 = Vector3_percentDistance(v3, v3_2, 50.0)
