// See https://aka.ms/new-console-template for more information
using TrabalhoPOO;

SistemaAgenciaViagens system = new SistemaAgenciaViagens();
Console.WriteLine("Cadastro de Funcionario");
Funcionario Vinicius = new Funcionario("Vinicius", "123.123.123-123", "email@email.com");
Funcionario Lucas = new Funcionario("Lucas", "123.123.123-123", "lucas@email.com");
system.CadastrarFuncionario(Vinicius);
system.CadastrarFuncionario(Lucas);
Console.WriteLine("Funcionarios Cadastrados:");
foreach(var funcionario in system.GetFuncionarios()) 
{
    Console.WriteLine($"Nome: {funcionario.getNome()}, CPF: {funcionario.getCPF()}, Email: {funcionario.getEmail()}");
}
Console.WriteLine("");
Console.WriteLine("Cadastro de Usuarios de funcionarios");
Usuario vinicius = new Usuario(Vinicius, "vinicius.login", "senha123");
Usuario lucas = new Usuario(Lucas, "lucas.login", "lucas123");
system.CadastrarUsuario(vinicius);
system.CadastrarUsuario(lucas);
Console.WriteLine("Usuarios Cadastrados:");
foreach(var usuario in system.GetUsuarios()) 
{
    Console.WriteLine($"Usuario de: {usuario.getFuncionario().getNome()}: Login: {usuario.getLogin()}, Senha: {usuario.getSenha()}");
}
Console.WriteLine("");
Console.WriteLine("Cadastro de CompanhiaAerea");
CompanhiaAerea companhia = new CompanhiaAerea("Companhia Aérea GOL", "GOL", "GOL Linhas Aéreas S/A", "00.000.000/0001-00", 50.0, 80.0);
system.CadastrarCompanhia(companhia);
Console.WriteLine("Companhias Cadastradas:");
foreach(var companhias in system.GetCompanhias()) 
{
    Console.WriteLine($"Nome: {companhias.getNome()}, Codigo: {companhias.getCodigo()}, RazaoSocial: {companhias.getRazaoSocial()}, CNPJ: {companhias.getCnpj()}, valor da primeira bagagem: {companhias.getValorPrimeraBagagem()}, valor da bagagem adicional: {companhias.getValorBagagemAdicional()}");
}
Console.WriteLine("");
Console.WriteLine("Cadastro de Aeroporto");
Aeroporto aeroporto1 = new Aeroporto("Aeroporto Internacional de São Paulo", "GRU", "São Paulo", "SP", "Brasil");
Aeroporto aeroporto2 = new Aeroporto("Aeroporto Internacional John F. Kennedy", "JFK", "Nova York", "NY", "Estados Unidos");
system.CadastrarAeroporto(aeroporto1);
system.CadastrarAeroporto(aeroporto2);
Console.WriteLine("Aeroportos Cadastrados:");
foreach(var aeroporto in system.GetAeroportos()) 
{
    Console.WriteLine($"Nome: {aeroporto.getNome()}");
}
Console.WriteLine("");
Console.WriteLine("Cadastro de Voos");
DateTime dataIda = new DateTime(2024, 05, 07);
TipoTarifa tarifa = new TipoTarifa(10, 20, 30);
Moeda moeda = new Moeda("BRL", 1000);
Voo voo = new Voo(aeroporto1, aeroporto2, dataIda, "1234567", companhia, tarifa, moeda);
system.CadastrarVoo(voo);
Console.WriteLine("Voos cadastrados:");
foreach(var voos in system.GetVoos()) 
{
    Console.WriteLine($"Aeroporto de origem: {voos.getAeroportoOrigem().getNome()}, Aeroporto de destino: {voos.getAeroportoDestino().getNome()}, Data de ida: {voos.getDataHoraVoo()}, Tipo da Tarifa: {voos.GetTipoTarifa().getTarifaBasica()}, moeda do voo: {voos.getMoeda().GetTipoMoeda()}");
}
Console.WriteLine("");
Console.WriteLine("Cadastro de Passagens");
TipoDocumento tipoDocumento = new TipoDocumento("MG-123-123-123", "123.123.123-123", "12345678");
Passageiro passageiro = new Passageiro("Vinicius", "Almeida", tipoDocumento, "12345");
Passagem passagem = new Passagem(system.GetVoos(), tarifa, passageiro, 4, moeda, 4000);
system.CadastrarPassagem(passagem);
Console.WriteLine("Passagens Cadastradas:");
foreach(var pass in system.GetPassagens()) 
{
    Console.WriteLine($"Passagem de: {pass.GetPassageiro().getNome()}, Voos da passagem: {pass.getVoos()}, Tipo da tarifa: {pass.GetTipoTarifa().getTarifaBasica()}, Numero de bagagens: {pass.getNumeroBagagens()}, Moeda da passagem: {pass.GetMoeda().GetTipoMoeda()}, Valor total: {pass.getValorTotal()}");

}
Console.WriteLine("");
Console.WriteLine("Buscando um voo por data de ida e data de volta");
DateTime dataVolta = new DateTime(2024, 09, 10);
List<Voo> voosEncontrados = system.BuscarVoos(aeroporto1, aeroporto2, dataIda, dataVolta);
foreach(var voos in voosEncontrados) 
{
    Console.WriteLine($"Voos encontrados: {voos.getAeroportoOrigem().getNome()} para {voos.getAeroportoDestino().getNome()}, Pela: {voos.getCompanhiaAerea().getNome()}");
}
Console.WriteLine("");
//Falta implementar buscando um voo com conexão
Console.WriteLine("Buscando voo com conexão:");
List<Voo> voosComConexao = system.BuscarVoosComConexao(aeroporto1, aeroporto2, dataIda);
foreach(var voosConexao in voosComConexao) 
{
    Console.WriteLine(voosConexao);
}
Console.WriteLine("");
//Falta implementar buscando voos com conexão
Console.WriteLine("Buscando passagens dos passageiros");
List<Passagem> passagensDoPassageiro = system.BuscarPassagem(passageiro);
foreach(var passagensPassageiro in passagensDoPassageiro) 
{
    Console.WriteLine($"Passageiro: {passagensPassageiro.GetPassageiro().getNome()}, passagens do passageiro: {passagem.getVoos()}");
}

