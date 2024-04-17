using System;
using MySql.Data.MySqlClient;
using System.Data;

class Program {
  public static void Main (string[] args)
  {
      Database database = new Database();
      database.RunDatabaseOperations(args);
      
    string opcao = "";
    do
    {
        Console.WriteLine("╔═════════════════MENU DE OPÇÕES════════════════╗    ");
        Console.WriteLine("║ 1 SOMAR                                       ║    ");
        Console.WriteLine("║                                               ║    ");
        Console.WriteLine("║ 2 SUBTRAIR                                    ║    ");
        Console.WriteLine("║                                               ║    ");
        Console.WriteLine("║ 3 MULTIPLICAR                                 ║    ");
        Console.WriteLine("║                                               ║    ");
        Console.WriteLine("║ 4 DIVIDIR                                     ║    ");
        Console.WriteLine("║                                               ║    ");
        Console.WriteLine("║ 6 ADICIONA NOVO ALUNO                         ║    ");
        Console.WriteLine("║                                               ║    ");
        Console.WriteLine("║ 0 SAIR                                        ║    ");
        Console.WriteLine("╚═══════════════════════════════════════════════╝    ");
        Console.WriteLine(" ");
        Console.Write("DIGITE UMA OPÇÃO : ");

        opcao = Console.ReadLine();
        if(opcao == "0")
            break;
        
        Console.Clear(); 

        switch (opcao)
        {
            case "6":
            {
                
                Console.Write("Digite o RGM do aluno: ");
                string rgm = Console.ReadLine();

                Console.Write("Digite o nome do aluno: ");
                string nome = Console.ReadLine();

                try
                {
                    // Conectar ao banco de dados
                    MySqlConnection con = new MySqlConnection("Persist Security Info=False;server=sql.freedb.tech;database=freedb_umc_dp_kevin;uid=freedb_kevinmistrele;pwd=$QSNfS53YNrEUtw");
                    con.Open();

                    // Preparar a consulta SQL para inserir um novo aluno
                    string sql = "INSERT INTO ALUNO (Rgm, Nome) VALUES (@Rgm, @Nome)";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Rgm", rgm);
                    cmd.Parameters.AddWithValue("@Nome", nome);
        
                    // Executar a consulta
                    int rowsAffected = cmd.ExecuteNonQuery();
        
                    // Verificar se a inserção foi bem-sucedida
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Aluno adicionado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Falha ao adicionar aluno.");
                    }

                    // Fechar a conexão
                    con.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Erro ao adicionar aluno: {ex.Message}");
                }
                
                break;

            }
            case "2":
            {
                Console.Write("Digite o numero 1: ");
                int number1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Digite o numero 2: ");
                int number2 = Convert.ToInt32(Console.ReadLine());

                
                Console.WriteLine("+--------------------RESULTADO------------------+    ");
                Console.WriteLine("¦                                               ¦    ");
                Console.WriteLine("        A SUBTRAÇÃO de {0} - {1} = {2}                ", number1, number2, number1 - number2);
                Console.WriteLine("¦                                               ¦    ");
                Console.WriteLine("+-----------------------------------------------+    ");
                break;
            }
            case "3":
            {
                
                Console.Write("Digite o numero 1: ");
                int number1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Digite o numero 2: ");
                int number2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("+--------------------RESULTADO------------------+    ");
                Console.WriteLine("¦                                               ¦    ");
                Console.WriteLine("        A Multiplicação de {0} x {1} = {2}                ", number1, number2, number1 * number2);
                Console.WriteLine("¦                                               ¦    ");
                Console.WriteLine("+-----------------------------------------------+    ");
                break;
            }
            case "4":
            {
                
                Console.Write("Digite o numero 1: ");
                int number1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Digite o numero 2: ");
                int number2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("+--------------------RESULTADO------------------+    ");
                Console.WriteLine("¦                                               ¦    ");
                Console.WriteLine("        A Divisão de {0} / {1} = {2}                ", number1, number2, number1 / number2);
                Console.WriteLine("¦                                               ¦    ");
                Console.WriteLine("+-----------------------------------------------+    ");
                break;
            }
            case "0":
            {
                break;
            }
            default:
            {
                Console.WriteLine("Digitou uma opção invalida!!");
                break;
            }      
        }

    } while (opcao != "0");

  }
}