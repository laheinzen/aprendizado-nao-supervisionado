# Trabalho Final de Aprendizado Não Supervisionado 

Trabalho de aprendizado não supervisionado para a turma II da Pós em Data Science, com o professor Márcio Koch.

## Tecnologia

O trabalho foi feito em C# /.Net Core 3.1

Como não sou dev no dia a dia, é quase certo que o repositório GIT tem coisas a mais que não precisariam ser commitadas. E que existem parte do código que podem ser melhoradas.

Além disso, usei o emguCV (via NuGet) como wrapper do OpenCV. Até a metada da segunda aula, tentei adaptar o código Java para C#.

O grande problema que enfrentei foi que não encontrei no emguCV o equivale ao mat.put, o que inviablizou a minha implementação em C#. 

Até tentei pedir ajuda via [Stack Overflow](https://stackoverflow.com/questions/65864907/emgucv-equivalent-to-java-mat-puti-0-mv), mas não obtive resposta de como fazer alguma coisas. Com isso, acabei desistindo e deixei apenas para assistir as aulas novamente e fazer o trabalho final.

Então o código será simplificado e, onde possível, farei apenas chamadas em alto nível para o Open/Emgu CV.

Mas, como se pode ver, eu tentei fazer/enteder as rotinas.

Se houvesse tempo hábil, tentaria fazer em Python, mas sou menos familiar com Pythin ainda.

## Como rodar

Usar o Visual Studio, a versão Community é Free e nós como alunos / professores da FURB temos direito a uma licença do Visual Studio Professional.

O código usa a biblioteca emguCV, via NuGet. O Visual Studio deve baixar todas as bibliotecas e permitir a execução. Mas, de novo, não sou dev no dia a dia, então é possível que não fucione de primeira. É possível que até mesmo via VS Code funcione. 

Os caminhos dos arquivos estão setados relativamentes, então não deve haver dificuldades com relação a diretórios.
