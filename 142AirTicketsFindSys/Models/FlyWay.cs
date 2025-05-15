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
    public Flyway(string[][] dt)
    {
        this.id = int.Parse(dt[0][0]);
        this.route = dt[1];
        this.places = int.Parse(dt[0][1]);
        this.startTime = DateTime.Parse(dt[0][2]);
        this.endTime = DateTime.Parse(dt[0][3]);
    }
    public string[] getPrettyWay()
    {
        string middle = "";
        for(int i = 0; i < route.Length - 1; i++)
        {
            middle += route[i] + "---";
        }
        middle = middle.Remove(middle.Length - 3,3);
        return [id.ToString(), route.Last(),middle,places.ToString(),startTime.ToString(),(endTime-startTime).TotalHours.ToString()+"h"];
    }
    public string[][] saveData()
    {
        return [[id.ToString(),places.ToString(),startTime.ToString(),endTime.ToString()],route];
    }

}