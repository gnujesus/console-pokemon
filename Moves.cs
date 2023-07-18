class Moves
{
    private string Name;
    private Types Type;
    private string MoveType;


    public Moves(string name, string moveType)
    {
        Name = name;
        Type = new Types();
        MoveType = moveType;
    }
}