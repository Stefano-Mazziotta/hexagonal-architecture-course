var beerData = new BeerData();
beerData.Add("IPA");
beerData.Add("Stout");

var reportGeneratorBeer = new ReportGeneratorBeer(beerData);
var report = new Report();
var data = reportGeneratorBeer.Generate();
report.Save(data, "beer_report.txt");

public class BeerData
{
    private List<string> beers;

    public BeerData()
    {
        beers = new List<string>();
    }

    public void Add(string beer) => beers.Add(beer);

    public List<string> Get() => beers;

}

public class  ReportGeneratorBeer
{
    private BeerData beerData;
    public ReportGeneratorBeer(BeerData beerData)
    {
        this.beerData = beerData;
    }

    public List<string> Generate()
    {
        var data = new List<string>();
        foreach (var beer in beerData.Get())
        {
            data.Add($"Beer: {beer}");
        }
        return data;
    }
}

public class Report
{
    public void Save(List<string> data, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var line in data)
            {
                writer.WriteLine(line);
            }
        }
    }
}