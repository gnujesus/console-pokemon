class Move
{
    private string Name;
    private Types Type;
    private string MoveType;


    public Move(string name, string moveType)
    {
        Name = name;
        Type = new Types();
        MoveType = moveType;
    }
}