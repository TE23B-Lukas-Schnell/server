WebApplication app = WebApplication.Create(args);

List<Lärare> båt = [
    new Lärare
    {
        Name = "Karim",
        Subject = "Båtigt",
        Lön = (int)Math.Log10(5),
    },
    new Lärare
    {
        Name = "Mikeal berg",
        Subject = "köttigt",
        Lön = (int)Math.Log(2,Math.E),
    }
];


app.MapGet("/", HetaAnton);
app.MapGet("/alla", BästaLärare);
app.MapGet("/get/{bat}", GetLärare);

app.Run();

List<Lärare> BästaLärare() => båt;

// Lärare GetLärare(int kött) => båt[Math.Clamp(kött,0,båt.Count)];
IResult GetLärare(int bat)
{
    if(bat < 0 || bat > båt.Count -1){
        return Results.NotFound();
    }
    else{
        return Results.Ok(båt[bat]);
    }
}

static string HetaAnton()
{
    return "hej jag heter anton";
}
