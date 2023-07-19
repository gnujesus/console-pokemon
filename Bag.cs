class Bag
{
    public string[] Items;


    public Bag(string[] items)
    {
        Items = items;
    }

    private void clearBag()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i] = "";
        }
    }
}