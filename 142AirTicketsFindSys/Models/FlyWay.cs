class Flyway
{
    public int id;
    public string[] route;
    public int places;
    public DateTime startTime;
    public DateTime endTime;
    public Flyway(int id, string[] route, int places,DateTime startTime,DateTime endTime)
    {
        this.id = id;
        this.route = route;
        this.places = places;
        this.startTime = startTime;
        this.endTime = endTime;
    }
    
}