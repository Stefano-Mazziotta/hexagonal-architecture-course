BeerData beerData = new BeerData();
beerData.Add("IPA");
beerData.Add("Stout");
beerData.Add("Lager"); // This will throw an exception because the limit is 2

var reportGeneratorBeer = new ReportGeneratorBeer(beerData);
var reportGeneratorHtmlBeer = new ReportGeneratorHtmlBeer(beerData);
var report = new Report();
report.Save(reportGeneratorHtmlBeer, "beer_report.html");

public interface IReportGenerator
{
    public string Generate();
}

public class BeerData
{
    protected List<string> beers;

    public BeerData()
    {
        beers = new List<string>();
    }

    public virtual void Add(string beer) => beers.Add(beer);

    public List<string> Get() => beers;

}

public class LimitedBeerData
{
    private BeerData beerData = new BeerData();
    private int limit;
    private int count = 0;

    public LimitedBeerData(int limit)
    {
        this.limit = limit;
    }

    public void Add(string beer)
    {
        if (count >= limit)
        {
            throw new InvalidOperationException($"Cannot add more than {limit} beers.");
        }
        beerData.Add(beer);
        count++;
    }
}

public class  ReportGeneratorBeer : IReportGenerator
{
    private BeerData beerData;
    public ReportGeneratorBeer(BeerData beerData)
    {
        this.beerData = beerData;
    }
    public string Generate()
    {
        string data = "";
        foreach (var beer in beerData.Get())
        {
            data += $"Beer: {beer}\n";

        }
        return data;
    }
}
public class ReportGeneratorHtmlBeer : IReportGenerator
{
    private BeerData beerData;
    public ReportGeneratorHtmlBeer(BeerData beerData)
    {
        this.beerData = beerData;
    }
    public string Generate()
    {
        string data = "<html><body>";
        foreach (var beer in beerData.Get())
        {
            data += $"<p>Beer: {beer}</p>";
        }
        data += "</body></html>";
        return data;
    }
}
public class Report
{
    public void Save(IReportGenerator reportGenerator, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            string data = reportGenerator.Generate();
            writer.Write(data);
        }
    }
}