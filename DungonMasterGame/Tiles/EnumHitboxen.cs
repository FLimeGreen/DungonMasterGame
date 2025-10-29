public enum Hitbox
{
    // Emthy Hitbox
    None = 0,

    // Hitbox für leere Felder beginnt mit 1
    FreeSpace = 1,
    FreeSpace_with_Player = 10,
    FreeSpace_with_Supporter = 11,
    FreeSpace_with_Gegner = 12,

    // Hitbox für Terrain beginnt mit 2
    Wall = 2,

    // Hitbox für Gebäude beginnt mit 3
    Friedhof = 30,
}