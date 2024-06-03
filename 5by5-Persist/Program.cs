using Controller;
using Model;

string path = "C:\\Users\\cauem\\JSONS\\dados_dos_radares.json";
var lst = ReadFile.GetData(path);

PersistController pc = new PersistController();