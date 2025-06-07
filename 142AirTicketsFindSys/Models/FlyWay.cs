public class Flyway
{
    public int Id { get; set; }
    public string[] Route { get; set; }
    public int[] Places { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Flyway(int id, string[] route, int[] places,DateTime startTime,DateTime endTime)
    {
        this.Id = id;
        this.Route = route;
        this.Places = places;
        this.StartTime = startTime;
        this.EndTime = endTime;
    }
    
    public Flyway()
    {

    }
    
    
    

}