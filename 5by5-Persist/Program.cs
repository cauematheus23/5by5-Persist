using Controller;
using Model;

string path = "C:\\Users\\cauem\\JSONS\\dados_dos_radares.json";
string p2 = "C:\\Users\\L.Veronezzi\\AquivosJson\\radar.json";
//var lst = ReadFile.GetData(path);
var lst = ReadFile.GetData(p2);

PersistController pc = new PersistController();
if (pc.Insert(lst))
{
    Console.WriteLine("Inserido com sucesso");
}
else
{
    Console.WriteLine("Falha ao inserir");
}