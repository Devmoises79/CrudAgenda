using AgendaContatos.Data;
using AgendaContatos.Models;

namespace AgendaContatos;

class Program
{
    static void Main(string[] args)
    {
        // Garante que o banco de dados existe
        using var db = new AppDbContext();
        db.Database.EnsureCreated();

        bool executando = true;
        
        while (executando)
        {
            Console.WriteLine("\n=== AGENDA DE CONTATOS ===");
            Console.WriteLine("1 - Listar contatos");
            Console.WriteLine("2 - Adicionar contato");
            Console.WriteLine("3 - Atualizar contato");
            Console.WriteLine("4 - Remover contato");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();
            
            switch (opcao)
            {
                case "1":
                    ListarContatos();
                    break;
                case "2":
                    AdicionarContato();
                    break;
                case "3":
                    AtualizarContato();
                    break;
                case "4":
                    RemoverContato();
                    break;
                case "5":
                    executando = false;
                    Console.WriteLine("Até logo!");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void ListarContatos()
    {
        using var db = new AppDbContext();
        var contatos = db.Contatos.ToList();
        
        if (contatos.Count == 0)
        {
            Console.WriteLine("\nNenhum contato cadastrado.");
            return;
        }
        
        Console.WriteLine("\n--- LISTA DE CONTATOS ---");
        foreach (var c in contatos)
        {
            Console.WriteLine($"ID: {c.Id} | Nome: {c.Nome} | Telefone: {c.Telefone} | Email: {c.Email}");
        }
    }

    static void AdicionarContato()
    {
        using var db = new AppDbContext();
        
        var contato = new Contato();
        
        Console.Write("\nNome: ");
        contato.Nome = Console.ReadLine();
        
        Console.Write("Telefone: ");
        contato.Telefone = Console.ReadLine();
        
        Console.Write("Email: ");
        contato.Email = Console.ReadLine();
        
        db.Contatos.Add(contato);
        db.SaveChanges();
        
        Console.WriteLine("Contato adicionado com sucesso!");
    }

    static void AtualizarContato()
    {
        using var db = new AppDbContext();
        
        Console.Write("\nID do contato a atualizar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var contato = db.Contatos.Find(id);
            
            if (contato != null)
            {
                Console.Write($"Novo nome (atual: {contato.Nome}): ");
                contato.Nome = Console.ReadLine();
                
                Console.Write($"Novo telefone (atual: {contato.Telefone}): ");
                contato.Telefone = Console.ReadLine();
                
                Console.Write($"Novo email (atual: {contato.Email}): ");
                contato.Email = Console.ReadLine();
                
                db.SaveChanges();
                Console.WriteLine("Contato atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Contato não encontrado!");
            }
        }
    }

    static void RemoverContato()
    {
        using var db = new AppDbContext();
        
        Console.Write("\nID do contato a remover: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var contato = db.Contatos.Find(id);
            
            if (contato != null)
            {
                db.Contatos.Remove(contato);
                db.SaveChanges();
                Console.WriteLine("Contato removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Contato não encontrado!");
            }
        }
    }
}