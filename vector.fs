
open System.Runtime.InteropServices

// [<DllImport("mydll.dll", CallingConvention= CallingConvention.Cdecl)>]
// extern int calculateSum(int a, int b)

// let result = calculateSum(3, 4)
// printfn "The sum of 3 and 4 is %d" result

[<DllImport("mydll.dll", CallingConvention= CallingConvention.Cdecl)>]
extern double Vector2(double x, double y)

let result = Vector2(3.0, 4.0)
printfn "The length of the vector (3, 4) is %f" result


[<DLKz>("libVectors.dylib", CallingConvention= CallingConvention.Cdecl)>]
extern double Vector2(double x, double y)

// let result = Vector2(3.0, 4.0)