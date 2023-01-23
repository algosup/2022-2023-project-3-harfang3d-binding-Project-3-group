open System.Runtime.InteropServices

type Vector2(x:float,y:float) =
    member val X = x with get,set
    member val Y = y with get,set
    member this.distanceTo (pos:Vector2) = 
        sqrt((pos.Y - this.Y) * (pos.Y - this.Y) + (pos.X - this.X) * (pos.X - this.X))
    member this.vectorMovement (plusx:float,plusy:float) = 
        this.X <- this.X + plusx
        this.Y <- this.Y + plusy
    member this.midpoint (pos:Vector2) = 
        let mx = (this.X + pos.X) / 2.0
        let my = (this.Y + pos.Y) / 2.0
        new Vector2(mx, my)
    member this.percentDistance (pos:Vector2, percentOfDistance:float) = 
        this.distanceTo(pos) / (100.0 / percentOfDistance)

type Vector3(x:float,y:float,z:float) =
    member val X = x with get,set
    member val Y = y with get,set
    member val Z = z with get,set
    member this.distanceTo (pos:Vector3) = 
        sqrt((pos.Y - this.Y) * (pos.Y - this.Y) + (pos.X - this.X) * (pos.X - this.X) + (pos.Z - this.Z) * (pos.Z - this.Z))
    member this.vectorMovement (plusx:float,plusy:float,plusz:float) = 
        this.X <- this.X + plusx
        this.Y <- this.Y + plusy
        this.Z <- this.Z + plusz
    member this.midpoint (pos:Vector3) = 
        let mx = (this.X + pos.X) / 2.0
        let my = (this.Y + pos.Y) / 2.0
        let mz = (this.Z + pos.Z) / 2.0
        new Vector3(mx, my, mz)
    member this.percentDistance (pos:Vector3, percentOfDistance:float) = 
        this.distanceTo(pos) / (100.0 / percentOfDistance)