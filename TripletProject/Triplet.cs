namespace TripletProject;

public record struct Triplet(char Letter1, char Letter2, char Letter3)
{
    public override string ToString()
    {
        return "" + Letter1 + Letter2 + Letter3;
    }
}