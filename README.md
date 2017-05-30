# 32120528
Answer to Stack Overflow question 32120528

Sample code

```C#
// List pages that returned a 500 status code
var reader = new W3CReader(textReader);
foreach (var webevent in reader.Read().Where(w => w.Status >= 500 && w.Status <= 600)
         .OrderBy(w => w.Status)
         .ThenBy(w => w.Date)
         .ThenBy(w => w.UriStem)
         .ThenBy(w => w.UriQuery))
{
	Console.WriteLine("{0}\t{1}\t{2}{3}", webevent.Status.ToString().Red().Bold(), webevent.ToLocalTime(), 
		webevent.UriStem.Blue(), webevent.UriQuery.Yellow());
}
```

```C#
// List requests by hour
var q = new W3CReader(textReader).Read()
			 .GroupBy(r => r.UtcTime().RoundUp(TimeSpan.FromHours(1)))
			 .Select(g => new
			 {
				 	HalfHour = g.Key,
					Count = g.Count()
			 });
foreach (var r in q)
{
	Console.WriteLine("{0}\t{1}", r.HalfHour, r.Count);
}
```

```C#
// List extensions requested
var q = new W3CReader(textReader).Read()
			 .GroupBy(r => ExtractExtension(r.UriStem))
			 .Select(g => new
			 {
				 Count = g.Count(),
				 Paths = g.Key
			 }).OrderByDescending(g => g.Count);

foreach (var r in q)
{
	Console.WriteLine("{0}\t{1}", r.Count, r.Paths);
}
```