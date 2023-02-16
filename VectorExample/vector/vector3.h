struct Vector3
{
    double x;
    double y;
    double z;
    Vector3(double inx = 0, double iny = 0, double inz = 0);
    double v3distanceTo(Vector3 pos);
    void v3vectorMovement(double plusx, double plusy, double plusz);
    Vector3 v3midpoint(Vector3 pos);
    double v3percentDistance(Vector3 pos, double percentOfDistance = 100);
};