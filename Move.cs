class Move
{
    public string Name;
    public Types Type;
    public string MoveType;


    public Move(string name, string moveType)
    {
        Name = name;
        Type = new Types();
        MoveType = moveType;
    }

}