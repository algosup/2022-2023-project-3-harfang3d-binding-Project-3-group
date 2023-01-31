namespace vector
open FsUnit
open System
open VectorProgramm
open NUnit.Framework

module testVector =

    [<Test>]
    let ``Test distanceTo for Vector2``() = 
        let v2 = Vector2(2.0, 2.0)
        let expectedDistance = 2.83
        let actualDistance = distanceTo(v2)
        let round(f : float) = System.Math.Round(f, 2)
        let roundedActualDistance = round(actualDistance)
        roundedActualDistance |> should equal expectedDistance
        

    [<Test>]
    let ``Test percentDistance for Vector2``() = 
        let v2 = Vector2(2.0, 2.0)
        let expectedPercentDistance = 1.41
        let actualPercentDistance = percentDistance(v2, 0.5)
        let round(f : float) = System.Math.Round(f, 2)
        let roundedActualPercentDistance = round(actualPercentDistance)
        roundedActualPercentDistance |> should equal expectedPercentDistance

    [<Test>]
    let ``Test v3distanceTo for Vector3``() = 
        let v3 = Vector3(1.0, 2.0, 3.0)
        let expectedV3Distance = 3.74
        let actualV3Distance = v3distanceTo(v3)
        let round(f : float) = System.Math.Round(f, 2)
        let roundedActualV3Distance = round(actualV3Distance)
        roundedActualV3Distance |> should equal expectedV3Distance

    [<Test>]
    let ``Test v3percentDistance for Vector3``() = 
        let v3 = Vector3(1.0, 2.0, 3.0)
        let expectedV3PercentDistance = 1.87
        let actualV3PercentDistance = v3percentDistance(v3, 0.5)
        let round(f : float) = System.Math.Round(f, 2)
        let roundedActualV3PercentDistance = round(actualV3PercentDistance)
        roundedActualV3PercentDistance |> should equal expectedV3PercentDistance

