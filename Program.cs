using AgendaContatos.Data;
using AgendaContatos.Models;

namespace AgendaContatos;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        // Modo de teste para GitHub Actions
        if (args.Length > 0)
        {
            return await ExecuteTestModeAsync(args);
        }

        // Execução normal da aplicação
        return await ExecuteNormalModeAsync();
    }

    private static async Task<int> ExecuteTestModeAsync(string[] args)
    {
        switch (args[0])
        {
            case "--test-mode":
                Console.WriteLine(" Modo de teste: Aplicação compilada com sucesso!");
                Console.WriteLine($" Versão: {typeof(Program).Assembly.GetName().Version}");
                Console.WriteLine($" Timestamp: {DateTime.Now}");
                return 0;

            case "--db-test":
                Console.WriteLine(" Testando conexão com o banco de dados...");
                try
                {
                    using var testDb = new AppDbContext();
                    await testDb.Database.EnsureCreatedAsync();
                    Console.WriteLine(" Banco de dados criado/verificado com sucesso!");

                    var count = testDb.Contatos.Count();
                    Console.WriteLine($" Total de contatos cadastrados: {count}");
                    return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Erro no banco de dados: {ex.Message}");
                    return 1;
                }

            default:
                Console.WriteLine($" Argumento desconhecido: {args[0]}");
                return 1;
        }
    }

    private static async Task<int> ExecuteNormalModeAsync()
    {
        try
        {
            // Inicializa e verifica o banco de dados
            using var db = new AppDbContext();
            await db.Database.EnsureCreatedAsync();

            var agendaManager = new AgendaManager(db);
            await agendaManager.ExecutarMenuPrincipalAsync();

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Erro fatal: {ex.Message}");
            return 1;
        }
    }
}

public class AgendaManager
{
    private readonly AppDbContext _db;

    public AgendaManager(AppDbContext db)
    {
        _db = db;
    }

    public async Task ExecutarMenuPrincipalAsync()
    {
        bool executando = true;

        while (executando)
        {
            ExibirMenu();
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    await ListarContatosAsync();
                    break;
                case "2":
                    await AdicionarContatoAsync();
                    break;
                case "3":
                    await AtualizarContatoAsync();
                    break;
                case "4":
                    await RemoverContatoAsync();
                    break;
                case "5":
                    executando = false;
                    Console.WriteLine(" Até logo!");
                    break;
                default:
                    Console.WriteLine(" Opção inválida!");
                    break;
            }
        }
    }

    private static void ExibirMenu()
    {
        Console.WriteLine("\n === AGENDA DE CONTATOS ===");
        Console.WriteLine("1 -  Listar contatos");
        Console.WriteLine("2 -  Adicionar contato");
        Console.WriteLine("3 -  Atualizar contato");
        Console.WriteLine("4 -  Remover contato");
        Console.WriteLine("5 -  Sair");
        Console.Write("Escolha uma opção: ");
    }

    private async Task ListarContatosAsync()
    {
        var contatos = await Task.Run(() => _db.Contatos.ToList());

        if (contatos.Count == 0)
        {
            Console.WriteLine("\n Nenhum contato cadastrado.");
            return;
        }

        Console.WriteLine("\n --- LISTA DE CONTATOS ---");
        foreach (var c in contatos)
        {
            Console.WriteLine($"ID: {c.Id} | Nome: {c.Nome} | Telefone: {c.Telefone} | Email: {c.Email}");
        }
    }

    private async Task AdicionarContatoAsync()
    {
        var contato = new Contato();

        Console.Write("\n Nome: ");
        contato.Nome = LerEntradaObrigatoria("Nome");

        Console.Write(" Telefone: ");
        contato.Telefone = LerEntradaObrigatoria("Telefone");

        Console.Write(" Email: ");
        contato.Email = LerEntradaObrigatoria("Email");

        _db.Contatos.Add(contato);
        await _db.SaveChangesAsync();

        Console.WriteLine(" Contato adicionado com sucesso!");
    }

    private async Task AtualizarContatoAsync()
    {
        Console.Write("\n ID do contato a atualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine(" ID inválido!");
            return;
        }

        var contato = await _db.Contatos.FindAsync(id);

        if (contato == null)
        {
            Console.WriteLine(" Contato não encontrado!");
            return;
        }

        Console.WriteLine($"\n Atualizando contato: {contato.Nome}");
        
        Console.Write($"Novo nome (atual: {contato.Nome}): ");
        var nome = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nome))
            contato.Nome = nome;

        Console.Write($"Novo telefone (atual: {contato.Telefone}): ");
        var telefone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(telefone))
            contato.Telefone = telefone;

        Console.Write($"Novo email (atual: {contato.Email}): ");
        var email = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(email))
            contato.Email = email;

        await _db.SaveChangesAsync();
        Console.WriteLine(" Contato atualizado com sucesso!");
    }

    private async Task RemoverContatoAsync()
    {
        Console.Write("\n ID do contato a remover: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine(" ID inválido!");
            return;
        }

        var contato = await _db.Contatos.FindAsync(id);

        if (contato == null)
        {
            Console.WriteLine(" Contato não encontrado!");
            return;
        }

        Console.Write($" Tem certeza que deseja remover {contato.Nome}? (s/N): ");
        var confirmacao = Console.ReadLine()?.ToLower();

        if (confirmacao == "s" || confirmacao == "sim")
        {
            _db.Contatos.Remove(contato);
            await _db.SaveChangesAsync();
            Console.WriteLine(" Contato removido com sucesso!");
        }
        else
        {
            Console.WriteLine("⏸ Operação cancelada.");
        }
    }

    private static string LerEntradaObrigatoria(string campo)
    {
        string? entrada;
        do
        {
            entrada = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.Write($" {campo} é obrigatório. Digite novamente: ");
            }
        } while (string.IsNullOrWhiteSpace(entrada));

        return entrada;
    }
}