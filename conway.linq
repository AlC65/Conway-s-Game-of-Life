void Main()
{
	var gldrlst = new List<Tuple<int, int>> {xy(0,0),xy(1,0),xy(2,0),xy(0,1), xy(1,2)};
	var glider = new HashSet<Tuple<int, int>>(gldrlst);
	for(int i=0;i<1000;i++) glider=advance(glider);
	foreach(var pt in glider) Console.WriteLine("{0}\t{1}",pt.Item1,pt.Item2);
}
Tuple<int, int> xy(int x, int y)
{
	return Tuple.Create(x,y);
}

IEnumerable<Tuple<int, int>> nbors(Tuple<int, int> p)
{
	int x=p.Item1,y=p.Item2;
	yield return(xy(x+1,y));
	yield return(xy(x + 1,y + 1));
	yield return(xy(x+1,y - 1));
	yield return(xy(x-1,y));
	yield return(xy(x - 1,y + 1));
	yield return(xy(x-1,y - 1));
	yield return(xy(x, y+1));
	yield return(xy(x, y-1));
}
HashSet<Tuple<int, int>> advance(HashSet<Tuple<int, int>> brd){
	var recalc = new HashSet<Tuple<int, int>>();
	var nbrd = new HashSet<Tuple<int, int>>();
	foreach(var pt in brd)
		foreach(var xy in nbors(pt)) recalc.Add(xy);
	recalc.UnionWith(brd);
	foreach (var pt in recalc)
	{
		int ct = 0;
		foreach (var xy in nbors(pt)) if(brd.Contains(xy)) ct++;	
		if(ct==3 ||(ct==2 && brd.Contains(pt))) nbrd.Add(pt);
	}
	return nbrd;
}
