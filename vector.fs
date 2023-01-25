
open System.Runtime.InteropServices

[<DllImport("Project_2.dll", CallingConvention= CallingConvention.Cdecl)>]
extern int calculateSum(int a, int b)

let result = calculateSum(3, 4)
printfn "The sum of 3 and 4 is %d" result