struct Vector2
{
    double x;
    double y;
    Vector2(double x, double y);
    double v2distanceTo(Vector2 pos);
    void v2vectorMovement(double plusx, double plusy);
    Vector2 v2midpoint(Vector2 pos);
    double v2percentDistance(Vector2 pos, double percentOfDistance);
};