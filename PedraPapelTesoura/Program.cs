using System;

class Program
{
    static int rodadas;


    public static void Main(string[] args)
    {
        //puxa a classe start para rodar no Main

        //ControlaRodadas();
        Start();
    }
    // Tela inicial
    //classe chamada start
    public static void Start()
    {

        Titulo(3);

        //colocar a opçao do usuario começar o jogo
        Console.WriteLine("Digite \"1\" para começar!");

        int iniciar;
        iniciar = Int32.Parse(Console.ReadLine());

        // se iniciar for diferente de 1 -> e o loop
        while (iniciar != 1)
        {
            //limpar a tela


            Titulo(3);

            Console.WriteLine("Opção invalida! Digite 1 para começar.");
            iniciar = Int32.Parse(Console.ReadLine());

        }
        //solicitar numero de rodadas
        DefineRodadas();


    }
    //desenhacabecalho do prof
    public static void Titulo(int linhasExtras)
    {

        Console.Clear();
        Console.WriteLine("*********************************");
        Console.WriteLine("*   PEDRA, PAPEL, ou TESOURA!   *");
        Console.WriteLine("*********************************");
        for (int i = 0; i < linhasExtras; i++)
        {
            Console.WriteLine("\n");
        }
    }
    public static void DefineRodadas()
    {


        Titulo(3);

        Console.WriteLine("Quantas Rodadas voce quer jogar? 3, 5 ou 7?: ");

        rodadas = Int32.Parse(Console.ReadLine());

        while (rodadas != 3 && rodadas != 5 && rodadas != 7)
        {
            Titulo(3);
            Console.WriteLine("Opção invalida! Digite novamente se, voce quer jogar, 3, 5 ou 7 rodadas: ");
            rodadas = Int32.Parse(Console.ReadLine());
        }
        ControlaRodadas();

    }    //fazendo uma função para fazer o while de controlar que o jogo             role a quantidade de rodadas escolhidas pelo Usuario.
    public static void ControlaRodadas()
    {
        int rodadaAtual = 1;
        int pontosUsuario = 0;
        int pontosProgama = 0;
        bool endGame = false;

        //enquanto fim de jogo for diferente de verdade 
        while (endGame != true)
        {
            Titulo(0);
            Console.WriteLine("          Rodada " + rodadaAtual.ToString() + "/" + rodadas.ToString() + "          ");
            Console.WriteLine("");
            Console.WriteLine("User: " + pontosUsuario.ToString() + " pontos   |  CPU " + pontosProgama.ToString() + "Pontos");


            switch (ExibeRodada())
            {
                case 0:
                    break;

                case 1:
                    pontosUsuario++;
                    rodadaAtual++;
                    if (pontosUsuario > rodadas / 2)
                    {
                        Console.WriteLine("usuario Venceu");
                        endGame = true;
                    }
                    break;
                case 2:
                    pontosProgama++;
                    rodadaAtual++;
                    if (pontosProgama > rodadas / 2)
                    {
                        Console.WriteLine("o computador Venceu");
                        endGame = true;
                    }
                    break;

            }
            if (endGame == true)
            {
                Titulo(3);
                if (pontosUsuario > pontosProgama)
                {
                    Console.WriteLine("Parabens voce venceu");
                }
                else
                {
                    Console.WriteLine("Não foi dessa vez");
                }
                Console.WriteLine("\n\n" + "Digite qualquer tecla para continuar");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n\n" + "Digite 1 para continuar ou 0 para sair");
                if (Int32.Parse(Console.ReadLine()) == 0)
                {
                    Start();
                }
            }


        }
    }
    public static int ExibeRodada()
    {

        //Algumas variáveis já estão criadas
        string escolhaDoUsuario; //armazena qual das opções o usuário escolheu
        string escolhaDoPrograma; //armazena qual da opções o computador sorteou
        string[] opcoes =  {
      "PEDRA",
      "PAPEL",
      "TESOURA"
    };
        //O Usuário deve escolher uma das opções. Lembrar de deixar claro quais são as opções
        Console.WriteLine("Escolha uma das opções: Pedra, Papel ou Tesoura?");
        escolhaDoUsuario = Console.ReadLine().ToUpper();
        while (escolhaDoUsuario != "PEDRA" && escolhaDoUsuario != "PAPEL" && escolhaDoUsuario != "TESOURA")
        {
            Console.WriteLine("Você fez uma escolha inválida. Digite novamente: Pedra, Papel ou Tesoura?");
            escolhaDoUsuario = Console.ReadLine().ToUpper();
        }
        //O Computador deve escolher uma das opções e o programa deve exibir qual foi essa escolha
        Random rand = new Random();
        int sorteio = rand.Next(opcoes.Length);
        escolhaDoPrograma = opcoes[sorteio];
        Console.WriteLine("A escolha do computador foi: " + escolhaDoPrograma);

        //O programa deve exibir quem ganhou, lembrando que Papel ganha de Pedra, Pedra ganha de Tesoura e Tesoura ganha de Papel
        if (escolhaDoUsuario == escolhaDoPrograma)
        {
            Console.WriteLine("Deu empate");
            return 0;
        }
        else if (escolhaDoUsuario == "PEDRA" && escolhaDoPrograma == "TESOURA")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else if (escolhaDoUsuario == "TESOURA" && escolhaDoPrograma == "PAPEL")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else if (escolhaDoUsuario == "PAPEL" && escolhaDoPrograma == "PEDRA")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else
        {
            Console.WriteLine("Que pena! Quem venceu foi o computador!");
            return 2;
        }
    }

}