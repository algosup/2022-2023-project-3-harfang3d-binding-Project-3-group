open vector.VectorProgramm

[<EntryPoint>]
let main args = 
    
    let v2 = Vector2(2.0, 2.0)
    let v2DistanceTo = v2distanceTo(v2)
    let v2PercentDistance = v2percentDistance(v2, 0.5)

    // ! Vector 3
    let v3 = Vector3(1.0, 2.0, 3.0)
    let v3DistanceTo = v3distanceTo(v3)
    let v3PercentDistance = v3percentDistance(v3, 0.5)
    // ! Print 
    printfn "Distance to origin in Vector 2: %f" v2DistanceTo
    printfn "Percent distance to origin in Vector 2: %f" v2PercentDistance
    printfn "Distance to origin in Vector 3: %f" v3DistanceTo
    printfn "Percent distance to origin in Vector 3: %f" v3PercentDistance

    0 // return an integer exit code