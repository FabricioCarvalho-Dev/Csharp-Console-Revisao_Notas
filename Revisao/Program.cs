namespace Revisao
{

    class Program
    {
         
         static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpçaoUsuario();

            while (opcaoUsuario.ToUpper() != "x")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                       Console.WriteLine("Informe Nome do aluno"); //TODO: adicionar alunos
                       Aluno aluno = new Aluno();
                       aluno.Nome = Console.ReadLine();

                       Console.WriteLine("Informe a nota do aluno");

                       if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                       {
                           aluno.Nota = nota;
                       }
                       else
                       {
                           throw new ArgumentException("Valor da nota deve ser decimal");
                       }

                       alunos[indiceAluno] = aluno;
                       indiceAluno++;

                       
                        break;
                    case "2": //TODO: listar alunos
                        foreach( var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                               Console.WriteLine($"ALUNO: {a.Nome} NOTA: {a.Nota}");
                            }
                            
                        }
                        
                        break;
                    case "3": //TODO: calcular media geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                         if(!string.IsNullOrEmpty(alunos[i].Nome))
                            { 
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        ConceitoE conceitoGeral;

                        if(mediaGeral < 2)
                        
                        {
                            conceitoGeral = ConceitoE.E;
                        }
                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = ConceitoE.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceitoGeral = ConceitoE.C;
                        }
                         else if(mediaGeral < 8)
                        {
                            conceitoGeral = ConceitoE.B;
                        }
                        else
                        {
                            conceitoGeral = ConceitoE.A;
                        }

                        Console.WriteLine($"MEDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opcaoUsuario = ObterOpçaoUsuario();
            }
        }

        private static string ObterOpçaoUsuario()
        {
            Console.WriteLine("Informe a opçao desejada: ");
            Console.WriteLine("1 - Inserir novo aluno ");
            Console.WriteLine("2 - Listar aluno ");
            Console.WriteLine("3 - Caucular Media geral ");
            Console.WriteLine("x - Sair ");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}